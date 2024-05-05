using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Patrolling")]
    [SerializeField] Transform[] wayPoints;
    [SerializeField] int targetPoint;
    [SerializeField] float speed;

    [Space]

    [Header("States")]
    [SerializeField] float sightRange;
    [SerializeField] bool inSightRange;

    [Space]

    [Header("Enemy Movement")]
    [SerializeField] NavMeshAgent enemy;
    [SerializeField] Transform player;
    [SerializeField] LayerMask isGround, isPlayer; 

    void Awake()
    {
        player = GameObject.Find("player").transform;
        enemy = GetComponent<NavMeshAgent>();
        targetPoint = 0;
    }
   
    void Update()
    {
        inSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);

        if (!inSightRange) 
        {
            Patrolling();
        }
        if (inSightRange) 
        {
            Chase();
        }
    }

    void Patrolling()
    {
        Debug.Log("Patrol");
        if (Vector3.Distance(transform.position, wayPoints[targetPoint].position) < 0.1f)
        {
            IncreaseTargetInt();
        }

        Vector3 direction = (wayPoints[targetPoint].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void IncreaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= wayPoints.Length)
        {
            targetPoint = 0;
        }
    }

    public void Chase()
    {
        Debug.Log("Chase");
        enemy.SetDestination(player.position);
        transform.LookAt(player);
    }
}
