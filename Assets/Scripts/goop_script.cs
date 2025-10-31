using UnityEngine;
using System.Collections;

public class goop_script : MonoBehaviour
{
    public Material badMaterial;
    public Material goodMaterial;

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "goop")
        {
            //Debug.Log("collison registered");

            if( UnityEngine.Input.GetKeyDown(KeyCode.E)){
                StartCoroutine(heal( collider.gameObject));
                
            }
            
        }

        
    }

    IEnumerator heal(GameObject goop)
    {
        anim.SetBool("healing", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("healing", false);
        goop.GetComponent<MeshRenderer>().material = goodMaterial;
    }
}
