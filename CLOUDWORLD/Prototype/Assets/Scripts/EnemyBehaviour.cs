using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.PlayerLoop;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int HP;

    public Health PlayerHealth;
    public PlayerBehaviour PlayerAttack;
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth.TakeDamage(damage);
        }
    }
}
