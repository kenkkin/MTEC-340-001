using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour Instance;

    public Transform player;

    private GameObject _gameObject;

    void Awake() //initialised in Awake as opposed to Start because it will initialise first, before start and only once. This gives GameBehaviour priority over GameObjects
    {
        // singleton pattern: enforces a single reference to the instance 
        if  (Instance != null && Instance != this)
            Destroy (this);
        else 
            Instance = this;

        _gameObject = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update () {
        transform.position = player.transform.position + new Vector3(0, 1, -5);

        if (_gameObject == null)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
