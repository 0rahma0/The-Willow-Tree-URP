using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outside_lab_scene_manager : MonoBehaviour
{

    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            text.enabled=true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("lab scene");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.enabled = false;
        }
    }
}
