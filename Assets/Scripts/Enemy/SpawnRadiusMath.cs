using UnityEngine;

public class SpawnRadiusMath
{
    // Returns a random point in an annulus (ring) around center on the XZ plane.
    public static Vector3 RingSpawnner(Vector3 centerPoint, float innerRadius, float outerRadius)
    {
        float angle = Random.Range(0, Mathf.PI * 2f);

        float radius = Mathf.Sqrt(Random.Range(innerRadius * innerRadius, outerRadius * outerRadius));

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        return new Vector3(centerPoint.x + x, centerPoint.y + 10f, centerPoint.z + z);

    }
}
