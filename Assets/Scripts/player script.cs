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

    public Camera camera;

    private CharacterController controller;

    public Transform follow;
    public Vector3 follow_offset = new Vector3();


    private bool isNearForage = false;
    private bool foraging = false;

    private float pull = 0;


    private Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        controller = GetComponent<CharacterController>();

        follow_offset = tr.position - follow.position;

    }

    // Update is called once per frame
    void Update()
    {
        float h = UnityEngine.Input.GetAxis("Horizontal");
        float v = UnityEngine.Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0f, v).normalized;



        // get camera forward/right directions
        Vector3 camForward = camera.transform.forward;
        Vector3 camRight = camera.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // move relative to camera direction
        Vector3 moveDir = (camForward * v + camRight * h).normalized;

        follow.rotation = Quaternion.LookRotation(moveDir, tr.up);

        if (move.magnitude >= 0.1f)
        {
            anim.SetBool("walking", true);

            // rotate player for a,s,d
            //tr.rotation = Quaternion.LookRotation(move, Vector3.up);

            //controller.Move(move * speed * Time.deltaTime);
            //follow.position = tr.position - follow_offset;


            tr.rotation = Quaternion.LookRotation(moveDir, Vector3.up);

            // move player using CharacterController
            controller.Move(moveDir * speed * Time.deltaTime);
            follow.position += moveDir * speed * Time.deltaTime;

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
            if (UnityEngine.Input.GetKeyDown(KeyCode.F) && pull < 10)
            {
                pull += 2;
                Debug.Log("pull :" + pull);
            }
            else if (pull == 10)
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

        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "forage" && pull == 10)
        {
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
