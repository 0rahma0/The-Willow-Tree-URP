using TMPro;
using UnityEngine;

public class corrupted_forest_scene_manager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Canvas dialogue_box;
    public bool nearThorns;
    public static bool first_time = true;

    public Transform tr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "hmm... i gotta get past these thorns to explore further";
        dialogue_box.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (tr.position.x > 150)
        {
            nearThorns = true;
        }

        if (nearThorns && first_time)
        {
            dialogue_box.enabled = true;
            objective_manager_script.explored = true;
        }

        if(nearThorns && Input.GetKey(KeyCode.Space))
        {
            dialogue_box.enabled = false;
            first_time = false;
        }


    }
}
