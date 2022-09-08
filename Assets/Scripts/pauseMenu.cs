using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _keysMenu;
    public GameObject _playerStats;
    bool pauseMenuActive = false;
    public Text keysCollectedText;
    int keysCollected = 0;
    public List<Transform> playerHP;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu.SetActive(pauseMenuActive);
        if (gameBehaviour.levelHasKeys) { showKeys(); }
        foreach (Transform child in _playerStats.transform)
        {
            playerHP.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            pauseMenuActive = !pauseMenuActive;
            if (pauseMenuActive)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            _pauseMenu.SetActive(pauseMenuActive);
        }
        keysCollectedText.text = gameBehaviour.keysCollected.ToString();
        foreach (Transform child in playerHP)
        {
            if (!(playerHP.IndexOf(child) < playerBehaviour.playerHP))
            {
                child.gameObject.GetComponent<Image>().sprite = emptyHeart;
            }
            else { 
                child.gameObject.GetComponent<Image>().sprite = fullHeart;
            }
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void resumeGame()
    {
        pauseMenuActive = !pauseMenuActive;
        Time.timeScale = 1f;
        _pauseMenu.SetActive(pauseMenuActive);
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        applicationController.backgroundMusic = "mainMenu";
        SceneManager.LoadScene(0);
    }
    public void showKeys()
    {
        _keysMenu.SetActive(true);
    }
    public void changeKeysCollected()
    {
        keysCollected++;
        keysCollectedText.text = keysCollected.ToString();
    }
    
}
