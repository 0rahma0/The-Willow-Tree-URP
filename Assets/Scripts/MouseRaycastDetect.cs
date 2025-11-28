using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseRaycastDetect : MonoBehaviour
{
    // this script works as mouse click detection and scene manager
    public Camera cam;
    public float rayDistance = 100f;

    // objects to be altered by scene manager
    public Animator scaleAnim;
    public Animator grindAnim;

    public GameObject powderPile;
    public GameObject creamContainer;

    private void Start()
    {
        // only appear when prev steps are done
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

                    // animate scales when clicked
                    case "scales":
                        Debug.Log("Clicked on scales");
                        StartCoroutine(playScaleAnim());
                        break;
                    // animate mortar and pestel when clicked on
                    case "grind":
                        Debug.Log("Clicked on mortar and pestel");
                        StartCoroutine (playGrindAnim());
                        break;
                    // remove powder and show remedy container
                    case "potions":
                        Debug.Log("Clicked on potions");
                        powderPile.SetActive(false);
                        creamContainer.SetActive(true);
                        break;
                    // pick up remedy container
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
                    // spawn selected item from inventory on palnt paper to use as ingredient
                    GameObject tmp = playerscript.selectedItem;
                    GameObject obj = Instantiate(tmp, new Vector3(-6.8f, 1.56f, -6.4f), Quaternion.identity);
                    obj.SetActive(true);
                    obj.GetComponent<BoxCollider>().enabled = false;
                    // scale down item when on paper (original scale is too big)
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
        // show grinded powder after grinding is done
        powderPile.SetActive(true);
    }
}
