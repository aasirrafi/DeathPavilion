using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent Nav;
    private Animator Anim;
    private Transform TheTarget;
    private float DistanceToTarget;
    private int TargetNumber = 1;
    private bool HasStopped = false;
    private bool Randomizer = true;
    private int NextTargetNumber;
    

    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
    [SerializeField] Transform Target3;
    [SerializeField] Transform Target4;
    [SerializeField] int MaxTargets = 4;
    [SerializeField] float StopTime = 0.0f;
    [SerializeField] float StopDistance= 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Nav = GetComponent<NavMeshAgent>();
        TheTarget = Target1;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(TheTarget.position, transform.position);
        if (DistanceToTarget > StopDistance)
        {
            Nav.SetDestination(TheTarget.position);
            Anim.SetInteger("State", 0);
            Nav.isStopped = false;
            NextTargetNumber = TargetNumber;


        }
        if (DistanceToTarget < StopDistance)
        {
            Nav.isStopped = true;
            Anim.SetInteger("State", 1);
            StartCoroutine(LookAround());
                    
        }
    }
    void SetTarget()
    {
        if (TargetNumber == 1)
        {
            TheTarget = Target1;
        }
        if (TargetNumber == 2)
        {
            TheTarget = Target2;
        }
        if (TargetNumber == 3)
        {
            TheTarget = Target3;
        }
        if (TargetNumber == 4)
        {
            TheTarget = Target4;
        }

    }
    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(StopTime);
        if(HasStopped==false)

        {
            HasStopped = true;
            if(Randomizer==true)
            {
                Randomizer = false;
                TargetNumber = Random.Range(1, MaxTargets);

            
                if (TargetNumber == NextTargetNumber)
                {
                    TargetNumber++;

                    if (TargetNumber >= MaxTargets)
                    {
                        TargetNumber = 1;
                    }
                }

            }

            SetTarget();
            yield return new WaitForSeconds(StopTime);
            HasStopped = false;
            Randomizer = true;

        }


    }
}
