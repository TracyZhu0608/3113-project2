using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    public Root3 Base;
    public GameObject explosion;
    public float explosion_size=10f;
    void Update(){
        //print(this.gameObject==null);
        if(Base.hp<=0){
            //explosion.transform.localScale = Vector3.one * explosion_size;
            //Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            StartCoroutine(Wait());
            //explosion.Play();
            //Destroy(gameObject);
        }
    }

    private IEnumerator Wait()
    {
    // Play the animation for getting suck in
        print("true");
        explosion.transform.localScale = Vector3.one * explosion_size;
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2); 
        Time.timeScale=0.5f;
        yield return new WaitForSeconds(0.5f);
        //Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    // Move this object somewhere off the screen
    }

}
