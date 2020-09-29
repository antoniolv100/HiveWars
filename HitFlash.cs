using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    public SpriteRenderer playerRender;
    public float FlashSpeed;

    IEnumerator flash()
    {
        playerRender.color = Color.red;
        yield return new WaitForSeconds(FlashSpeed);
        playerRender.color = Color.white;
    }

    public void CallFlash(){
        StartCoroutine(flash());
    }
}
