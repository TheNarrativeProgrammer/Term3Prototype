using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField]
    private float _speed;

    private GameObject _playerObject;


    private Transform _playerLocation;

    private void Awake()
    {
        _playerObject = GameObject.Find("Player");
    }

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();                         //get reference to rb
    }

    private void FixedUpdate()
    {
        _playerLocation = _playerObject.transform;
        TrackPlayer();
    }


    private void TrackPlayer()
    {
        Vector3 playerDirection = (_playerLocation.position - gameObject.transform.position).normalized;            //Player.position is where we want to go. Subtract current position and normalize
        Quaternion enemyRotation = Quaternion.LookRotation(playerDirection);                                //get direction to face

        gameObject.transform.rotation = enemyRotation;                                                      //change rotation of this object
        _rb.linearVelocity = gameObject.transform.forward * _speed;                                         //keep same velocity
    }
   
}
