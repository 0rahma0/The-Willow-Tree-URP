using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class playerscript : MonoBehaviour
{
    public float speed;
    public float walkFactor;
    private Animator anim;
    private Rigidbody rb;
    private Transform tr;
    public Text forageText;


    private bool isNearForage = false;

    private Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        forageText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0f, v).normalized;       

        if (move.magnitude > 0)
        {
            anim.SetBool("walking", true);
            transform.rotation = Quaternion.LookRotation(move);
            tr.Translate(Vector3.forward * speed  * Time.deltaTime);

        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (isNearForage)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(forage());
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



}
