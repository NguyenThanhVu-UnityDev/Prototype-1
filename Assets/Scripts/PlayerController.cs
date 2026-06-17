using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [Tooltip("In m/s")]
    [SerializeField] float maxSpeed = 30;
    //[SerializeField] float steeringSpeed = 100f;
    [SerializeField] float mass = 1200f;
    [SerializeField] float linearDamping = 0.1f;
    [SerializeField] float angularDamping = 1f;

    [Tooltip("In m/s^2")]
    [SerializeField] float acceleration = 5f;

    [Range(0f, 90f)] 
    [SerializeField] float maxSteeringAngle = 80f;
    [SerializeField] float steeringSpeed = 3f;  // how fast the car rotates toward the steer input
    [SerializeField] InputAction moveAction;
    // Test
    //[Header("Steering")]
    //[SerializeField] float maxSteerAngle = 35f; // degrees
    //[SerializeField] float steerReductionAtSpeed = 0.8f; // reduces steering as speed approaches topSpeed



    private Rigidbody playerRb;
    private float currentSteeringAngle = 0f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        InitPhysicsValues();
        moveAction.Enable();
    }

    private void InitPhysicsValues()
    {
        playerRb.mass = mass;
        playerRb.linearDamping = linearDamping;
        playerRb.angularDamping = angularDamping;
        playerRb.interpolation = RigidbodyInterpolation.Interpolate;
        playerRb.constraints = RigidbodyConstraints.None;
    }

    //void Update()
    //{
    //    Vector2 input = moveAction.ReadValue<Vector2>();

    //    currentSteeringAngle = Mathf.Lerp(currentSteeringAngle, input.x * maxSteeringAngle, Time.deltaTime * steeringSpeed);
    //    currentSteeringAngle = Mathf.Clamp(currentSteeringAngle, -maxSteeringAngle, maxSteeringAngle);

    //    Vector3 steeringDirection = (Quaternion.Euler(0, currentSteeringAngle, 0) * transform.forward * input.y).normalized;

    //    if (steeringDirection.magnitude != 0 && steeringDirection != transform.forward) transform.rotation = Quaternion.LookRotation(Vector3.Lerp(transform.forward, steeringDirection, Time.deltaTime * steeringSpeed), Vector3.up);
    //    //transform.Rotate(Vector3.up, currentSteeringAngle);

    //    transform.Translate(Vector3.forward * input.y * speed * Time.deltaTime, Space.Self);
    //}

    private void FixedUpdate()
    {
        Move();
        //TestMove();
    }

    private void Move()
    {
        if (playerRb == null) return;

        Vector2 input = moveAction.ReadValue<Vector2>();

        currentSteeringAngle = Mathf.Lerp(currentSteeringAngle, input.x * maxSteeringAngle, Time.deltaTime * steeringSpeed);
        currentSteeringAngle = Mathf.Clamp(currentSteeringAngle, -maxSteeringAngle, maxSteeringAngle);

        Vector3 steeringDirection = Quaternion.Euler(0, currentSteeringAngle, 0) * transform.forward * input.y;

        if (steeringDirection.magnitude != 0 && steeringDirection != transform.forward)
        {
            playerRb.MoveRotation(Quaternion.LookRotation(Vector3.Lerp(transform.forward, steeringDirection, Time.deltaTime * steeringSpeed), Vector3.up));
            //transform.rotation = Quaternion.LookRotation(Vector3.Lerp(transform.forward, steeringDirection, Time.deltaTime * steeringSpeed), Vector3.up);
        }
        //transform.Rotate(Vector3.up, currentSteeringAngle);
        //transform.Translate(Vector3.forward * input.y * maxSpeed * Time.deltaTime, Space.Self);
        playerRb.AddRelativeForce(Vector3.forward * input.y * acceleration, ForceMode.Acceleration);
    }

    //private void TestMove()
    //{
    //    if (playerRb == null) return;

    //    Vector2 input = moveAction.ReadValue<Vector2>();

    //    float steerInput = Mathf.Clamp(input.x, -1f, 1f);
    //    float throttleInput = Mathf.Clamp(input.y, -1f, 1f);

    //    // Current speed
    //    float speed = playerRb.linearVelocity.magnitude;

    //    // ForceMode.Acceleration: independent of mass
    //    if (throttleInput > 0f)
    //    {
    //        playerRb.AddRelativeForce(Vector3.forward * (acceleration * throttleInput), ForceMode.Acceleration);
    //    }
    //    else if (throttleInput < 0f)
    //    {
    //        // braking or reverse: stronger deceleration when braking (throttleInput negative)
    //        playerRb.AddRelativeForce(Vector3.forward * (acceleration * throttleInput), ForceMode.Acceleration);
    //    }

    //    // implement simple braking
    //    if ((throttleInput < 0f && Vector3.Dot(playerRb.linearVelocity, transform.forward) > 0f) ||
    //        (throttleInput > 0f && Vector3.Dot(playerRb.linearVelocity, transform.forward) < 0f))
    //    {
    //        // apply immediate decay
    //        playerRb.linearVelocity = Vector3.MoveTowards(playerRb.linearVelocity, Vector3.zero, brakingDeceleration * Time.fixedDeltaTime);
    //    }

    //    // clamp top speed (project forward component)
    //    Vector3 flatVel = new Vector3(playerRb.linearVelocity.x, 0f, playerRb.linearVelocity.z);
    //    if (flatVel.magnitude > maxSpeed)
    //    {
    //        Vector3 limited = flatVel.normalized * maxSpeed;
    //        playerRb.linearVelocity = new Vector3(limited.x, playerRb.linearVelocity.y, limited.z);
    //    }

    //    // ---- Steering: reduce steering at higher speed to avoid twitchiness
    //    float speedFactor = Mathf.Clamp01(speed / maxSpeed); // 0..1
    //    float steerScale = 1f - (speedFactor * steerReductionAtSpeed);
    //    float steerAngle = steerInput * maxSteerAngle * steerScale;

    //    // apply rotation by moving the Rigidbody rotation (better than transform.Rotate)
    //    Quaternion targetRot = Quaternion.Euler(0f, steerAngle * steeringSpeed * Time.fixedDeltaTime, 0f);
    //    playerRb.MoveRotation(playerRb.rotation * targetRot);
    //}
}
