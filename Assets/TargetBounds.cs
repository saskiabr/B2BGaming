using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBounds : MonoBehaviour
{
    // Add this static so the other classes (in this case Target) will be able to access this.
    public static TargetBounds Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] BoxCollider col;

    public Vector3 GetRandomPosition()
    {   
        // Get the center of our target boundary
        Vector3 center = col.center + transform.position;

        // Get boundaries of target bounds
        float minX = center.x - col.size.x / 2f;
        float maxX = center.x + col.size.x / 2f;

        float minY = center.y - col.size.y / 2f;
        float maxY = center.y + col.size.y / 2f;

        float minZ = center.z - col.size.z / 2f;
        float maxZ = center.z + col.size.z / 2f;

        // Generate a random location (coordinates)
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        // Turn the location into a vector
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        return randomPosition;
    }
}
