using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    [SerializeField] int enemyCount;
    [SerializeField] GameObject doorBefore = null;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorBefore != null)
        {
            if (!doorBefore.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= enemyCount)
        {
            gameObject.SetActive(false);
        }

    }
}
