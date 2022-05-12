using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string nextScene = "1";
    public GameObject creditsMenu;
    public GameObject startMenu;

    public void onStart()
    {
        SceneManager.LoadScene(nextScene);
        Zeugnisse.zeugnisse = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void onCredits() {
        clearMenus();
        creditsMenu.SetActive(true);


    }
    public void onBack()
    {
        clearMenus();
        startMenu.SetActive(true);
            
    }
    public void clearMenus()
    {
        creditsMenu.SetActive(false);
        startMenu.SetActive(false);
    }
}
