using UnityEngine;

public class bouncingLaser_exercise_2 : MonoBehaviour
{
    [SerializeField]
    Transform laser;
    [SerializeField]
    int bounces = 3; // Number of bounces for the laser beam
    Ray[] reflectionRays; // Array to hold the reflection rays
    RaycastHit[] hits;
    Vector3[] reflectionDirections;
    [SerializeField]
    float laserLength = 10f; // Length of the laser beam
    private void OnDrawGizmos()
    {
        // original laser's ray
        Gizmos.color = Color.red; // Set the color of the laser beam
        Vector3 laserBeam = laser.position + laser.up * laserLength; // Calculate the end position of the laser beam
        Gizmos.DrawLine(laser.position, laserBeam); // Draw the laser beam

        //calculate the first reflection ray
        reflectionRays = new Ray[bounces]; // Initialize the array with the number of bounces
        hits = new RaycastHit[bounces]; // Initialize the hits array to store the hit information for each bounce
        reflectionDirections = new Vector3[bounces];
        reflectionRays[0] = new Ray(laser.position, laser.up); // Store the first reflection ray in the first element of the array
        hits = new RaycastHit[bounces]; // Initialize the hits array to store the hit information for each bounce
        if (Physics.Raycast(reflectionRays[0], out hits[0], laserLength)) // Check for the first hit
        {
            Gizmos.color = Color.green; // Change color to yellow if it hits something
            Vector3 hitPosition = hits[0].point; // Get the hit point in world coordinates
            Gizmos.DrawLine(laser.position, hitPosition); // Draw a line to the hit point
            Gizmos.DrawSphere(hitPosition, 0.1f); // Draw a sphere at the hit point
            Vector3 incomingDirection = reflectionRays[0].direction; // Get the direction of the incoming ray
            Vector3 vectorProjection = Vector3.Dot(incomingDirection, hits[0].normal) * hits[0].normal; // Calculate the projection of the incoming direction onto the normal
            reflectionDirections[0] = incomingDirection - 2 * vectorProjection; // Calculate the reflection direction r = d - 2 * (d * n) * n, where d is the incoming direction and n is the normal of the surface hit
        }
        else
        {
            Gizmos.color = Color.red; // Keep the color red if nothing is hit
        }

        //Calculate the reflection rays based on the number of bounces
        for (int i = 1; i < bounces; i++)
        {
            if (hits[i - 1].collider != null) // Check if the previous hit was valid
            {
                reflectionRays[i] = new Ray(hits[i - 1].point, reflectionDirections[i - 1]); // Create a new ray from the hit point in the reflected direction
                if (Physics.Raycast(reflectionRays[i], out hits[i], laserLength)) // Check for a hit with the new ray
                {
                    Gizmos.color = Color.magenta; // Change color to green if it hits something
                    Vector3 hitPosition = hits[i].point; // Get the hit point in world coordinates
                    Gizmos.DrawLine(hits[i - 1].point, hitPosition); // Draw a line to the hit point
                    Gizmos.DrawSphere(hitPosition, 0.1f); // Draw a sphere at the hit point
                    Vector3 incomingDirection = reflectionRays[i].direction; // Get the direction of the incoming ray
                    Vector3 vectorProjection = Vector3.Dot(incomingDirection, hits[i].normal) * hits[i].normal; // Calculate the projection of the incoming direction onto the normal
                    reflectionDirections[i] = incomingDirection - 2 * vectorProjection; // Calculate the reflection direction
                }
                else
                {
                    Gizmos.color = Color.black; // Keep the color red if nothing is hit
                }
            }
            else
            {
                break; // Exit if there are no more valid hits
            }

        }
    }
}
