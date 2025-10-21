using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform tr;
    [SerializeField] int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        Vector3 move = transform.right  * x + transform.forward * -1 * z;

        tr.Translate(move * speed * Time.deltaTime);


    }
}
