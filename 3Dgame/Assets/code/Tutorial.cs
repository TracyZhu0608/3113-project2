using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;


    void Start()
    {
        txt1.SetActive(false);
        txt2.SetActive(false);
        txt3.SetActive(false);

    }

   private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Tutorial")){
            Destroy(other.gameObject);

            if (txt1.activeSelf){
                txt2.SetActive(true);
                txt1.SetActive(false);                
            } else if (txt2.activeSelf){
                txt3.SetActive(true);
                txt2.SetActive(false);
            }
         }

    }
}