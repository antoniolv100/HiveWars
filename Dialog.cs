using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public float nextSentenceSpeed;

    void Start() {
        StartCoroutine(type());
    }

    IEnumerator type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        Invoke("nextSentence",nextSentenceSpeed);
    }

    public void nextSentence(){
        if(index < sentences.Length -1){
            index++;
            textDisplay.text = "";
            StartCoroutine(type());
        }else{
            textDisplay.text = "";
        }
    }

}
