using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttondisable : MonoBehaviour{
    Button buttonToHide;

    void Start(){
        buttonToHide = GetComponent<Button>();

        buttonToHide.onClick.AddListener(() => HideButton());
    }

    void HideButton(){
        buttonToHide.gameObject.SetActive(false);
    }
}