using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knight : MonoBehaviour
{
    CapsuleCollider cc;
    [SerializeField] int damage = 10;
    [SerializeField] int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponentInChildren<CapsuleCollider>();
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
            if (cc.enabled)
            {
                Debug.Log("Damage");
            }
        }
        else if(collision.gameObject.CompareTag("EnemyWeapon"))
        {
            Destroy(collision.gameObject);
            health -= collision.gameObject.GetComponent<ProjectileDamage>().getDamage();
            if (health <= 0)
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(index);
            }
        }
    }

    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int dam)
    {
        damage = dam;
    }
}
