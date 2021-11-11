using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public Root3 myRoot;
    public Animator animator;
    public NavMeshAgent myAgent;
    //public Camera _camera;
    //static Vector3 a=GameObject.transform;
    //public float animationTime=32f;
    // Update is called once per frame
    void Update()
    {   
        //a=GameObject.transform;
        //myAgent.enabled=true;
        if(myRoot.currentState != Root3.STATE.Idle){
            animator.SetBool("isIdle",false);
            animator.SetBool("shooting",true);
        }
        else{
            animator.SetBool("isIdle",true);
            animator.SetBool("shooting",false);
        }
        if(myRoot.hp<=0){
            //a=GameObject.transform;
            //_camera.transform.LookAt(a);
            animator.SetBool("die",true); 
            StartCoroutine(Die());
        }

    }
    private IEnumerator Die()
    {
    // Play the animation for getting suck in

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    // Move this object somewhere off the screen

    }
}
