using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackUpdated : MonoBehaviour
{

    private NavMeshAgent nav;
    

    public Transform Player;
    private NavMeshHit hit;
    private bool blocked = false;
    public Collider Col;
    //private bool CheckForPlayer = false;
    //public GameObject chasemusic;

    [SerializeField] float ChaseSpeed = 10.5f;
    [SerializeField] float WalkSpeed = 1.5f;

    //private bool TimedCheckActive = false;
    private Animator anim;
    public float distancetoplayer;
    private bool runtoplayer;
    public float AttackDistance = 2.3f;
    public float AttackRotateSpeed = 2.0f;
    

    public GameObject Enemy;



    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (runtoplayer == true)
        {
            nav.speed = ChaseSpeed;
            distancetoplayer = Vector3.Distance(Player.position, transform.position);
            Enemy.GetComponent<EnemyMoveUpdated>().enabled = false;
            if (distancetoplayer > AttackDistance)
            {
                nav.SetDestination(Player.position);
                nav.isStopped = false;





                Debug.Log("I AM RUNNING");
                anim.SetInteger("State", 2);





            }
            else if (distancetoplayer < AttackDistance)
            {
                nav.isStopped = true;
                //chasemusic.gameObject.SetActive(false);

                Vector3 Pos = (Player.transform.position - transform.position).normalized;
                Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, PosRotation, Time.deltaTime * AttackRotateSpeed);






                Debug.Log("Hit Him");
                anim.SetInteger("State", 3);



            }


        }

        else if (runtoplayer == false)
        {
            Enemy.GetComponent<EnemyMoveUpdated>().enabled = true;
            nav.speed = WalkSpeed;
            anim.SetInteger("State", 0);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
                //CheckForPlayer = true;
                StartCoroutine(Checking());
                Col.enabled = false;
            
        }
    }


    IEnumerator Checking()
    {
        //CheckForPlayer = false;
        blocked = NavMesh.Raycast(transform.position, Player.position, out hit, NavMesh.AllAreas);
        Debug.DrawLine(transform.position, Player.position, blocked ? Color.red : Color.green);
        
        if (blocked == false)
        {
            runtoplayer = true;
            //CheckForPlayer = false;
        }
        if (blocked == true)
        {
            Debug.DrawRay(hit.position, Vector3.up, Color.red);
            runtoplayer = false;
            //newchasespeed = 1.5f;
            Col.enabled = true;
            //CheckForPlayer = true;


        }

        yield return new WaitForSeconds(3.0f);

        StartCoroutine(TimedCheck());
    }

    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(3.0f);

        StartCoroutine(Checking());
        //TimedCheckActive = false;
    }


}
