using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    //MOVEMENT ADJUSTABLE ATTRIBUTES
    [SerializeField] private float _mouseSensativity;

    //STORED VALUES
    private float _rotationAlongX = -90.0f;                         //set to -45f to make camera start looking forward. When set to 0f, camera looks at ground, at -90 looks at sky.
    private Vector3 _moveVector;

    private void Awake()
    {
        
       
        _moveVector = Vector3.zero;
    }

    private void Update()
    {                                                       //ASSIGN NORMALIZED MOVEMENT INPUT          AXIS        NEG RETURN = -1        NO INPUT = 0    POSI RETURN = 1
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensativity * Time.deltaTime;   //side to side     x-axis          -1  left            0               1   right
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensativity * Time.deltaTime;    //up & down        Y-axis          -1  down            0               1   up

        _rotationAlongX -= mouseY;                               // 1st handle VERTICAL ROTATION (x-axis) - CAMERA ONLY           assign rotation to opposite of Y movement

                                                    // upward   downward
        _rotationAlongX = Mathf.Clamp(_rotationAlongX, -50.0f, 5.0f);                              //Limit rotation so player can't do flip

                                                                                        //rotate ALONG x-axis       (1,0,0)     = vertical rotation         camera only
        Camera.main.transform.localRotation = Quaternion.Euler(_rotationAlongX, 0.0f, 0.0f);      //avoid gimble lock by locking other axis

                                                            // 2ns handle HORIZONTAL ROTATION (Y-axis) - Player & child camera      assign rotation to opposite of Y movement
        gameObject.transform.Rotate(Vector3.up * mouseX);                               //rotate ALONG y-axis       (0,1,0)     = horizontal rotation        player & camera
                                                                                        //                          vector3.up
    }
}
