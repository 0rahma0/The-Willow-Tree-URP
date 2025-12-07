using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_managment_script : MonoBehaviour
{
    // player
    private Rigidbody rb;
    private Transform tr;

    //-----for scenes where starting position changes--------
    //spawning outside lab
    public static Vector3 from_forest = new Vector3(24.5f, 0.5f, 131f); // rot=90
    public static Vector3 from_lab = new Vector3(144f, 0.5f, 115.5f); // rot =0
    public static Vector3 from_village = new Vector3(272, 0.5f, 133.5f); //rot=-90
    // spawning in village from forest
    public static Vector3 forest_to_village_pos = new Vector3(380f, -2f, 145f); //rot=-90

    // booleans for changign spwan positiom
    private static bool lab_to_outside;
    private static bool village_to_lab;
    private static bool forest_to_lab;
    private static bool forest_to_village;

    // first scene entries to control objectives
    public static bool first_corrupted_forest_entry = false;
    public static bool first_normal_forest_entry = false;
    // loadign screen canvas
    public Canvas loadingScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get player rigid body and transform
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        //loadingScreen.enabled = false;

        //-----setting spwan postion and activated booleans to false-----
        if (lab_to_outside)
        {
            tr.position = from_lab;
            tr.rotation = Quaternion.Euler(0f, 0f, 0f);
            lab_to_outside = false;
        }

        if (forest_to_lab)
        {
            tr.position = from_forest;
            tr.rotation = Quaternion.Euler(0f, 90f, 0f);
            forest_to_lab = false;
        }

        if (village_to_lab)
        {
            tr.position = from_village;
            tr.rotation = Quaternion.Euler(0f, -90f, 0f);
            village_to_lab = false;
        }

        if (forest_to_village)
        {
            tr.position = forest_to_village_pos;
            tr.rotation = Quaternion.Euler(0f, -90f, 0f);
            forest_to_village = false;
        }
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
            case "forest_to_lab":
                forest_to_lab = true;
                Debug.Log("going from forest to ouside lab");
                //SceneManager.LoadScene("outside lab");
                StartCoroutine(loadScene("outside lab"));
                break;
            case "lab_to_forest":
                //SceneManager.LoadScene("forest with river");
                // to be used by dialogue manager
                if (!first_normal_forest_entry)
                    first_normal_forest_entry = true;
                StartCoroutine(loadScene("forest with river"));
                break;
            case "lab_to_village":
                //SceneManager.LoadScene("village");
                StartCoroutine(loadScene("village"));
                break;
            case "village_to_lab":
                village_to_lab=true;
                //SceneManager.LoadScene("outside lab");
                StartCoroutine(loadScene("outside lab"));
                break;
            case "village_to_forest":
                // to be used by dialogue manager
                if (!first_corrupted_forest_entry)
                    first_corrupted_forest_entry = true;
                //SceneManager.LoadScene("corrupted forest");
                StartCoroutine(loadScene("corrupted forest"));
                break;
            case "forest_to_village":
                forest_to_village = true;
                StartCoroutine(loadScene("village"));
                //SceneManager.LoadScene();
                break;
            default:
                break;

        }
    }

    private void OnTriggerStay(Collider collider)
    {
        // switching from inside lab to outside, seperated because it requires key press
        // switching into lab dosent require spawn point change so is handled in the same script as the canvas
        // telling the player to press E to enter
        if(collider.gameObject.tag == "lab_to_forest" && Input.GetKeyDown(KeyCode.E))
        {
            lab_to_outside = true;
            SceneManager.LoadScene("outside lab");

        }

        if (collider.gameObject.tag == "lab_to_forest" && Input.GetKeyDown(KeyCode.E))
        {
            lab_to_outside = true;
            SceneManager.LoadScene("outside lab");

        }
    }

    // loading screen between scenes
    IEnumerator loadScene(string sceneName)
    {
        loadingScreen.enabled = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
        loadingScreen.enabled = false;
        
    }

}

