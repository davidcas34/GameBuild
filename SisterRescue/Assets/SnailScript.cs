using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
    [SerializeField] Animator animationController;
    [SerializeField] float roam = 1f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    [SerializeField] int Health;


    //ProjectileScript
    [SerializeField] GameObject proj;
    [SerializeField] GameObject fowardObj;
    [SerializeField] GameObject targets;
    [SerializeField] float shotDelay;
    [SerializeField] float speed;
    bool canShot = true; GameObject projCole;

    bool Attacked;

    // Start is called before the first frame update
    void Start()
    {
        Attacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Attacked)
        {
            distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
           // Debug.Log(distanceToTarget);
            if (distanceToTarget > 10f)
            {
                animationController.SetBool("Attack", false);
                
                animationController.SetBool("Turn", true);
                transform.LookAt(target);
                animationController.SetBool("Turn", false);
                //Projectile

                if (canShot)
                    {
                        projCole = (GameObject)Instantiate(proj, fowardObj.transform.position, transform.rotation);
                        projCole.GetComponent<MeshRenderer>().enabled = true;
                        projCole.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                        projCole.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                        canShot = false;
                        StartCoroutine(ShootandWait(shotDelay));
                    }
                    

            }
            else if (distanceToTarget < 10f)
            {
                /*
                Debug.Log("close");

                //animationController.SetBool("Turn", true);

                // transform.LookAt(target.position);
                // transform.LookAt(target.position);

                Vector3 newV = target.position;

                transform.LookAt(newV);

                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                //animationController.SetBool("Turn", false);
                Debug.Log(target.position);
                animationController.SetBool("Attack", true);
                

                // animationController.SetBool("Attack", false);
                */
            }
        }
    }

    private IEnumerator ShootandWait(float delay)
    {
        projCole.GetComponent<Rigidbody>().AddForce(transform.forward * 7);
        yield return new WaitForSeconds(delay);
        canShot = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(projCole);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            if (!Attacked)
            {
                Attacked = true;
            }
            else
            {
                Health -= collision.gameObject.GetComponentInParent<Knight>().getDamage();
                if (Health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
