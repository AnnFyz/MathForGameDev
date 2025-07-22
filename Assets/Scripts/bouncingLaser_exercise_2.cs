using UnityEngine;

public class bouncingLaser_exercise_2 : MonoBehaviour
{
    [SerializeField]
    Transform laser;
    [SerializeField]
    int bounces = 3; // Number of bounces for the laser beam
    Ray[] reflectionRays; // Array to hold the reflection rays
    RaycastHit[] hits; 
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
        reflectionRays[0] = new Ray(laser.position, laserBeam); // Store the first reflection ray in the first element of the array
        hits = new RaycastHit[bounces]; // Initialize the hits array to store the hit information for each bounce
        if (Physics.Raycast(reflectionRays[0], out hits[0], laserLength)) // Check for the first hit
        {
            Gizmos.color = Color.yellow; // Change color to yellow if it hits something
            Gizmos.DrawLine(laser.position, hits[0].point); // Draw a line to the hit point
            Gizmos.DrawSphere(hits[0].point, 0.1f); // Draw a sphere at the hit point
            Vector3 incomingDirection = reflectionRays[0].direction; // Get the direction of the incoming ray
            Vector3 vectorProjection = Vector3.Dot(incomingDirection, hits[0].normal) * hits[0].normal; // Calculate the projection of the incoming direction onto the normal
            Vector3 reflectionDirection = incomingDirection - 2 * vectorProjection; // Calculate the reflection direction
            Gizmos.DrawLine(hits[0].point, hits[0].point + reflectionDirection * laserLength); // Draw the reflected ray
        }
        else
        {
            Gizmos.color = Color.red; // Keep the color red if nothing is hit
        }


        // Calculate the reflection rays based on the number of bounces
        //for (int i = 1; i < bounces; i++)
        //{
        //    if (hits[i - 1].collider != null) // Check if the previous hit was valid
        //    {
        //        reflectionRays[i] = new Ray(hits[i - 1].position, hits[i - 1].position + hits[i - 1].up); // Create a new ray for the reflection
        //        if (Physics.Raycast(reflectionRays[i], out hits[i], laserLength)) // Check for hits with the new ray
        //        {
        //            Gizmos.color = Color.yellow; // Change color to yellow if it hits something
        //            Gizmos.DrawLine(hits[i - 1].point, hits[i].point); // Draw a line to the new hit point
        //            Gizmos.DrawSphere(hits[i].point, 0.1f); // Draw a sphere at the new hit point
        //            Vector3 incomingDirection = reflectionRays[i].direction;
        //            Vector3 vectorProjection = Vector3.Dot(incomingDirection, hits[i].normal) * hits[i].normal;
        //            Vector3 reflectionDirection = incomingDirection - 2 * vectorProjection;
        //            Gizmos.DrawLine(hits[i].point, hits[i].point + reflectionDirection * laserLength);
        //        }
        //        else
        //        {
        //            Gizmos.color = Color.red; // Keep the color red if nothing is hit
        //        }
        //    }
        //}
    }
}
