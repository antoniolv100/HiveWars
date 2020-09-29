using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ai : MonoBehaviour
{
    public Transform target;
    public Transform EnemyGFX;
    public Animator EnemyAnim;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;

    public int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public bool ShootingUnit = false;
    public EnemyShoot shoot;

    public void SwitchTarget(Transform x){
        target = x;
    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            target = hitInfo.gameObject.transform;
            EnemyAnim.SetBool("Move", true);
            if(ShootingUnit){
                shoot.StartShooting = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player")
        {
            target = gameObject.transform;
            EnemyAnim.SetBool("Move", false);
            if (ShootingUnit)
            {
                shoot.StartShooting = false;
            }
        }
    }
    

    void Start(){
        target = gameObject.transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath",0f,.5f);
    }

    void UpdatePath() {
        if(seeker.IsDone()){
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    

    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update() {

        if(path == null){
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position,path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance){
            currentWaypoint++;
        }

        if(rb.velocity.x >= .01f){
            EnemyGFX.localScale = new Vector3(-1f,1f,1f);
        } else if (rb.velocity.x <= -.01f){
            EnemyGFX.localScale = new Vector3 (1f,1f,1f);
        }
    
    }
}
