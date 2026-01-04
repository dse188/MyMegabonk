using UnityEngine;
using UnityEngine.AI;

public class AgentFallOnSpawn : MonoBehaviour
{
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundMask;

    Rigidbody rb;
    Collider col;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        Vector3 origin = col.bounds.center;
        origin.y = col.bounds.min.y + 0.05f;

        bool grounded = Physics.Raycast(origin, Vector3.down, out RaycastHit hit, groundCheckDistance, groundMask);

        if (grounded)
            Debug.Log("Enemy landed!");
    }
}
