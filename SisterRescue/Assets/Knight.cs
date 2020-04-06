using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;

    public health_display healthBar;

    CapsuleCollider cc;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
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
            if (currentHealth - 1 == 0)
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(index);
            }
            else
                TakeDamage(1);
        }
    }



    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
