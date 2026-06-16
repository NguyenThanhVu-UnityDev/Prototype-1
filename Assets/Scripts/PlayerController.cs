using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20000;
    [SerializeField] float steeringSpeed = 100f;
    [Range(0f, 90f)] 
    [SerializeField] float maxSteeringAngle = 80f;
    [SerializeField] InputAction moveAction;

    private float currentSteeringAngle = 0f;

    void Start()
    {
        moveAction.Enable();
    }

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        currentSteeringAngle = Mathf.Lerp(currentSteeringAngle, input.x * maxSteeringAngle, Time.deltaTime * steeringSpeed);
        currentSteeringAngle = Mathf.Clamp(currentSteeringAngle, -maxSteeringAngle, maxSteeringAngle);

        Vector3 steeringDirection = (Quaternion.Euler(0, currentSteeringAngle, 0) * transform.forward * input.y).normalized;
        
        if (steeringDirection.magnitude != 0 && steeringDirection != transform.forward) transform.rotation = Quaternion.LookRotation(Vector3.Lerp(transform.forward, steeringDirection, Time.deltaTime * steeringSpeed), Vector3.up);
        //transform.Rotate(Vector3.up, currentSteeringAngle);

        transform.Translate(Vector3.forward * input.y * speed * Time.deltaTime, Space.Self);
    }
}
