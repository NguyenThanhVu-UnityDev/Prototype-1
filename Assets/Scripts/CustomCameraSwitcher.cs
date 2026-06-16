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
            firstPersonCamera.enabled = false;
            thirdPersonCamera.enabled = true;
        }
    }

    private void SwitchCamera()
    {
        Debug.Log($"Switch camera: {firstPersonCamera} {thirdPersonCamera}");
        if (firstPersonCamera != null && thirdPersonCamera != null)
        {
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
        }
    }
}
