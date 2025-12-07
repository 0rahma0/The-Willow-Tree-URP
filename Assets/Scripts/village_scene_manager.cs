using System;
using TMPro;
using UnityEngine;

public class village_scene_manager : MonoBehaviour
{

    public Rigidbody chief;
    public TextMeshProUGUI text;
    public Canvas dialogue_box;
    public static bool firstEntry = true;
    public string[] dialogue ;
    int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "";
        
       
    }

    // Update is called once per frame
    void Update()
    {

        if (!firstEntry)
        {
            //chief.gameObject.SetActive(false);
            dialogue_box.enabled = false;
        }

        if (firstEntry)
        {
            text.text = dialogue[i];
            
            if (Input.GetKeyDown(KeyCode.Space)){
                i++;
                if (i == dialogue.Length)
                {
                    firstEntry = false;
                }
                Debug.Log(i);

            } 
            
        }
        
    }
}
