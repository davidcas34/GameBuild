using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
    //[SerializeField] Animator animationController;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      // animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        Debug.Log(distanceToTarget);
        if (distanceToTarget < chaseRange)
        {
            isProvoked = true;

        }

        if (isProvoked)
        {
            EngageTarget();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        // if distance to target is less than chase range but more than attack distance
        if (distanceToTarget >= agent.stoppingDistance)
        {
            //ChaseTarget();
           // animationController.SetTrigger("run");
          //  animationController.SetBool("Attack", false);
            agent.SetDestination(target.position);
        }

        else
        {
            //AttackTarget();
         //   animationController.SetBool("Attack", true);
            Debug.LogError("I am attacking you...........");
        }
    }
}
