using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 360f;
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
