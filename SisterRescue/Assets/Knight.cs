using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knight : MonoBehaviour
{
    CapsuleCollider cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            if (index == SceneManager.sceneCountInBuildSettings - 2)
            {
                Debug.Log(SceneManager.sceneCount - 1);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            SceneManager.LoadScene(index + 1);


        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }
    }
}
