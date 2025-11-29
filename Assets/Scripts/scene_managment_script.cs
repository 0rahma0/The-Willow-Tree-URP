using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_managment_script : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {

        // switch on diffrent invisible wall tags
        switch (collision.gameObject.tag)
        {
            case "lab_to_forest":
                SceneManager.LoadScene("forest with river");
                break;
            case "lab_to_village":
                SceneManager.LoadScene("village");
                break;
            default:
                break;

        }
    }

}

