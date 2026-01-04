using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform player;

    [SerializeField] float spawnRate;

    [SerializeField] float noSpawnRadius;
    [SerializeField] float spawnRadius;

    [SerializeField] float enemyCounter;


    private void Start()
    {
        StartCoroutine(Spawn());
    }


    // Spawn enemies every # seconds at a random spot around the player
    IEnumerator Spawn()
    {
        while (enemyCounter < 3000)
        {
            Vector3 pos = SpawnRadiusMath.RingSpawnner(player.position, noSpawnRadius, spawnRadius);
            Instantiate(enemyPrefab, pos, Quaternion.identity);

            //yield return new WaitForSeconds(spawnRate);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (!player) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, noSpawnRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, spawnRadius);
    }
}
