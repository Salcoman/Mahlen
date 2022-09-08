using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class bossManager : MonoBehaviour
{
    bossBehaviour[] _bossBehaviour;
    bossBehaviour activeBoss;
    gameBehaviour _gameBehaviour;
    float activeTime = 10f;
    int previousActiveBoss;
    bool bossPhase = false;
    public bool hasAttacked;
    void Start()
    {
        _bossBehaviour = GetComponentsInChildren<bossBehaviour>();
         _gameBehaviour = FindObjectOfType<gameBehaviour>().GetComponent<gameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossPhase) { 
            System.Random rnd = new System.Random();
            int index = rnd.Next(_bossBehaviour.Length);
            if (index != previousActiveBoss || _bossBehaviour.Length==1)
            {
                previousActiveBoss = index;
                activeBoss = _bossBehaviour[index];
                StartCoroutine(activeCooldown(activeTime));

            }
        }
        if(bossPhase && !hasAttacked)
        {
            StartCoroutine(projectileAttack());
            activeBoss.GetComponent<bossBehaviour>().fireBullet();
        }
        if (_bossBehaviour.Length == 0)
        {
            _gameBehaviour.nextLevel(0);
        }
    }

    public void getRidOfBoss()
    {
        _bossBehaviour = _bossBehaviour.Where(e=>e != activeBoss).ToArray();
        StopAllCoroutines();
        bossPhase = false;
        _gameBehaviour.spawnHeart();
    }

    private IEnumerator activeCooldown(float cooldownTime)
    {
        bossPhase = true;
        activeBoss.GetComponent<bossBehaviour>().isActive();
        yield return new WaitForSeconds(cooldownTime);
        activeBoss.GetComponent<bossBehaviour>().isNotActive();
        bossPhase = false;
    }

    private IEnumerator projectileAttack()
    {
        hasAttacked = true;
        
        yield return new WaitForSeconds(5f);
        hasAttacked = false;
    }
}
