using Unity.Cinemachine;
using UnityEngine;

public class cameraswitchscript : MonoBehaviour
{
    public CinemachineCamera firstPersonCam;
    public CinemachineCamera thirdPersonCam;
    private bool isFirstPerson = false;
    void Start()
    {
        // Start with first person camera active
        firstPersonCam.enabled = false;
        thirdPersonCam.enabled = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            firstPersonCam.enabled = isFirstPerson;
            thirdPersonCam.enabled = !isFirstPerson;
        }
    }
}
