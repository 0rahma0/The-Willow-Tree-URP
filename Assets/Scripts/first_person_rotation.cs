using UnityEngine;

public class first_person_rotation : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 10f;
    public Transform tr;

    private void Start()
    {
        tr= GetComponent<Transform>();  
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(cam.transform.position.z - transform.position.z);

        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);

        transform.position = Vector3.Lerp(transform.position, worldPos, moveSpeed * Time.deltaTime);
    }
}