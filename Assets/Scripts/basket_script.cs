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

    // sold out
    public TextMeshProUGUI soldOut1;
    public TextMeshProUGUI soldOut2;

    // basket rows
    public Image[] row2;
    public Image[] row3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgrade1.image.color = new Color32(0xF5, 0xDE, 0xB3, 0xFF); // first upgrade possible
        upgrade2.image.color = new Color32(0xB4, 0x98, 0x72, 0xFF); // 2nd upgrade locked
        // 2nd adn 3rd basket rows disabled
        for(int i = 0; i< 4; i++)
        {
            row2[i].color = new Color32(0xB4, 0x98, 0x72, 0xFF);
            row3[i].color = new Color32(0xB4, 0x98, 0x72, 0xFF);
        }

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
                break;
            case 1:
                soldOut1.enabled = true;
                soldOut2.enabled = false;
                // first sold out 2nd enabled
                upgrade1.image.color = new Color32(0xB4, 0x98, 0x72, 0xFF);
                upgrade2.image.color = new Color32(0xF5, 0xDE, 0xB3, 0xFF);
                // 2nd row enabled
                for (int i = 0; i < 4; i++)
                {
                    row2[i].color = new Color32(0xF5, 0xDE, 0xB3, 0xFF);
                }
                break;
            case 2:
                soldOut1.enabled = true;
                soldOut2.enabled = true;
                // both sold out
                upgrade1.image.color = new Color32(0xB4, 0x98, 0x72, 0xFF);
                upgrade2.image.color = new Color32(0xB4, 0x98, 0x72, 0xFF);
                // 3rd row enabled
                for (int i = 0; i < 4; i++)
                {
                    row3[i].color = new Color32(0xF5, 0xDE, 0xB3, 0xFF);
                }
                break;
            default:
                break;
        }
    }

    public void upgradeBasket()
    {
        // increase size and upgrade times
        basketize += 4;
        upgrades++;
    }
}
