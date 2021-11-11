using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Root3 : MonoBehaviour
{
    public enum STATE {Idle, Moving, Combat, Following};
    public enum target {enemy, ai};
    [Header("State")]
    public STATE currentState;
    public TextMesh myStateText;
    [Header("Stats")]
    public target target1;
    public float hp = 50;
    public int def = 5;
    public int atk = 10;
    public int atkVar = 2;
    public float atkSpeed = 2.5f;
    public float reach = 20;
    public int attack_radius = 10;
    public GameObject explosion;
    public float explosion_size=2f;
    [Header("Detection")]
    public List<Root3> detected;

    [Header("Other")]
    //public GameObject gun;
    public Transform Fire_pos;
    public float bullet_force = 50f;
    public GameObject Bulletprefab; 
    private NavMeshAgent agent;
    private bool auto_destination = false;
    // Start is called before the first frame update
    void status(){
        if(this.tag == "ai"){
            //print(1);
            if(GameObject.FindWithTag("key")){
                if((gameObject.GetComponent("player") as player) == null){
                    if((System.Math.Abs(agent.destination.x - agent.nextPosition.x))<20f && (System.Math.Abs(agent.destination.z - agent.nextPosition.z)) <20f){
                        currentState = STATE.Idle;
                    }
                    else{
                        currentState = STATE.Moving;
                        agent.isStopped = false;
                    }
                }
                else{
                    if((System.Math.Abs(agent.destination.x - agent.nextPosition.x))<0.5f && (System.Math.Abs(agent.destination.z - agent.nextPosition.z)) <0.5f){
                        currentState = STATE.Idle;
                    }
                    else{
                        currentState = STATE.Moving;
                        agent.isStopped = false;
                    }
                }
            }
            else{
                if((System.Math.Abs(agent.destination.x - agent.nextPosition.x))<20f && (System.Math.Abs(agent.destination.z - agent.nextPosition.z)) <20f){
                    currentState = STATE.Idle;
                }
                else{
                    currentState = STATE.Moving;
                    agent.isStopped = false;
                }
            }
        }
    }
    public void DamageTaken(int damage){
        if((damage-def)>=0){
            hp = hp - (damage - def);
        }
        if(hp<=0&&((gameObject.GetComponent("player") as player) == null)){
            explosion.transform.localScale = Vector3.one * explosion_size;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            //explosion.Play();
            Destroy(gameObject);
        }
    }
    public void ChangeState(STATE state){
        currentState = state;
        if(myStateText != null) myStateText.text = state.ToString();
    }
    public void shoot(Transform enemy_pos){
        if(Bulletprefab==null){return;}
        GameObject newbullet = Instantiate(Bulletprefab, Fire_pos.position, Quaternion.identity);
        newbullet.GetComponent<Transform>().LookAt(enemy_pos);
		newbullet.GetComponent<Rigidbody>().AddForce((enemy_pos.position - Fire_pos.position)*bullet_force);
		//AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){
        status();
    }
    void OnTriggerEnter(Collider other){
        if (target1 == target.enemy){
            if(other.tag == "enemy"){
            detected.Add(other.GetComponent<Root3>());
            //print("add");
            }
        }
        else{
            if(other.tag == "ai"){
            detected.Add(other.GetComponent<Root3>());
            //print("add");
            }
        }
    }
    void OnTriggerExit(Collider other){
            detected.Remove(other.GetComponent<Root3>());
    }
}