using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMethod : MonoBehaviour
{
    public Health hp;
    public void sub(){
        hp.SubHp();
    }
}
