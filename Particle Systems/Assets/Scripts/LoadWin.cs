using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider ChangeScene)
    {
        if(ChangeScene.gameObject.CompareTag("Player"))
        {
            Invoke("LoadNextScene", 2.05f);
            Debug.Log("Trigger Entered");
        } 
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Win");
    }
}
