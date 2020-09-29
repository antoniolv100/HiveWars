using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP = 100;
    public int DamageMulti;

    public void SubHp(){
        HP -= (20* DamageMulti);
    }

    void Update() {
        if(HP < 0){
            Destroy(gameObject);
        }
    }
}
