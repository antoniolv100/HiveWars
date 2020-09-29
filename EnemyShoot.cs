using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    public float cooldownTime = 5f;
    public bool StartShooting = false;
   
    public IEnumerator Shoot(){
        canShoot = false;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    public void Update() {
        if(StartShooting && canShoot){
            StartCoroutine("Shoot");
        }
    }

    public void SwitchLeft(){
        firePoint.Rotate(0f,0f,180f);
    }

    public void SwitchRight(){
        firePoint.Rotate(0f, 0f, 0f);
    }
}
