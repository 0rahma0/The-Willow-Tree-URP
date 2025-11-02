using UnityEngine;

public class ingredients_shelf_script : MonoBehaviour
{

    public static GameObject[] inventory = new GameObject[10];
    public static int[] quantities = {1, 2, 0, 0, 0, 0, 0, 0, 0};

    public GameObject redflwoers;
    public GameObject blueflwoers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory[0] = redflwoers;
        inventory[1] = blueflwoers;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < quantities.Length; i++)
        {
            if ((quantities[i] == 0) && inventory[i] != null)
            {
                inventory[i].SetActive(false);
            }
        }
    }

    public static void updateCount(GameObject plant)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(plant.name == inventory[i].name)
            {
                quantities[i] -= 1;
                break;
            }
        }  
        playerscript.addToInv(plant);
    }
}
