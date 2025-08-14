using UnityEngine;

public class lookAtTrigger_exercise_4 : MonoBehaviour
{
    [SerializeField]
    Transform triggerZone, NPC;
    [SerializeField]
    [Range(0, 1)] float lookAtThreshold = 0.5f, dotProduct; // Threshold for the NPC to look at the trigger zone
    [SerializeField]
    float triggerRadius = 5f; // Radius of the trigger zone

    private void OnDrawGizmos()
    {
        dotProduct = Vector3.Dot(triggerZone.right, (NPC.position - triggerZone.position).normalized); // Calculate the dot product to determine if the NPC is looking at the trigger zone
        if (Vector3.Distance(triggerZone.position, NPC.position) <= triggerRadius && dotProduct >= lookAtThreshold)
        {
          
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(triggerZone.position, triggerRadius); // Draw a wire sphere to represent the trigger zone
            Gizmos.DrawLine(triggerZone.position, NPC.position); // Draw a line if the NPC is within the trigger zone
            Gizmos.DrawSphere(NPC.position, 0.2f); // Draw a sphere at the NPC's position
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(triggerZone.position, triggerRadius); // Draw a wire sphere to represent the trigger zone
            Gizmos.DrawSphere(NPC.position, 0.1f); // Draw a smaller sphere if the NPC is outside the trigger zone
        }
    }
}
