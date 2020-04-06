using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordDamage : MonoBehaviour
{
    Animator parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            if(parent.GetBool("Attack"))
            {
                Debug.Log("Damage");
            }
            else if(parent.GetBool("Block"))
            {
                Debug.Log("Block");
            }
        }
    }
}
