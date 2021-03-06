using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToLoad = 4f;

    public string nextLevel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LevelEnd()
    {
        AudioManager.instance.PlayLevelWin();
        PlayerController.instance.canMove = false;

        UiController.instance.StartFadeOutToBlack();

        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(nextLevel);
    }
}
