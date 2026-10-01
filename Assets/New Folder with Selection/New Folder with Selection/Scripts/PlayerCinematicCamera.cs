using UnityEngine;
using Unity.Cinemachine; // Required for Cinemachine 3 in Unity 6

public class PlayerCinematicCamera : MonoBehaviour
{
    private CinemachineCamera cinemachineCam;

    void Awake()
    {
        cinemachineCam = GetComponent<CinemachineCamera>();
        if (cinemachineCam == null)
        {
            cinemachineCam = GetComponentInChildren<CinemachineCamera>();
        }
    }

    public void SetTarget(GameObject targetObject)
    {
        if (cinemachineCam != null && targetObject != null)
        {
            cinemachineCam.Target.TrackingTarget = targetObject.transform;
            Debug.Log("[PlayerCinematicCamera] Camera now tracking: " + targetObject.name);
        }
        else
        {
            Debug.LogWarning("[PlayerCinematicCamera] CinemachineCamera or targetObject is missing!");
        }
    }
}