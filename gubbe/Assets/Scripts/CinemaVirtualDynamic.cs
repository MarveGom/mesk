using UnityEngine;
using Cinemachine;

public class CinemachineVirtualDynamic : MonoBehaviour
{
    [SerializeField]
    private Transform focusObjectTransform;

    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain);
        if (brain == null)
        {
            brain = Camera.main.gameObject.AddComponent<CinemachineBrain>();
        }
        brain.m_DefaultBlend.m_Time = 1;
        brain.m_ShowDebugText = true;

        cinemachineVirtualCamera = gameObject.AddComponent<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = focusObjectTransform;
        cinemachineVirtualCamera.LookAt = focusObjectTransform;
        cinemachineVirtualCamera.Priority = 1;

        CinemachineTransposer transposer = cinemachineVirtualCamera.AddCinemachineComponent<CinemachineTransposer>
            ();
        transposer.m_FollowOffset = new Vector3(0f, 0f, -20);

        CinemachineComposer composer = cinemachineVirtualCamera.AddCinemachineComponent<CinemachineComposer>();
        composer.m_ScreenX = 0.30f;
        composer.m_ScreenY = -0.11f;
    }
}