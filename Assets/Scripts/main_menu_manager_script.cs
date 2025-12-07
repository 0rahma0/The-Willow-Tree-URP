using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_manager_script : MonoBehaviour
{
    // nmenu , controls, and loading screen
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
    // to attatch to start button to start game
    IEnumerator loadStart()
    {
        loadingScreen.enabled=true;
        menu.enabled = false;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("village");
        loadingScreen.enabled=false;
    }
    // to attach to controls button to show controls
    public void showControls()
    {
        controls.enabled = true;
    }
    // to attach to back button in control cnavas to go back to menu
    public void hideControls()
    {
        controls.enabled = false;
    }

    // to attartch to quit button to quit game
    public void Quit()
    {
        Application.Quit();
    }
}
