using System.Collections;
using UnityEngine;

public class MouseRaycastDetect : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 100f;

    public Animator scaleAnim;
    public Animator grindAnim;

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

                    default:
                        Debug.Log("Clicked on something else: " + hit.collider.tag);
                        break;
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
    }
}
