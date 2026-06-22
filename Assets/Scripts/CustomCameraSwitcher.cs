using UnityEngine;
using UnityEngine.InputSystem;

public class CustomCameraSwitcher : MonoBehaviour
{
    [SerializeField] InputAction switchCamAction;
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] Camera thirdPersonCamera;

    private void Start()
    {
        switchCamAction.started += ctx => SwitchCamera();
        switchCamAction.Enable();

        if (firstPersonCamera != null && thirdPersonCamera != null)
        {
            firstPersonCamera.gameObject.SetActive(false);
            thirdPersonCamera.gameObject.SetActive(true);
        }
    }

    private void SwitchCamera()
    {
        Debug.Log($"Switch camera: {firstPersonCamera} {thirdPersonCamera}");
        if (firstPersonCamera != null && thirdPersonCamera != null)
        {
            firstPersonCamera.gameObject.SetActive(!firstPersonCamera.gameObject.activeInHierarchy);
            thirdPersonCamera.gameObject.SetActive(!thirdPersonCamera.gameObject.activeInHierarchy);
        }
    }
}
