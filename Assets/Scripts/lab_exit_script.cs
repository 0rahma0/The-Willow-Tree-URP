using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lab_exit_script : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            text.enabled = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        //if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player")
        //{
          
        //   SceneManager.LoadScene("outside lab");
        //}
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.enabled = false;
        }
    }
}
