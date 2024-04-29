using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteLevel : MonoBehaviour


{
    public string nextLevelName; 

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Next level"))
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}