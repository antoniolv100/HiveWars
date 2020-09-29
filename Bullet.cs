using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Animator BulletGFX;

    void Start() {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Enemy")
        { 
            hitInfo.gameObject.GetComponent<callMethod>().sub();
            rb.velocity = Vector3.zero;
            BulletGFX.SetBool("Impact",true);
            Invoke("DestoryObj", .2f);
        }
        if (hitInfo.gameObject.tag == "Wall")
        {
            rb.velocity = Vector3.zero;
            BulletGFX.SetBool("Impact", true);
            Invoke("DestoryObj", .2f);
        }
    }

    void DestoryObj(){
        Destroy(gameObject);
    }
}
