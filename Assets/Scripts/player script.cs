using System;
using System.Collections;
using TMPro;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class playerscript : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private Rigidbody rb;
    private Transform tr;

    // player movement
    public Camera cameraObj;
    private CharacterController controller;

    // foraging
    private bool isNearForage = false;
    private bool foraging = false;
    private int pull = 0;
    private int pullGoal = 20;

    //inventory system
    public static int invSize = 4;
    public string[] inventory = new string[invSize];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();

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

        if (isNearForage)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                foraging = true;
                StartCoroutine(start_forage());
            }
        }

        if (foraging)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.F) && pull < pullGoal)
            {
                pull += 2;
                Debug.Log("pull :" + pull);
            }
            else if (pull == pullGoal)
            {
                Debug.Log("pulled");
                pull = 0;
                anim.SetBool("foraging", false);
                StartCoroutine(end_forage());
                foraging = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "forage")
        {
            isNearForage = true;
            Debug.Log(collider.gameObject.name);

        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "forage" && pull == pullGoal)
        {
            updateInv(collider.gameObject.name);
            Debug.Log(collider.gameObject.name);
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "forage")
        {
            isNearForage = false;
        }
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

        if (!(inventory[inventory.Length - 1].Equals("") || inventory[inventory.Length - 1].Equals(null)))
        {
            Debug.Log("inventory full");
            return;
        }
        for (int i = 0; i < inventory.Length;  i++)
        {
            if (inventory[i].Equals("") || inventory[i].Equals(null))
            {
                inventory[i] = itemName;
                Debug.Log(inventory);
                return;
            }
        }
    }
    IEnumerator forage()
    {
        Debug.Log("foraging");
        anim.SetBool("foraging", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("foraging", false);
    }

    IEnumerator start_forage()
    {
        Debug.Log("starting foraging");
        anim.SetBool("startForage", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        anim.SetBool("startForage", false);
        anim.SetBool("foraging", true);
    }

    IEnumerator end_forage()
    {
        Debug.Log("stopped foraging");
        anim.SetBool("finishForage", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        anim.SetBool("finishForage", false);
    }

    public Vector3 MousePosition()
    {
        Vector3 mousePos = UnityEngine.Input.mousePosition;
        mousePos.z = 10f; // distance from camera
        return Camera.main.ScreenToWorldPoint(mousePos);
    }


}
