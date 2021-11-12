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
    public GameObject button;
    public GameObject fight;
    public GameObject inprogress;

    void Start()
    {
        sentences = new Queue<string>();
        mission.SetActive(false);
        assignment.Stop();
        yes.Stop();
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
        //button.SetActive(true);
        yes.Play();

    }

    public void NextandButton(){
        if (sentences.Count == 0){
            End();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Type(sentence));
        button.SetActive(true);
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
        fight.SetActive(true);
        inprogress.SetActive(true);
        mission.SetActive(true);
        assignment.Play();
        //Debug.Log("end");
    }
    
}
