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
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (!attacked)
            {
                sword.enabled = true;
                sword.Play("Attack", 0, 0.50f);
                attacked = true;
                time = Time.time;
            }
            else
            {
                Debug.Log(Time.time);
                Debug.Log(time);
                if (Time.time - time > 0.1f)
                {
                    Debug.Log("Sub" + (Time.time - time).ToString());
                    sword.enabled = false;
                    attacked = false;
                }
            }
        }
    }
}
