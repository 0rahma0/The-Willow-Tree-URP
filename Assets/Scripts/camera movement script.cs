using UnityEngine;

public class cameramovementscript : MonoBehaviour
{

    public Transform player;
    // camera position offset from player
    public Vector3 offset = new Vector3();
    public float deadZoneX = 10f;
    public float deadZoneZ = 10f;
    public float cameraSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        Vector3 currentPos = GetComponent<Transform>().position;

        if (player.position.x < 280)
        {
            currentPos.x = Mathf.Lerp(currentPos.x, targetPos.x, cameraSpeed * Time.deltaTime);
        }

         // float diffZ = player.position.z - (currentPos.z - offset.z);
        if (player.position.z > 50)
        {
            currentPos.z = Mathf.Lerp(currentPos.z, targetPos.z, cameraSpeed * Time.deltaTime);
        }

        GetComponent<Transform>().position = currentPos;

    }

    void LateUpdate()
    {
       
    }
}
