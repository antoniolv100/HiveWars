using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSwitching : MonoBehaviour
{
    public Transform WayPoint;
    public Transform WayPoint2;
    public Ai ai;
    public bool Should_Wonder = true;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "WayPoint" && Should_Wonder)
        {
            if(ai.target == WayPoint){
                ai.SwitchTarget(WayPoint2);
            }else{
                ai.SwitchTarget(WayPoint);
            }
            
        }
    }
}
