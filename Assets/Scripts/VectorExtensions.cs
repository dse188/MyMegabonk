using UnityEngine;

public static class VectorExtensions
{

    public static Vector3 XZVector(this Vector3 v)
    {
        return new Vector3(v.x, 0f, v.z);
    }
}