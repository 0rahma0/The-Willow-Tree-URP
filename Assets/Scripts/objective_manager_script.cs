using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class objective_manager_script : MonoBehaviour
{
    public TextMeshProUGUI objective;

    // objectives and booleans that control them
    private string obj1 = "collect 2 unique plants";
    bool collectedRed,collectedPurple = false;
    int collected = 0;

    private string obj2 = "heal orange goop";
    public static int healed = 0;

    private string obj3 = "explore further ";
    public static bool explored = false;

    private string obj4 = "get through thorns wall";
    public static bool cleared = false;

    private string obj5 = "head deeper into the forest";

    public static int currObj = 0 ; //becomes 1 when objectives start

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //currObj = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (currObj == 1)
        {   
            objective.text = "objective : \n" + obj1+" "+collected+"/2";
            //stuff to complete obj 1

            if (Foragingscript.foraged_plants.Contains("purple flower culster") && !collectedPurple)
            {
                Debug.Log("foraged purple flower unique++");
                collectedPurple = true;
                collected++;
            }
            if (Foragingscript.foraged_plants.Contains("red flower cluster") && !collectedRed)
            {
                Debug.Log("foraged red flower unique++");
                collectedRed = true;
                collected++;
            }
            if (collected == 2)
            {
                //obj1Comp = true;
                currObj = 2;
                objective.text = "objective : \n"+obj2;
            }
        }

        if (currObj == 2) 
        {
            objective.text = "objective : \n" + obj2 + " " + healed + "/3";
            if (healed == 3)
            {
                //obj2Comp = true;
                currObj = 3;
                objective.text = "objective : \n" + obj3 ;
            }
        }

        if(currObj == 3)
        {
            if (Foragingscript.foraged_plants.Contains("TallMush2"))
            {
                explored = true;
            }

            if (explored)
            {
                //obj3Comp = true;
                currObj = 4;
                objective.text = "objective : \n" + obj4;
            }

        }

        if (currObj == 4) 
        {
            if (cleared) {
                currObj = 5;
                objective.text = "objective : \n" + obj5;
                
            }
        }

        
    }
}
