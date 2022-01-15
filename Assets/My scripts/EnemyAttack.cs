using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent Nav;
    private NavMeshHit hit;
    private bool blocked = false;
    private bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool IsChecking = true;
    private int FailedChecks = 0;

    [SerializeField] Transform Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] float MaxRange = 35.0f;
    [SerializeField] int MaxChecks = 3;
    [SerializeField] float ChaseSpeed = 8.5f;
    [SerializeField] float WalkSpeed = 1.6f;
    [SerializeField] float AttackDistance = 2.3f;
    [SerializeField] float AttackRotateSpeed = 2.0f;
    [SerializeField] float CheckTime = 3.0f;
    [SerializeField] GameObject HurtUI;

    [SerializeField] Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);
        if(DistanceToPlayer < MaxRange)
        {
            if(IsChecking == true)
            {
                IsChecking = false;


                blocked = NavMesh.Raycast(transform.position, Player.position, out hit, NavMesh.AllAreas);
                if(blocked == false)
                {
                    Debug.Log("I CAN SEE THE PLAYER");
                    RunToPlayer = true;
                    FailedChecks = 0;
                    
                }
                if(blocked == true)
                {
                    Debug.Log("FIND HIM");
                    RunToPlayer = false;
                    Anim.SetInteger("State", 1);
                    FailedChecks++;

                    



                }


                StartCoroutine(TimedCheck());
            }
        }


        if(RunToPlayer == true)
        {
            
            if(DistanceToPlayer > AttackDistance)
            {
                StartCoroutine(WaitToRun());
                Nav.isStopped = false;
                Anim.SetInteger("State", 2);
                Nav.acceleration = 24;
                //Nav.SetDestination(Player.position);
                Nav.speed = ChaseSpeed;
                HurtUI.gameObject.SetActive(false);
            }
            if (DistanceToPlayer < AttackDistance - 0.5f)
            {
                Nav.isStopped = true;
                Debug.Log("Hit Him");
                Anim.SetInteger("State", 3);
                Nav.acceleration = 180;
                HurtUI.gameObject.SetActive(true);

                //if (EnemyDamage.EnemyHealth <= 0)
                //{
                //    Anim.SetInteger("State", 0);
                //    Enemy.GetComponent<EnemyMove>().enabled = true;
                //    Nav.isStopped = false;
                //    Nav.speed = WalkSpeed;
                //    FailedChecks = 0;
                //}


                //ENEMY ROTATION
                Vector3 Pos = (Player.position - Enemy.transform.position).normalized;
                Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, PosRotation, Time.deltaTime * AttackRotateSpeed);
            }

        }

        else if(RunToPlayer == false)
        {
            Nav.isStopped = true;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RunToPlayer = true;
        }

    }


    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(CheckTime);
        IsChecking = true;

        if(FailedChecks > MaxChecks)
        {
            Nav.isStopped = false;
            Nav.speed = WalkSpeed;
            FailedChecks = 0;
        }
    }

    IEnumerator WaitToRun()
    {
        yield return new WaitForSeconds(0.1f);
        Nav.SetDestination(Player.position);
    }
}
