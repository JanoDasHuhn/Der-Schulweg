using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public int healAmount = 1;
    public float timeBeforeCollectable = 0.5f;
    private bool _isCollectable = false;
    public AudioSource audioClip;

    void Start()
    {
        StartCoroutine(SetCollectable(timeBeforeCollectable));
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _isCollectable)
        {
            PlayerHealthController.instance.HealPlayer(healAmount);
            audioClip.Play();
            Destroy(gameObject);
        }
    }

    private IEnumerator SetCollectable(float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);
        _isCollectable = true;
    }
}
