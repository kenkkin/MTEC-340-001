using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] int damage = 3;

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth _health = collider.GetComponent<EnemyHealth>();
            _health.TakeDamage(damage);
        }
    }
}
