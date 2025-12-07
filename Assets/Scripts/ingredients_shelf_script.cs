using UnityEngine;

public class ingredients_shelf_script : MonoBehaviour
{

    public static GameObject[] inventory = new GameObject[10];
    // quantities with a max of 5
    public static int[] quantities = {1, 2, 2, 0, 0, 0, 0, 0, 0};

    public GameObject redflwoers;
    public GameObject blueflwoers;
    public GameObject mushrooms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // preset slots for where each plant is stored
        inventory[0] = redflwoers;
        inventory[1] = blueflwoers;
        inventory[2] = mushrooms;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < quantities.Length; i++)
        {
            // deactivate object if quantity is 0
            if ((quantities[i] == 0) && inventory[i] != null)
            {
                //inventory[i].transform.position = 
                //            new Vector3(inventory[i].transform.position.x + 10,
                //                        inventory[i].transform.position.y,
                //                        inventory[i].transform.position.z);
                inventory[i].SetActive(false);
            }
        }
    }

    public static void updateCount(GameObject plant)
    {
        // put in player inventory
        playerscript.addToInv(plant);
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                // deduct count of taken shelf ingredients
                if (plant.name == inventory[i].name)
                {
                    quantities[i] -= 1;
                    break;
                }
            }
        }  
        
    }
}
