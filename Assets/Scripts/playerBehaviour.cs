using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    public float playerSpeed = 7.0f;
    public float jumpPower = 12.0f;
    public float projectileSpeed = 100f;
    public static int playerHP = 3;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    private float horizontalInput;
    private Rigidbody2D _rb;
    private Animator _animator;
    private gameBehaviour _gameBehaviour;
    private audioManager _audioManager;
    bool invurnable;
    private void Start()
    {
         playerHP = 3;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _gameBehaviour = FindObjectOfType<gameBehaviour>().GetComponent<gameBehaviour>();
        _audioManager = FindObjectOfType<audioManager>().GetComponent<audioManager>();
    }
    private void Update()
    {
        movePlayer();

        if (Input.GetKeyDown("space") && isGrounded())
            Jump();

        if (Input.GetMouseButtonDown(0))
        {
            fireBullet();
        }
    }
    private void movePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * playerSpeed, _rb.velocity.y);
        if (horizontalInput != 0) { changeDirection(horizontalInput); }
        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (_rb.velocity.y != 0)
        {
            _animator.SetBool("IsJumping", true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
        }
    }
    private void Jump()
    {
        _rb.velocity = new Vector2(0, jumpPower);
        _audioManager.playJumpSound();
    }

    private void fireBullet()
    {
        Transform spawn = GameObject.Find("projectileSpawn").transform;
        
        GameObject projectileInstance = Instantiate(bulletPrefab, spawn.transform.position, spawn.transform.rotation);
        
        projectileInstance.GetComponent<projectileBehaviour>().projectileDirection(transform.localScale.x);
        projectileInstance.GetComponent<projectileBehaviour>().projectileSpeed(transform.localScale.x,projectileSpeed);

        _audioManager.playGunshotSound();
    }

    private void changeDirection(float direction)
    {
        float x = transform.localScale.x;
       
        if (direction < 0) {
            x = -1 * Mathf.Abs(x);
        }
        else
        {
            x = Mathf.Abs(x);
        }
        Vector3 newDirection = new Vector3(x, transform.localScale.y, transform.localScale.z);
        transform.localScale = newDirection;
    }

    private bool isGrounded()
    {
        
        LayerMask mask = LayerMask.GetMask("Platform");
        if(Physics2D.Raycast(transform.position,Vector2.down, 1.6f, mask))
        {
            
            return true;
        }
        
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            _gameBehaviour.restartLevel();
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gameBehaviour.keysCollected++;
        }
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            _gameBehaviour.startFight();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("HurtBox"))
        {
            if (!invurnable)
            {
                Destroy(collision.gameObject);
                StartCoroutine(isHurt(1.5f));
            }
            
        }
        if (collision.gameObject.CompareTag("HeartPickup"))
        {
            
            Destroy(collision.gameObject);
            _audioManager.playPlayerHealSound();
            if (playerHP < 3)
            {
                playerHP++;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            _gameBehaviour.nextLevel();
        }
    }

    private IEnumerator isHurt(float period)
    {
        invurnable = true;
        _audioManager.playPlayerHurtSound();
        _animator.SetTrigger("Hurt");
        knockBack();
        playerHP--;
        if (playerHP == 0)
        {
            _gameBehaviour.restartLevel();
        }
        yield return new WaitForSeconds(period);
        invurnable = false;
    }

    void knockBack()
    {
        float x = transform.localScale.x;

        if (x > 0)
        {
            _rb.AddRelativeForce(Vector2.right * -2000f);
        }
        else
        {
            _rb.AddRelativeForce(Vector2.right * 2000f);
        }
    }
}
