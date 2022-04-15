using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ZitatScript : MonoBehaviour
{
    public string[] zitate;
    public TMP_Text text;

    private void Start()
    {
        int number = Random.Range(0, zitate.Length);
        text.text = zitate[number];

     
    }
    public void GoBackToMainMénu()
    {
        SceneManager.LoadScene(0);
    }

    
}
