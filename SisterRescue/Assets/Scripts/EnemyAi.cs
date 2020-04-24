using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
    [SerializeField] Animator animationController;
    [SerializeField] float roam = 1f;
    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    [SerializeField] int Health;
    [SerializeField] int damage = 10;

    //ProjectileScript
    [SerializeField] GameObject proj;
    [SerializeField] GameObject fowardObj;
   // [SerializeField] GameObject target;
    [SerializeField] float shotDelay;
    [SerializeField] float speed;
    bool canShot = true; GameObject projCole;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animationController.SetBool("Run", true);
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        if (distanceToTarget < chaseRange)
        {
            isProvoked = true;

        }
        else
        {
            if (Time.time > roam)
            {
                animationController.SetBool("Run", true);
                Vector3 newposition = transform.position + Random.insideUnitSphere * 20;
                agent.SetDestination(newposition);
            }
            isProvoked = false;
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
            animationController.SetBool("Run", true);
            animationController.SetBool("Attack", false);
            agent.SetDestination(target.position);
        }

        else
        {
            if (canShot)
            {
                //AttackTarget();
                animationController.SetBool("Run", false);
                animationController.SetBool("Attack", true);
                //transform.LookAt(target);
                attack();
                Debug.LogError("I am attacking you...........");
            }
        }
    }

    //Projectile
    public void attack()
    {
        if (canShot)
        {
            projCole = (GameObject)Instantiate(proj, fowardObj.transform.position, transform.rotation);
            projCole.GetComponent<MeshRenderer>().enabled = true;
            projCole.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            projCole.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            canShot = false;
           // animationController.SetBool("Attack", false);
            StartCoroutine(ShootandWait(shotDelay));
        }
    }

    private IEnumerator ShootandWait(float delay)
    {
        projCole.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        yield return new WaitForSeconds(delay);
        canShot = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(projCole);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Hit");
            Health -= collision.gameObject.GetComponentInParent<Knight>().getDamage();
            
            Debug.Log(Health);
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Door");
            Vector3 newposition = transform.position + Random.insideUnitSphere * 20;
            agent.SetDestination(newposition);
        }
    }

    public int getDamage()
    {
        return damage;
    }
}
