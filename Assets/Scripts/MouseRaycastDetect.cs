using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseRaycastDetect : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 100f;

    public Animator scaleAnim;
    public Animator grindAnim;

    public GameObject powderPile;
    public GameObject creamContainer;

    private void Start()
    {
        powderPile.SetActive(false);
        creamContainer.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left-click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                switch (hit.collider.tag)
                {
                    case "forage":
                        Debug.Log("Clicked on"+ hit.collider.gameObject.name);
                        ingredients_shelf_script.updateCount(hit.collider.gameObject);
                        break;

                    case "scales":
                        Debug.Log("Clicked on scales");
                        StartCoroutine(playScaleAnim());
                        break;

                    case "grind":
                        Debug.Log("Clicked on mortar and pestel");
                        StartCoroutine (playGrindAnim());
                        break;
                    case "potions":
                        Debug.Log("Clicked on potions");
                        powderPile.SetActive(false);
                        creamContainer.SetActive(true);
                        break;
                    case "remedy":
                        Debug.Log("Clicked on remedy");
                        creamContainer.SetActive(false);
                        playerscript.addToInv(hit.collider.gameObject);
                        break;
                    default:
                        Debug.Log("Clicked on something else: " + hit.collider.tag);
                        break;
                }

                if (hit.collider.tag == "plantPaper" )
                {
                    GameObject tmp = playerscript.selectedItem;
                    GameObject obj = Instantiate(tmp, new Vector3(-6.8f, 1.56f, -6.4f), Quaternion.identity);
                    obj.SetActive(true);
                    obj.GetComponent<BoxCollider>().enabled = false;
                    obj.transform.localScale = new Vector3(tmp.transform.localScale.x / 2,
                                                           tmp.transform.localScale.y / 2,
                                                           tmp.transform.localScale.z / 2);
                }
            }
        }
    }

    IEnumerator playScaleAnim()
    {
        scaleAnim.SetBool("scaling",true);
        yield return new WaitForSeconds(3);
        scaleAnim.SetBool("scaling", false);
    }

    IEnumerator playGrindAnim()
    {
        grindAnim.SetBool("grinding", true);
        yield return new WaitForSeconds(3);
        grindAnim.SetBool("grinding", false);
        powderPile.SetActive(true);
    }
}
