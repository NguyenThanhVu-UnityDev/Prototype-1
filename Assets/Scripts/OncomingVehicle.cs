using UnityEngine;

public class OncomingVehicle : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
     void FixedUpdate()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
