using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeChange : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public void changeVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        applicationController.ChangeVolume();
    }
}
