using System.Collections;
using UnityEngine;

public class Foragingscript : MonoBehaviour
{
    // foraging
    private bool isNearForage = false;
    private bool foraging = false;
    private int pull = 0;
    private int pullGoal = 8;

    public static string[] foraged_plants = new string[100];

    //player anim
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize player components, this script is added to the player in scenes where he can forage
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            //updateInv(collider.gameObject.name);
            Debug.Log(collider.gameObject.name);

            string cutName = "";

            if (collider.gameObject.name.EndsWith((")")))
            {
                cutName = collider.gameObject.name.Substring(0, collider.gameObject.name.Length - 4);
                Debug.Log(cutName);
            }

            pull = 0;
            Destroy(collider.gameObject);

            for (int i = 0; i < foraged_plants.Length; i++)
            {
                if (foraged_plants[i] == null)
                {
                    foraged_plants[i] = cutName;
                    Debug.Log(foraged_plants[i]);
                    break;
                }
            }

        }

        //if (collider.gameObject.tag == "goop" && UnityEngine.Input.GetKeyDown(KeyCode.E))
        //{
        //    StartCoroutine(heal());
        //}

    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "forage")
        {
            isNearForage = false;
        }
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

}


