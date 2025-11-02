using UnityEngine;

public class first_person_rotation : MonoBehaviour
{
    private Transform tr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     tr = gameObject.GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = UnityEngine.Input.mousePosition;
        Vector3 mouseDir = Camera.main.ScreenToWorldPoint(mousePos).normalized;
        tr.rotation = Quaternion.LookRotation(mouseDir);
    }

    
}
