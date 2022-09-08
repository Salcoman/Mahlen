using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource gunshotSound, jumpSound, playerHurtSound, playerHealSound, mainMenuBGM, levelBGM;

    private void Start()
    {
        if (applicationController.backgroundMusic == "mainMenu")
        {
            mainMenuBGM.Play();
        }
        else
        {
            levelBGM.Play();
        }
        applicationController.LoadVolume();
    }

    public void playGunshotSound()
    {
        gunshotSound.Play();
    }
    public void playPlayerHurtSound()
    {
        playerHurtSound.Play();
    }
    public void playPlayerHealSound()
    {
        playerHealSound.Play();
    }
    public void playJumpSound()
    {
        jumpSound.Play();
    }
    public void playMenuBGM()
    {
        mainMenuBGM.Play();
    }

    public void playLevelBGM()
    {
        levelBGM.Play();
    }
}
