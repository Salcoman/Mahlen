using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehaviour : MonoBehaviour
{
    
    public void projectileDirection(float direction)
    {
        float x = transform.localScale.x;

        if (direction < 0)
        {
            x = -1 * Mathf.Abs(x);
        }
        else
        {
            x = Mathf.Abs(x);
        }
        Vector3 newDirection = new Vector3(x, transform.localScale.y, transform.localScale.z);
        transform.localScale = newDirection;
    }
    public void projectileSpeed(float direction, float projectileSpeed)
    {
        if (direction < 0)
        {
            this.GetComponent<Rigidbody2D>().AddRelativeForce(-transform.right * projectileSpeed);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddRelativeForce(transform.right * projectileSpeed);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BossEye")
        {
            collision.transform.parent.GetComponent<bossBehaviour>().reduceHP();
            
        }
        Destroy(this.gameObject);
    }

    

}
