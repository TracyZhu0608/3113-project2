using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject, 1.8f);
    }
    void OntriggerEnter(){
        Destroy(gameObject);
    }
}
