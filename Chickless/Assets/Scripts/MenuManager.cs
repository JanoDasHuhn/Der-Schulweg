using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string nextScene = "1";


    public void onStart()
    {
        SceneManager.LoadScene(nextScene);
    }
}
