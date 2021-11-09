using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool canPlay = true;
    public static AudioManager instance;
    public AudioSource levelmusic, gameOverMusic, WinMusic;
    public AudioSource[] sfx;
    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void PlayGameOver()
    {
        levelmusic.Stop();
        gameOverMusic.Play();

    }
    public void PlayLevelWin()
    {
        levelmusic.Stop();
        WinMusic.Play();
    }
    public void PlaySFX(int sfxToPlay)
    {

        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();

    }
}
