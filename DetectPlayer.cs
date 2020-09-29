using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool side = true;
    public EnemyShoot Swap;

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if(side){
            if (hitInfo.gameObject.tag == "Player")
            {
               Swap.SwitchRight();
            }
        }else{
            if (hitInfo.gameObject.tag == "Player")
            {
                Swap.SwitchLeft();
            }
        }
    }

}
