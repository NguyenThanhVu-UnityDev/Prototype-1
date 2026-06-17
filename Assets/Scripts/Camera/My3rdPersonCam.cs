using System;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class My3rdPersonCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 10, 0);
    [SerializeField] float minDistance = 0.2f;
    [SerializeField] float maxDistance = 3f;
    [SerializeField] float rotationSpeed =1f;
    [Range(0f, 90f)]
    [SerializeField] float maxVerticalAngle = 80f;
    [Range(-90f, 0f)]
    [SerializeField] float minVerticalAngle = -20f;

    private Vector3 relativePositionToTarget = Vector3.zero;
    void Start()
    {
        relativePositionToTarget = target.position - transform.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position;

        transform.position = desiredPosition - relativePositionToTarget;

        Vector3 dir = desiredPosition - transform.position;
        Vector2 input = Mouse.current.delta.ReadValue();

        // Calculate the angles to rotate based on input and rotation speed
        float horizAngleToRotate = input.x * rotationSpeed * Time.deltaTime;
        float vertAngleToRotate = input.y * rotationSpeed * Time.deltaTime;

        float currentHorizAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        float currentVertAngle = Mathf.Asin(dir.y / dir.magnitude) * Mathf.Rad2Deg;

        float newHorizAngle = currentHorizAngle + horizAngleToRotate;
        float newVertAngle = ((currentVertAngle + vertAngleToRotate) <= maxVerticalAngle && (currentVertAngle + vertAngleToRotate) >= minVerticalAngle) ? currentVertAngle + vertAngleToRotate : currentVertAngle;

        newHorizAngle = (newHorizAngle % 360f) > 180f ? (newHorizAngle % 360f) - 360f : (newHorizAngle % 360f);
        newVertAngle = (newVertAngle % 360f) > 180f ? (newVertAngle % 360f) - 360f : (newVertAngle % 360f);

        // Convert the angles back to a direction vector using spherical coordinates and standard trigonometric formulas
        Vector3 targetDir = new()
        {
            x = Mathf.Cos(newVertAngle * Mathf.Deg2Rad) * Mathf.Sin(newHorizAngle * Mathf.Deg2Rad),
            y = Mathf.Sin(newVertAngle * Mathf.Deg2Rad),
            z = Mathf.Cos(newVertAngle * Mathf.Deg2Rad) * Mathf.Cos(newHorizAngle * Mathf.Deg2Rad)
        };

        // Shoot a raycast from the desired position to the target to check if there are any obstacles in the way, and if so, move the camera between the desired position and the hit point so that the game view wont be obstructed
        var hits = Physics.RaycastAll(desiredPosition + offset, -targetDir.normalized, maxDistance);
        GameObject hitObject = null;
        float targetDistance = -1;
        if (hits.Length > 0) 
        {
            float minDistanceInHits = -1;
            foreach(var hitInfo in hits)
            {
                if (hitInfo.collider.gameObject == target.gameObject || 
                    hitInfo.collider.gameObject.transform.IsChildOf(target)) continue;

                if (minDistanceInHits == -1 || hitInfo.distance < minDistanceInHits)
                {
                    minDistanceInHits = hitInfo.distance;
                    hitObject = hitInfo.collider.gameObject;
                    targetDistance = hitInfo.distance;
                }
            }
        }
        if (hitObject == null)
        {
            transform.position = desiredPosition - targetDir.normalized * maxDistance + offset;
        }
        else if (targetDistance > minDistance)
        {
            transform.position = desiredPosition - targetDir.normalized * ((maxDistance < targetDistance) ? maxDistance : targetDistance) + offset;
        }
        else
        {
            transform.position += offset;
        }

        transform.LookAt(target);

        relativePositionToTarget = desiredPosition - transform.position + offset;
    }
}
