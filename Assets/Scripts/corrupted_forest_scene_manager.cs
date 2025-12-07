using TMPro;
using UnityEngine;

public class corrupted_forest_scene_manager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Canvas dialogue_box;
    public bool nearThorns;
    public static bool first_time = true;

    public static bool first_entry = true;


    public Transform tr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        dialogue_box.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (tr.position.x > 150)
        {
            nearThorns = true;
        }

        if (nearThorns && first_time && objective_manager_script.currObj == 3)
        {
            dialogue_box.enabled = true;
            text.text = "hmm... i gotta get past these thorns to explore further";
            objective_manager_script.explored = true;
        }

        if(nearThorns && Input.GetKey(KeyCode.Space))
        {
            dialogue_box.enabled = false;
            first_time = false;
        }

        if (scene_managment_script.first_corrupted_forest_entry && first_entry)
        {
            dialogue_box.enabled = true;
            text.text = "wow..this looks awful..and..interesting.";
            
        }

        if (scene_managment_script.first_corrupted_forest_entry && Input.GetKey(KeyCode.Space))
        {
            dialogue_box.enabled = false;
            first_entry = false;
            scene_managment_script.first_corrupted_forest_entry = false;
        }

        if (objective_manager_script.cleared )
        {
            dialogue_box.enabled = true;
            text.text = "now i can head deepr in";
        }

        if (objective_manager_script.cleared && Input.GetKey(KeyCode.Space))
        {
            dialogue_box.enabled = false;
            objective_manager_script.cleared = false;

        }


    }
}
