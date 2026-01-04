using UnityEngine;


public class EnemyBrain : MonoBehaviour
{
    Transform player;
    Rigidbody rb;
    [SerializeField] float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0f;

        if (toPlayer.sqrMagnitude < 0.0001f) return;

        ///Vector3 dir = VectorExtensions.XZVector(player.position - transform.position);
        Vector3 dir = toPlayer.normalized;
        Vector3 nextPos = transform.position + dir * speed * Time.fixedDeltaTime;
        rb.MovePosition(nextPos);
        
    }
}
