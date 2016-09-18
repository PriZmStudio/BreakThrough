using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed = 100.0f;
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        // Calculate the movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        // final movement vector
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        // apply movement
        motor.Move(_velocity);

        // calculate rotation as a 3D vector (turning left/right)
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0,_yRot, 0)*lookSensitivity;
        // Apply rotation
        motor.Rotate(_rotation);
    }
}
