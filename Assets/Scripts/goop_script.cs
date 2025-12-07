using UnityEngine;
using System.Collections;

public class goop_script : MonoBehaviour
{
    public Material badMaterial;
    public Material goodMaterial;
    public static Material material;
    //public static bool healed;

    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //anim = GetComponent<Animator>();
        material = GetComponent<MeshRenderer>().material;

        gameObject.GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //Debug.Log("collison registered");

            if( Input.GetKeyDown(KeyCode.E)){
                StartCoroutine(heal( collider.gameObject));
                
            }
            
        }

        
    }

    IEnumerator heal(GameObject goop)
    {
        anim.SetBool("healing", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("healing", false);
        material = goodMaterial;
        gameObject.GetComponent <MeshRenderer>().material = goodMaterial;
        if(objective_manager_script.healed < 3)
        {
            objective_manager_script.healed++;
        }
    }
}
