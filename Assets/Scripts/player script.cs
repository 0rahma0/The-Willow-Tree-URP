using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Windows;
//using Image = UnityEngine.UI.Image;

public class playerscript : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private Rigidbody rb;
    private Transform tr;

    // player movement
    public Camera cameraObj;
    private CharacterController controller;

    // gravity for character controller
    public float gravity;
    private Vector3 velocity = new Vector3(0f,0f,0f);

    //inventory
    public static GameObject[] pocketInv = new GameObject[5];
    public static GameObject selectedItem ;
    public static int selectedIndex ;

    //inventory items
    public UnityEngine.UI.Image[] items_inspector;
    public static UnityEngine.UI.Image[] items;
    // plant images
    public  Sprite red_flower_image_ins;
    public  Sprite purple_flower_image_ins;
    public  Sprite mushroom_image_ins;

    public static Sprite red_flower_image;
    public static Sprite purple_flower_image;
    public static Sprite mushroom_image;

    // healing
    // public bool canHeal = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize player components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();

        items = items_inspector;
        red_flower_image = red_flower_image_ins;
        purple_flower_image= purple_flower_image_ins;
        mushroom_image = mushroom_image_ins;
    }

    // Update is called once per frame
    void Update()
    {
        float h = UnityEngine.Input.GetAxis("Horizontal");
        float v = UnityEngine.Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0f, v).normalized;


        // get camera forward/right directions
        Vector3 camForward = cameraObj.transform.forward;
        Vector3 camRight = cameraObj.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // move relative to camera direction
        Vector3 moveDir = (camForward * v + camRight * h).normalized;

        //apply gravity
        velocity.y += gravity*-1 * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (move.magnitude >= 0.1f)
        {
            anim.SetBool("walking", true);
            tr.rotation = Quaternion.LookRotation(moveDir, Vector3.up);
            controller.Move(moveDir * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("walking", false);
        }


        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1)){
            selectedItem = pocketInv[0];
            selectedIndex = 0;
            Debug.Log("holding "+ selectedItem);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = pocketInv[1];
            selectedIndex = 1;
            Debug.Log("holding " + selectedItem);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedItem = pocketInv[2];
            selectedIndex = 2;
            Debug.Log("holding " + selectedItem);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedItem = pocketInv[3];
            selectedIndex = 3;
            Debug.Log("holding " + selectedItem);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedItem = pocketInv[4];
            selectedIndex = 4;
            Debug.Log("holding " + selectedItem);
        }


        

    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.gameObject.tag == "forage")
        //{
        //    isNearForage = true;
        //    Debug.Log(collider.gameObject.name);

        //}
    }

    private void OnTriggerStay(Collider collider)
    {
        //if (collider.gameObject.tag == "forage" && pull == pullGoal)
        //{
        //    //updateInv(collider.gameObject.name);
        //    Debug.Log(collider.gameObject.name);

        //    pull = 0;
        //    Destroy(collider.gameObject);

            
        //}

        //if (collider.gameObject.tag == "goop" && UnityEngine.Input.GetKeyDown(KeyCode.E))
        //{
        //    StartCoroutine(heal());
        //}

    }

    private void OnTriggerExit(Collider collider)
    {
        //if (collider.gameObject.tag == "forage")
        //{
        //    isNearForage = false;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {

    }


    private void updateInv(string name)
    {
        string cutName = name;
        if (name.EndsWith((')')) ){
            cutName = name.Remove(name.Length - 4);
        }

        string itemName = "";
        switch (name)
        {
            case "red flower cluster":
                itemName = "red flower";
                break;
            default:
                break;
        }

        
    }


    public static void addToInv(GameObject thing)
    {
        for(int i = 0;i < pocketInv.Length; i++)
        {
            if (pocketInv[i] == null)
            {
                pocketInv[i] = thing;
                updateInvImage(thing, i);
                Debug.Log("selected : "+ i + pocketInv[i].name);
                return;
            }
        }
    }

    public static void updateInvImage(GameObject thing, int i)
    {
        Debug.Log("updating image for slot "+i+"for itme"+ thing.gameObject.name);
        switch (thing.gameObject.name)
        {
            case "":
                break;
            case "red flower cluster":
                items[i].enabled = true;
                items[i].sprite = red_flower_image;
                break;
            case "purple flower culster":
                items[i].enabled = true;
                items[i].sprite = purple_flower_image;
                break;
            case "TallMush2":
                items[i].enabled = true;
                items[i].sprite = mushroom_image;
                break;
            default:
                break;

        }
    }


}
