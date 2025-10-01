using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance { get; private set; }

    [SerializeField] private Transform[] wayPoints;


    void Awake()
    {
        //Singleton pattern -- Ensure only one wpManager exist

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    public Transform[] GetWayPoints()
    {
        return wayPoints;
    }

    void OnDrawGizmos()
    {
        if (wayPoints == null || wayPoints.Length == 0) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < wayPoints.Length; i++)
        {
            if (wayPoints[i] == null) continue;

            // Draw sphere at waypoint
            Gizmos.DrawWireSphere(wayPoints[i].position, 0.3f);

            // Draw line to next waypoint
            if (i < wayPoints.Length - 1 && wayPoints[i + 1] != null)
            {
                Gizmos.DrawLine(wayPoints[i].position, wayPoints[i + 1].position);
            }
        }
    }
}
