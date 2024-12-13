using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] 
    private Transform player;

    [SerializeField]
    private float spawnTimeMin = 0.5f;

    [SerializeField]
    private float spawnTimeMax = 4.0f;

    [SerializeField]
    private GameObject EnemiesPrefab;

    [SerializeField]
    private Transform SpawnLocation;

    public bool isSpawnEnemy = true;


    public void Awake()
    {
        isSpawnEnemy = true;
    }

    void Start()
    {
        StartCoroutine(SpawnDelayCoroutine());
        
    }


    private IEnumerator SpawnDelayCoroutine()
    {
        while (isSpawnEnemy)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(GetRandomDelay());
        }
    }

    public void SetStopCorroutine()
    {
        isSpawnEnemy = false;
        StopCoroutine(SpawnDelayCoroutine());
    }

    private int GetRandomDelay()
    {
        int results = (int)Random.Range(spawnTimeMin, spawnTimeMax); ;
        return results;
    }

    private void SpawnEnemy()
    {
        Vector3 startPosition = SpawnLocation.position;
        Vector3 endPosition = player.position;

        GameObject enemy = GameObject.Instantiate(EnemiesPrefab, startPosition, SpawnLocation.transform.rotation);
        enemy.transform.LookAt(endPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
