using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundcontroller : MonoBehaviour
{
    public AudioSource fight;
    public AudioSource inprogress;

    // Update is called once per frame
    void Start(){
        inprogress.Play();
        fight.Stop();
    }
    void Update()
    {
        //print(GameObject.FindWithTag("bullet"));
        if(GameObject.FindWithTag("bullet")&&!fight.isPlaying){
            //print("true");
            fight.volume=1;
            inprogress.Pause();
            fight.Play();
        }
        if(!GameObject.FindWithTag("bullet")&&!inprogress.isPlaying){
            StartCoroutine(Wait());
        }
 
    }
    private IEnumerator Wait()
    {
    // Play the animation for getting suck in
        fight.volume-=(Time.deltaTime/3);
        if(GameObject.FindWithTag("bullet")){yield break;}
        yield return new WaitForSeconds(8);
        inprogress.UnPause();
        fight.Stop();
    // Move this object somewhere off the screen

    }
}
