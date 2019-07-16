using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadNextSceneByName();
    }

    public void LoadNextSceneByName()
    {
        string gameOverSceneName = "GameOver";
        SceneManager.LoadScene(gameOverSceneName);
    }
}
