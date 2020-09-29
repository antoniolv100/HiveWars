using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator PlayerAnim;
    public Button Shotbutton;
    // Update is called once per frame
    void Update()
    {
       //if(){
           //Shoot();
           //PlayerAnim.SetBool("Shoot",true);
       //}else{
          // PlayerAnim.SetBool("Shoot",false);
       //}
    }

    public void ShootBtn(){
        Shoot();
        PlayerAnim.SetBool("Shoot", true);
        Invoke("Turnbtnoff",.2f);
    }

    public void Turnbtnoff(){
        PlayerAnim.SetBool("Shoot", false);
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    
}
