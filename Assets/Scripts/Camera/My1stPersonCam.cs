using UnityEngine;

public class My1stPersonCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + Quaternion.LookRotation(target.transform.forward) * offset;
            transform.rotation = Quaternion.LookRotation(target.transform.forward);
        }
    }
}
