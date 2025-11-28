using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class basket_script : MonoBehaviour
{
    // this script handles adding stuff to basket adn basket upgrades along with ui changes to basket upgrade shop
    //inventory system
    public static int basketize = 5;
    public static ArrayList basketInv = new ArrayList();

    private static int upgrades; // how many times basket was upgraded, should be saved for when player closes and re-opens game

    // basket upgrade shop 
    public Button  upgrade1;
    public Button upgrade2;
    public Button upgrade3;

    // sold out
    public TextMeshPro soldOut1;
    public TextMeshPro soldOut2;
    public TextMeshPro soldOut3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // update sold out
        switch (upgrades)
        {
            case 0:
                soldOut1.enabled = false;
                soldOut2.enabled = false;
                soldOut3.enabled = false;
                break;
            case 1:
                soldOut1.enabled = true;
                soldOut2.enabled = false;
                soldOut3.enabled = false;
                break;
            case 2:
                soldOut1.enabled = true;
                soldOut2.enabled = true;
                soldOut3.enabled = true;
                break;
            default:
                break;
        }
    }

    public void upgradeBasket()
    {
        switch (upgrades)
        {
            case 0:
                // check required items are in basket

                // change button colors to lock old and unlock new
                upgrade1.image.color = new Color32(0xB4, 0x98, 0x72, 0xFF);
                upgrade2.image.color = new Color32(0xF5, 0xDE, 0xB3, 0xFF);
                
                
                break;
            case 1:
                // repeat as first upgrade
                upgrade2.image.color = new Color32(0xB4, 0x98, 0x72, 0xFF);
                upgrade3.image.color = new Color32(0xF5, 0xDE, 0xB3, 0xFF);
                break;
            case 2:
                // repeat as second upgrade
                upgrade3.image.color = new Color32(0xB4, 0x98, 0x72, 0xFF);
                break;
            default:
                return;
        }

        // increase size and upgrade times
        basketize += 5;
        upgrades++;
    }
}
