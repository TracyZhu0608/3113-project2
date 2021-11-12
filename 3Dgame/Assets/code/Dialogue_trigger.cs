using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_trigger : MonoBehaviour
{
    public allDia dialogue;
    public AudioSource commander; 
    public UITest talk;
    public GameObject tutorial;
    public GameObject oldmission;
    public void OnTriggerEnter(Collider other){
        if(other.GetComponent("player") as player!=null){
            talk.Start(dialogue);
            commander.Play();
            tutorial.SetActive(true);
            oldmission.SetActive(false);
        }
    }
}
