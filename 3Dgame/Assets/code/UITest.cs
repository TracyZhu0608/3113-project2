using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    private Queue<string> sentences;

    public Text messageT;

    public Animator animator;

    public GameObject mission;
    public AudioSource assignment;
    public AudioSource yes;


    void Start()
    {
        sentences = new Queue<string>();
        mission.SetActive(false);
    }

    public void Start(allDia dialogue){
        animator.SetBool("isopen", true);

        //sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }



    }

    public void Next(){
        if (sentences.Count == 0){
            End();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Type(sentence));
        yes.Play();

    }

    IEnumerator Type (string sentence){
        messageT.text = "";
        foreach (char letter in sentence.ToCharArray()){
            messageT.text += letter;
            yield return null;
        }
    }

    public void End(){
        animator.SetBool("isopen", false);
        mission.SetActive(true);
        assignment.Play();
        Debug.Log("end");
    }
    
}
