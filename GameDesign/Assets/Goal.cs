using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    CapsuleCollider CC;
    // Start is called before the first frame update
    void Start()
    {
        CC = gameObject.GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            if(index == SceneManager.sceneCountInBuildSettings - 2)
            {
                Debug.Log(SceneManager.sceneCount - 1);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            SceneManager.LoadScene(index + 1);
        }
    }
}
