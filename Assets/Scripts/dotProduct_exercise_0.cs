using UnityEngine;

public class dotProduct_exercise_0 : MonoBehaviour
{
    [SerializeField]
    Transform A;
    [SerializeField]
    Transform B;
    [SerializeField]
    float scalarProjection;
    private void OnDrawGizmos()
    {
        Vector2 a = A.position;
        Vector2 b = B.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, A.position);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(default, B.position);

        //float aMagnitude = Mathf.Sqrt(a.x * a.x + a.y * a.y); // Calculate the magnitude of vector A
        //float magnitudeA = a.magnitude;
        //Vector2 aNormalized = a / magnitudeA; // Normalize vector A

        Vector2 aNormalized = a.normalized; // Normalize vector A - this is the preferred way in Unity
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(aNormalized, 0.1f);
        scalarProjection = Vector2.Dot(aNormalized, b); // Calculate the dot product
        Vector2 vectorProjection = aNormalized * scalarProjection; // Project vector A onto vector B
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(vectorProjection, 0.1f);
    }
}
