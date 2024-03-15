using UnityEngine;
using UnityEngine.SceneManagement;

// make sure scene exists in build settings
public class CutsceneBehaviour : MonoBehaviour
{
    void Start()
    {
       Invoke("LoadScene", 16.5f); // delay's the specified function by a certain amount of seconds
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Village");  
    }
}
