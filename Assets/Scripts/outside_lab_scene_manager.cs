using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outside_lab_scene_manager : MonoBehaviour
{
    public Transform player;

    public TextMeshProUGUI text;

    public static Transform playerTrans;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("switching to lab scene");
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
