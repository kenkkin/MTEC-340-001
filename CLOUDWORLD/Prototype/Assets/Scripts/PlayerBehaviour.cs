using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5.0f;

    [SerializeField] Rigidbody2D rb;

    Vector2 movement;

    // Player Attack
    private GameObject _attackArea = default;

    private bool _attacking = false;

    private float _timeToAttack = 0.25f;
    private float _timer = 0f;

    void Start()
    {
        _attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (_attacking)
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeToAttack)
            {
                _timer = 0;
                _attacking = false;
                _attackArea.SetActive(_attacking);
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        _attacking = true;
        _attackArea.SetActive(_attacking);
    }
}
