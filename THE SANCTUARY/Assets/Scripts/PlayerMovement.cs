using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [Space]

    [Header("Rotation")]
    [SerializeField] Transform weapon;
    [SerializeField] float offset;

    [Space]

    [Header("Projectiles")]
    [SerializeField] Transform shooter;
    [SerializeField] GameObject projectile;
    [SerializeField] float delay;
    private float nextShot;

    void Update()
    {
        // movement
        if(Input.GetMouseButtonDown(0))
        {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(movePosition, out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }

        // rotation
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0.0f, 0.0f, angle + offset);

        // projectile shooting
        if (Input.GetMouseButtonDown(1))
        {
            Projectile();
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("X_X");
        }
    }

    void Projectile()
    {    
        if (Time.time > nextShot)
        {
            nextShot = Time.time + delay;
            Instantiate(projectile, shooter.position, shooter.rotation);
        }
    }
}
