using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    Animator sword;
    bool attacked = false;
    float time;

    void Start()
    {
        sword = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            sword.SetBool("Attack", true);
        }
        else
        {
            sword.SetBool("Attack", false);
        }
        if (Input.GetKey(KeyCode.G))
            sword.SetBool("Block", true);
        else
            sword.SetBool("Block", false);
        if (Input.GetKey(KeyCode.H))
            sword.SetBool("Poke", true);
        else
            sword.SetBool("Poke", false);
    }
    
}
