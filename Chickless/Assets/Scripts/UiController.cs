using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    public static UiController instance;
    public Slider healthSlider;
    public Text healthText;

    public GameObject deathScreen;

    public Image fadeScreen;

    public float fadeSpeed;

    private bool fadeToBlack, fadeOutBlack;
    public Text quest;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        fadeOutBlack = true;
        fadeToBlack = false;

        StartUI();
    }

   
    void Update()
    {
        if (fadeOutBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a,0f,fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 0f)
            {
                fadeOutBlack = false;
            }
        }
        if (fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

    }
    public void StartFadeOutToBlack()
    {
        fadeToBlack = true;
        fadeOutBlack = false;
        

    }
    public void StartUI()
    {
        quest.gameObject.SetActive(true);
        StartCoroutine(UICoroutine());
    }

    private IEnumerator UICoroutine()
    {
        yield return new WaitForSeconds(2);
        quest.gameObject.SetActive(false);
        quest.text = "";
    }
}
