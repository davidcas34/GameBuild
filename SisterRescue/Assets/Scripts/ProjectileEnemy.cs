using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ProjectileEnemy : MonoBehaviour
{
    [SerializeField] GameObject proj;
    [SerializeField] GameObject fowardObj;
    [SerializeField] GameObject target;
    [SerializeField] float shotDelay;
    [SerializeField] float speed;
    bool canShot = true; GameObject projCole;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void attack()
    {
        if (canShot)
        {
            projCole = (GameObject)Instantiate(proj, fowardObj.transform.position, transform.rotation);
            projCole.GetComponent<MeshRenderer>().enabled = true;
            projCole.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

            canShot = false;
            StartCoroutine(ShootandWait(shotDelay));
        }
        Debug.Log(canShot);
        Debug.Log(target.transform.position);
    }

    private IEnumerator ShootandWait(float delay)
    {
        projCole.GetComponent<Rigidbody>().AddForce(transform.forward * 7);
        yield return new WaitForSeconds(delay);
        canShot = true;
    }
}
