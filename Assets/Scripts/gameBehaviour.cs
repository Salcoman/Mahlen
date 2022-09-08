using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameBehaviour : MonoBehaviour
{
    public static bool levelHasKeys;
    public bool keysOn;
    public static int keysCollected;
    public Sprite doorOpen;
    public GameObject boss;

    private audioManager _audioManager;

    public GameObject spawnableHeartPrefab;
    public GameObject spawnLocations;
    public List<Transform> spawnLocation;
    void Start()
    {
        keysCollected = 0;
        SceneManager.LoadScene("HUDv2", LoadSceneMode.Additive);
        levelHasKeys = keysOn;

        foreach (Transform child in spawnLocations.transform)
        {
            spawnLocation.Add(child);
        }


        _audioManager = FindObjectOfType<audioManager>().GetComponent<audioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keysCollected == 3)
        {
            GameObject.Find("Gate").GetComponent<SpriteRenderer>().sprite = doorOpen;
            GameObject.Find("Gate").GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void restartLevel()
    {   
        Scene scena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scena.buildIndex);
    }
    public void nextLevel()
    {
        Scene scena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scena.buildIndex + 1);
    }
    public void nextLevel(int i)
    {
        if (i == 0)
        {
            applicationController.backgroundMusic = "mainMenu";
        }
        SceneManager.LoadScene(i);
    }

    public void startFight()
    {
        boss.SetActive(true);
        FindObjectOfType<Camera>().GetComponent<Camera>().orthographicSize = 15;
    }

    public void spawnHeart()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(spawnLocation.Count);
        Instantiate(spawnableHeartPrefab, spawnLocation[index].transform.position, spawnLocation[index].transform.rotation); ;
    }
}
