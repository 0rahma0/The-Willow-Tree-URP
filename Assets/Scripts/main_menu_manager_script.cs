using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_manager_script : MonoBehaviour
{
    public Canvas loadingScreen;
    private Canvas menu;
    public Canvas controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loadingScreen.enabled = false;
        menu = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_game()
    {
        StartCoroutine(loadStart());
    }

    IEnumerator loadStart()
    {
        loadingScreen.enabled=true;
        menu.enabled = false;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("village");
        loadingScreen.enabled=false;
    }

    public void showControls()
    {
        controls.enabled = true;
    }

    public void hideControls()
    {
        controls.enabled = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
