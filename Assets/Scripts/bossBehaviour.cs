using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehaviour : MonoBehaviour
{
    public GameObject eye;
    public GameObject attackField;
    public GameObject enemyProjectile;
    int bossHP = 15;

    public Sprite bossPassiveSprite;
    public Sprite bossActiveSprite;
    public Sprite bossDeadSprite;
    public string bossName;

    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    public void reduceHP()
    {
        bossHP--;
        if (bossHP == 0) {
            died();
        }
    }

    public void isActive()
    {
        eye.SetActive(true);
        _spriteRenderer.sprite = bossActiveSprite;
    }
    public void isNotActive()
    {
        
        eye.SetActive(false);
        _spriteRenderer.sprite = bossPassiveSprite;
    }
    
    void died()
    {
        eye.SetActive(false);
        transform.parent.GetComponent<bossManager>().hasAttacked=false;
        _spriteRenderer.sprite = bossDeadSprite;
        transform.parent.GetComponent<bossManager>().getRidOfBoss();
        
    }

    public void fireBullet()
    {
        Transform spawn = attackField.transform;

        GameObject projectileInstance = Instantiate(enemyProjectile, spawn.transform.position, spawn.transform.rotation);
        projectileInstance.GetComponent<Rigidbody2D>().AddForce(-transform.right * 400f);
    }

    //private IEnumerator attack()
    //{
    //    hasAttacked = true;
    //    attackField.gameObject.GetComponent<fieldAttack>().attacked();
    //    Debug.LogError("lightning napad");
    //    yield return new WaitForSeconds(5f);
    //    hasAttacked = false;
    //}




}
