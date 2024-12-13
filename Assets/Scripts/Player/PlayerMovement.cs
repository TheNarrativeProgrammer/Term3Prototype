using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //MOVEMENT ADJUSTABLE ATTRIBUTES
    [SerializeField] private    int     _speed  = 20;

    //APPLY FORCES TO OBJECT
    private Rigidbody   _rb;                                        //RigidBody -> what the force is applied to     what's moving
    private Vector3     _moveVector;                                //Vector3 -> the force that is applied          where to move

    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;                   //turn off visibility of cursor. Note: always put this in PlayerMovement, not in cameraMovement script.
        _rb = gameObject.GetComponent<Rigidbody>();                 //assign the RigidBody element of the object this script is attached to variable _rb

        _moveVector = Vector3.zero;                                 //initialize all 3 vector values to 0. Makes player stationary at beginning

        
    }

    private void Update()
    {
                                                            //ASSIGN NORMALIZED MOVEMENT INPUT      AXIS        NEG RETURN = -1        NO INPUT = 0    POSITIVE RETURN = 1
        float xMovement = Input.GetAxis("Horizontal");              //side to side                  x-axis         A = -1                                   D = 1
        float zMovement = Input.GetAxis("Vertical");                //forward backward              x-axis         S = -1                                   W = 1

                                                        //ASSIGN NORMALIZED MOVEMENT INPUT      shorthand for   NEG RETURN = -1        NO INPUT = 0    POSITIVE RETURN = 1
                                                                    //tranform.right            (1,0,0)         (-1,0,0)   left         (0,0,0)  right      (1,0,0)
                                                                    //tranform.forward          (0,0,1)         (0,0,-1)   back         (0,0,0)  forward    (0,0,1)
        _moveVector = transform.right * xMovement + transform.forward * zMovement;  //addition of 2 vectors results in single vector. This is force applied to RB
    }

    private void FixedUpdate()
    {
        MoveRB();
    }

    private void MoveRB()
    {
        _rb.AddForce(_moveVector * _speed);
    }

    



}
