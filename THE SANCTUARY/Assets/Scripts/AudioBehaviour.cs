using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AudioBehaviour : MonoBehaviour
{
    [Tooltip("Names of the scenes this object should stay alive in when transitioning into")]
    public List<string> sceneNames;

    [Tooltip("A unique string identifier for this object, must be shared across scenes to work correctly")]
    public string instanceName;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        // subscribe to the scene load callback
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // delete any potential duplicates that might be in the scene already, keeping only this one 
        CheckForDuplicateInstances();

        // check if this object should be deleted based on the input scene names given 
        CheckIfSceneInList();
    }

    void CheckForDuplicateInstances()
    {
        // cache all objects containing this component
        AudioBehaviour[] collection = FindObjectsOfType<AudioBehaviour>();

        // iterate through the objects with this component, deleting those with matching identifiers
        foreach (AudioBehaviour obj in collection)
        {
            if(obj != this) // avoid deleting the object running this check
            {
                if (obj.instanceName == instanceName)
                {
                    Debug.Log("Duplicate object in loaded scene, deleting now...");
                    DestroyImmediate(obj.gameObject);
                }
            }
        }
    }

    void CheckIfSceneInList()
    {
        // check what scene we are in and compare it to the list of strings 
        string currentScene = SceneManager.GetActiveScene().name;

        if (sceneNames.Contains(currentScene))
        {
            // keep the object alive 
        }
        else
        {
            // unsubscribe to the scene load callback
            SceneManager.sceneLoaded -= OnSceneLoaded;

            DestroyImmediate(this.gameObject);
        }
    }
}

// {
//     private static AudioBehaviour instance = null;
//     private string currentScene;
    
//     public static AudioBehaviour Instance
//     {
//         get { return instance; }
//     }
    
//     void Awake()
//     {
//         if (instance != null && instance != this) 
//         {
//             Destroy(this.gameObject);
//             return;
//         } 
//         else 
//         {
//             instance = this;
//         }
//         DontDestroyOnLoad(this.gameObject);
//     }

//     void Start()
//     {
//         currentScene = SceneManager.GetActiveScene().name;
//     }
    
//     private void FinalScore()
//     {
//         if(currentScene == "LVL 2")
//         {
//             Destroy(instance);
//         }
//     }
// }