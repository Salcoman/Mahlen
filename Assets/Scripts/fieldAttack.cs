using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldAttack : MonoBehaviour
{
    public List<Transform> gameObjectsFields;
    float windup = 3f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            gameObjectsFields.Add(child);
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attacked()
    {
        int x = Random.Range(0, 2);
        if (x != 0)
        {
            gameObjectsFields[3].gameObject.SetActive(true);
            gameObjectsFields[5].gameObject.SetActive(true);
            StartCoroutine(attackWindup1());
        }
        else
        {
            gameObjectsFields[4].gameObject.SetActive(true);
            StartCoroutine(attackWindup2());
        }
    }

    private IEnumerator attackWindup1()
    {
        yield return new WaitForSeconds(windup);
        gameObjectsFields[0].gameObject.SetActive(true);
        gameObjectsFields[2].gameObject.SetActive(true);
        StartCoroutine(transition());
    }
    private IEnumerator attackWindup2()
    {
        yield return new WaitForSeconds(windup);
        gameObjectsFields[1].gameObject.SetActive(true);
        StartCoroutine(transition());
    }

    private IEnumerator transition()
    {
        yield return new WaitForSeconds(2f);
        foreach (Transform child in gameObjectsFields)
        {
            child.gameObject.SetActive(false);
        }
        
    }
}
