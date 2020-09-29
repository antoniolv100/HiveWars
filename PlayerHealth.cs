using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float health = 100;
    public ProgressBar Pb;
    public Animator PlayerAnim;
    public HitFlash playerHit;
    public bool Dead = false;

    public void SubHp () {
        health -= 10;
        playerHit.CallFlash();
    }

    public void AddHp () {
        health += 10;
    }

    void Update() {
        Pb.BarValue = health;
        if(health < 1){
            Dead = true;
            PlayerAnim.SetBool("Dead",true);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if(hitInfo.gameObject.tag == "DeathZone"){
            health = 0;
            Dead = true;
        }
    } 
}