using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public allDia dialogue;
    public AudioSource commander; 
    public UITest talk;

    void Start(){
        commander.Stop();
    }
    public void TriggerDialogue(){
        //FindObjectOfType<UITest>().Start(dialogue);
        talk.Start(dialogue);
        commander.Play();
    }
    
}
