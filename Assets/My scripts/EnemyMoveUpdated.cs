using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveUpdated : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Transform TheTarget;
    private float DistanceToTarget;
    private int TargetNumber = 1;
    private bool HasStopped = false;
    private bool Randomizer = true;
    private int NextTargetNumber;

    [SerializeField] float StopDistance = 2.0f;
    [SerializeField] Transform Waypoint1;
    [SerializeField] Transform Waypoint2;
    [SerializeField] Transform Waypoint3;
    [SerializeField] float WaitTime = 2.0f;
    [SerializeField] int MaxWayPoints;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        TheTarget = Waypoint1;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(TheTarget.position, transform.position);

        if(DistanceToTarget > StopDistance)
        {
            nav.SetDestination(TheTarget.position);
            NextTargetNumber = TargetNumber;
            nav.isStopped = false;
        }

        else if (DistanceToTarget < StopDistance)
        {
            nav.isStopped = true;
            StartCoroutine(EnemyPause());
        }
    }

    void SetTarget()
    {
        if(TargetNumber == 1)
        {
            TheTarget = Waypoint1;
        }
        if (TargetNumber == 2)
        {
            TheTarget = Waypoint2;
        }
        if (TargetNumber == 3)
        {
            TheTarget = Waypoint3;
        }
    }


    IEnumerator EnemyPause()
    {
        anim.SetInteger("State", 1);
        yield return new WaitForSeconds(WaitTime);

        if(HasStopped == false)
        {
            HasStopped = true;
            if(Randomizer == true)
            {
                Randomizer = false;
                TargetNumber = Random.Range(1, MaxWayPoints);

                if(NextTargetNumber == TargetNumber)
                {
                    TargetNumber++;
                }
                else if (TargetNumber == MaxWayPoints)
                {
                    TargetNumber = 1;
                }
            }

            SetTarget();
            //anim.SetInteger("State", 0);

            yield return new WaitForSeconds(WaitTime);
            Randomizer = true;
            HasStopped = false;
        }
    }
}
