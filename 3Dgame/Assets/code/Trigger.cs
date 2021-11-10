using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public allDia dialogue;
    public AudioSource commander; 

    public void TriggerDialogue(){
        FindObjectOfType<UITest>().Start(dialogue);
        commander.Play();
    }
    
}
