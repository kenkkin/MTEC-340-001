using UnityEngine;
using UnityEngine.UIElements;

public class FollowBehaviourScript : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float speed;

    private float distance;

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
