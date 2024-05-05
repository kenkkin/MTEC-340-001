using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}