using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadPlayerLevel(int i)
    {
        SceneManager.LoadScene(i);
        applicationController.backgroundMusic = "levelBGM";
    }
}
