using Unity.Mathematics;
using UnityEngine;

public class village_follow_script : MonoBehaviour
{
    public Transform player;
    public Animator playerAnim;
    private Transform tr;

    private float posZChange = 0;
    private float posXChange = 0;
    private float startZpos;

    private float Zoffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tr = GetComponent<Transform>();
        Zoffset = tr.position.z - player.position.z;

        startZpos = tr.position.z;

        posZChange = tr.position.z;
        posXChange = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float v = UnityEngine.Input.GetAxis("Vertical");
        float h = UnityEngine.Input.GetAxis("Horizontal");

        if ( playerAnim.GetBool("walking"))
        {
            if (player.position.z < 130 && v != 0)
            {
                posZChange = player.position.z + Zoffset;
            }
            else { 
                posZChange = tr.position.z; 
            }
           
            if (h < 0)
            {
                posXChange = 20;
            }
            else if (h > 0)
            {
                posXChange = -20;
            }
            else { posXChange = 0; }
        }
        else { posXChange = 0; posZChange = tr.position.z; }

        if (player.position.z > 130)
        {
            posZChange = startZpos;
        }


        Vector3 newPos = new Vector3(
                player.position.x + posXChange,
                tr.position.y,
                posZChange);
        

        tr.position = math.lerp(tr.position, newPos, Time.deltaTime);
    }
}
