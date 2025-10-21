using UnityEngine;
using UnityEngine.UI;

public class foragableplantscript : MonoBehaviour
{
    public Text forage;
    public bool textenabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            forage.enabled = true;
            textenabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if( other.gameObject.tag == "Player")
        {
            forage.enabled = false;
            textenabled = false;
        }
    }
}
