using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset = new();

    private void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.transform.position + offset;
    }
}
