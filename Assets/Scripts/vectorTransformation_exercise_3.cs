using Unity.VisualScripting;
using UnityEngine;

public class vectorTransformation_exercise_3 : MonoBehaviour
{
    [SerializeField]
    Vector2 localCoord, gloabalCoord;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; // Set the color for the local coordinates
        Gizmos.DrawSphere(LocalToWorld(localCoord), 0.5f); // Draw a sphere at the origin of the local space
        Gizmos.color = Color.red; // Set the color for the global coordinates
        Vector2 worldCoor = WorldToLocal(gloabalCoord);
        Gizmos.DrawSphere(gloabalCoord, 0.5f); // Draw a sphere at the global coordinates
    }

    Vector2 LocalToWorld(Vector2 localCoord)
    {
        Vector2 position = transform.position;
        position += localCoord.x * (Vector2)transform.right; // Convert local x-coordinate to world coordinates
        position += localCoord.y * (Vector2)transform.up; // Convert local y-coordinate to world coordinates
        return position;
    }

    Vector2 WorldToLocal(Vector2 worldCoord)
    {
        Vector2 rel = worldCoord - (Vector2)transform.position; // Get the position relative to the transform's position
        float x = Vector2.Dot(rel, transform.right); // Project onto the right vector
        float y = Vector2.Dot(rel, transform.up); // Project onto the up vector
        return new Vector2(x, y); // Return the local coordinates
    }
}

