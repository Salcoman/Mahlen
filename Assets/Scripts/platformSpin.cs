using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpin : MonoBehaviour
{
    bool spin;
    Quaternion targetAngle = Quaternion.Euler(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            this.transform.parent.transform.rotation = Quaternion.Slerp(this.transform.parent.transform.rotation,targetAngle, 0.05f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            spin = true;
        }
    }
}
