using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class applicationController : MonoBehaviour
{
    public static string backgroundMusic = "mainMenu";

    public static void ChangeVolume()
    {

        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        
    }

    public static void LoadVolume()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            ChangeVolume();
        }
    }
}
