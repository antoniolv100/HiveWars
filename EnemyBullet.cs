using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Animator BulletGFX;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            hitInfo.gameObject.GetComponent<PlayerHealth>().SubHp();
            rb.velocity = Vector3.zero;
            BulletGFX.SetBool("Impact", true);
            Invoke("DestoryObj", .2f);
        }
        if (hitInfo.gameObject.tag == "Wall")
        {
            rb.velocity = Vector3.zero;
            BulletGFX.SetBool("Impact", true);
            Invoke("DestoryObj", .2f);
        }
    }

    void DestoryObj()
    {
        Destroy(gameObject);
    }

}
