using UnityEngine;
using UnityEngine.SceneManagement;

// make sure scene exists in build settings
public class StartBehaviour : MonoBehaviour
{
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Return))
       {
          SceneManager.LoadScene("Cutscene"); // string sceneName preferred to index int // defaults to loading a single scene (can set = to LoadSceneMode.Additive | use LoadSceneAsync)
       } 
    }

     public void StartGame()
     {
          SceneManager.LoadScene("Cutscene"); // string sceneName preferred to index int // defaults to loading a single scene (can set = to LoadSceneMode.Additive | use LoadSceneAsync)
     } 
}
