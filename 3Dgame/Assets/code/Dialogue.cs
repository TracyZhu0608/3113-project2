using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EasyUI.Dialogs{
    public class Dialogue : MonoBehaviour{
        [SerializeField] GameObject canvas;
        [SerializeField] Text messageT;
        [SerializeField] Button button;

        Dia dia = new Dia ();

        public static Dialogue Instance;

        void Awake (){
            Instance = this;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(Hide);
        }

        public Dialogue setmessage (string message){
            dia.message = message;
            return Instance;
        }

        public void Show(){
            messageT.text = dia.message;
            

            canvas.SetActive (true);
        }

        public void Hide(){
            canvas.SetActive (false);

            dia = new Dia ();
        }
    }

    public class Dia{
            public string message = "message goes here";
    }

}