using TMPro;
using UnityEngine;

public class forest_dialogue_manager : MonoBehaviour
{
    // dialogue text, canvas, and objective canvas
    public TextMeshProUGUI dialogue;
    private Canvas dialogue_canvas;
    public Canvas objective;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       dialogue_canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene_managment_script.first_normal_forest_entry)
        {
            dialogue_canvas.enabled = true;
            dialogue.text = "looks like i can find some nice ingredients here";
        }

        if (scene_managment_script.first_normal_forest_entry && Input.GetKeyDown(KeyCode.Space))
        {
            dialogue_canvas.enabled = false;
            scene_managment_script.first_normal_forest_entry = false;
            objective_manager_script.currObj = 1;
        }
    }
}
