using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private string currentScene;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    } 

    private void OnTriggerEnter(Collider ChangeScene)
    {
        if(ChangeScene.gameObject.CompareTag("Player"))
        {
            Invoke("LoadNextScene", 1.05f);
            Debug.Log("Trigger Entered");
        } 
    }

    void LoadNextScene()
    {
        if(currentScene == "LVL 1")
        {
            SceneManager.LoadScene("LVL 2");
        }

        if(currentScene == "LVL 2")
        {
            SceneManager.LoadScene("WIN");
        }
    }
}
