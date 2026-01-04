using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    Transform player;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (agent.isActiveAndEnabled)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        agent.destination = player.position;
    }
}
