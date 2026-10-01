using UnityEngine;
using Unity.Cinemachine; // Required for Cinemachine 3 in Unity 6

public class LocalCameraSetup : MonoBehaviour
{
    private CinemachineCamera cinemachineCam;

    void Awake()
    {
        // Get the CinemachineCamera component on this same GameObject
        cinemachineCam = GetComponent<CinemachineCamera>();
        if (cinemachineCam == null)
        {
            Debug.LogError("CinemachineCamera component not found on this GameObject!");
        }
    }

    // Call this method to assign the local player's transform
    public void SetLocalTarget(Transform playerTransform)
    {
        if (cinemachineCam != null && playerTransform != null)
        {
            cinemachineCam.Target.TrackingTarget = playerTransform;
            Debug.Log("Camera successfully locked onto: " + playerTransform.name);
        }
    }
}