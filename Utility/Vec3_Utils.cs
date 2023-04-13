using UnityEngine;
using UnityEngine.AI;
public static class Vec3_Utils 
{
    public static Vector3 RandomizeAll(float min, float max) 
    {
        float x, y, z;
        x = Random.Range(min, max);
        y = Random.Range(min, max);
        z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    private static bool PointIsNavigable(Vector3 pos, out float y)
    {
        bool navigable = NavMesh.SamplePosition(pos, out NavMeshHit hit, 1.0f, NavMesh.AllAreas);
        y = hit.position.y;
        return navigable;
    }

    /// <summary>
    /// Will return a random position within radius of passed position. Will place the object on the ground or at the passed position's Y.
    /// </summary>
    /// <param name="maxDist"></param>
    /// <param name="pos"></param>
    /// <param name="ensureNavigable">Optionally can check that the position is navigable on the NavMesh.</param>
    /// <returns></returns>
    public static Vector3 RandomPositionNearPosition(float maxDist, Vector3 pos, bool ensureNavigable = false)
    {
        float prevY = pos.y;
        pos += (Random.insideUnitSphere * maxDist);

        //Place the object on the ground.
        if (ensureNavigable)
            PointIsNavigable(pos, out pos.y);
        else
            pos.y = prevY;

        return pos;
    }
    public static Vector3 WithinRadiusOfOrigin(float radius)
    {
        Vector3 pos = Random.insideUnitSphere * radius;
        pos.y = 0;

        return pos;
    }

    public static Vector3 RandPosNearTransform(Transform me, float maxDist) 
    {
        float dist = maxDist / 2f;

        return new Vector3(me.position.x + Random.Range(-dist, dist),
                            me.position.y,
                            me.position.z + Random.Range(-dist, dist));
    }
}
