using UnityEngine;

public class EnemyFallHandler : MonoBehaviour
{
    public bool Landed { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (Landed) return;
        Landed = true;
    }
}
