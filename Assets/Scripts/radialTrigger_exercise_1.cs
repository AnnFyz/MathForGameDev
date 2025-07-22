using UnityEngine;

public class radialTrigger_exercose_1 : MonoBehaviour
{
    [SerializeField]
    Transform triggerZone, NPC;
    [SerializeField]
    float triggerRadius = 5f; // Radius of the trigger zone

    private void OnDrawGizmos()
    {
        if (Vector3.Distance(triggerZone.position, NPC.position) <= triggerRadius)
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
