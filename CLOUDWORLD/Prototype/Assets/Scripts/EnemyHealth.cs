using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int HP;
    public void TakeDamage(int damage)
    {
        HP -= damage;
        
        if (gameObject.tag == "Enemy")
        {
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
