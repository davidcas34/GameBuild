using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null; // for the damage effect
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
    //[SerializeField] Animator animationController;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    public int maxHealth = 5; // Health for the enemy
    public int currentHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // animationController = GetComponent<Animator>();
        agent.SetDestination(target.position);

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
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

        //code to kill the enemy and see particle effect
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentHealth - 1 == 0)
            {
                Destroy(gameObject);
            }
            else
                TakeDamage(1);
            Collect();
        }
        


    }

    //Code to take on coming damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
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

    public void Collect()
    {
        //this will play the effect
        collectParticle.Play();
    }
}

