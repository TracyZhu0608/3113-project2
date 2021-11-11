using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UnitController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    public void MoveUnit(Vector3 dest)
    {
        if(this!=null){
            navAgent.destination = dest;
        }
    }

    public void SetSelected(bool isSelected)
    {
        //TODO: 被选中底下有光
        if(this!=null){
            transform.Find("highlight").gameObject.SetActive(isSelected);
        }
        //print(1);
    }
}
