using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
  public static Action<bool> OnGameOverEvent;
    public static Action<bool> OnGameWonEvent;

    private EnemySpawner EnemySpawnerRef;

    private void Start()
    {
        OnGameOverEvent += DestroyEnemies;
        OnGameWonEvent += DestroyEnemies;
    }

    public static void GameOver()
    {
        OnGameOverEvent?.Invoke(true);
        
    }

    public static void GameWon()
    {
        OnGameWonEvent?.Invoke(true);
    }

    private void DestroyEnemies(bool unUsedBool)
    {
        if (EnemySpawnerRef != null)
        {
            return;
            Debug.LogError("no ref to Enemy Spawner");
        }
        EnemySpawnerRef.SetStopCorroutine();
         GameObject[] enemiesSpawned = GameObject.FindGameObjectsWithTag("Enemy");       //Get any array of all enemies spawned
        foreach(GameObject enemy in enemiesSpawned)
        {
            Destroy(enemy);
        }
    }
}
