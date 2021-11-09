using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public int maxHealth;

    public float damageInvinceLenght = 1f;
    private float invinceCount;

    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        MakeUI(3f);
        //UiController.instance.healthSlider.maxValue = maxHealth;
        //UiController.instance.healthSlider.value = currentHealth;
        //UiController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        /*UiController.instance.healthSlider.maxValue   maxValue = maxHealth;
        */

    }

    // Update is called once per frame
    void Update()
    {
        if( invinceCount > 0)
        {
            invinceCount -= Time.deltaTime;
            if(invinceCount <= 0){
                PlayerController.instance.skinSR.color = new Color(PlayerController.instance.skinSR.color.r, PlayerController.instance.skinSR.color.g, PlayerController.instance.skinSR.color.b, 1f);
            }
        }
    }
    public void DamagePlayer()
    {
        AudioManager.instance.PlaySFX(2 );
        if (invinceCount <= 0)
        {
            invinceCount = damageInvinceLenght;
            PlayerController.instance.skinSR.color = new Color(PlayerController.instance.skinSR.color.r, PlayerController.instance.skinSR.color.g, PlayerController.instance.skinSR.color.b, .5f);

            currentHealth--;
            if (currentHealth <= 0)
            {
                PlayerController.instance.gameObject.SetActive(false);
                UiController.instance.deathScreen.SetActive(true);
                AudioManager.instance.PlayGameOver();
            }
            UiController.instance.healthSlider.value = currentHealth;
            UiController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }
    public void MakeInvicible(float length)
    {
        invinceCount = length;
        PlayerController.instance.skinSR.color = new Color(PlayerController.instance.skinSR.color.r, PlayerController.instance.skinSR.color.g, PlayerController.instance.skinSR.color.b, .5f);
    }
    public void HealPlayer(int healAmount)
    {

        currentHealth += healAmount;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        UiController.instance.healthSlider.value = currentHealth;
        UiController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
    private IEnumerator MakeUI(float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);
        UiController.instance.healthSlider.value = currentHealth;
        UiController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
