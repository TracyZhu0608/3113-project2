using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radar_rotate : MonoBehaviour
{
    public string way;
    // Update is called once per frame
    public GameObject player;
    public float distance = 5.5f;
    public bool rotate = false;
    public GameObject icon;
    void Update()
    {
        float dist1 = Vector3.Distance(transform.position, player.transform.position);
        //print(dist1);
        if (dist1 <= distance)
        {
            rotate = true;
            //icon.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (rotate)
        {
            if (way == "x") { transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime); }
            if (way == "z") { transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); }
            if (way == "y") { transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime); }
        }

    }
}
