using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject, 2.5f);
    }
    void OntriggerEnter(){
        Destroy(gameObject);
    }
}
