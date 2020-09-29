using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePlayer : MonoBehaviour
{
    public Transform target;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(
           target.position.x - transform.position.x,
           target.position.y - transform.position.y
        );
        transform.up = direction;
    }
}
