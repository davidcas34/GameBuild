using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManger : MonoBehaviour
{
    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
    public void loadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
