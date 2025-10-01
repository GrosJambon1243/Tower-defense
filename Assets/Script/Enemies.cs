using System;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Transform[] wayPoints;
    [SerializeField] private float speed;

    [SerializeField] private float wpReachBuffer = 0.1f;

    private int currentWpIndex = 0;

   
    void Start()
    {
        if (WaypointManager.Instance != null)
        {
            wayPoints = WaypointManager.Instance.GetWayPoints();
        }
    }


    void Update()
    {
        if (wayPoints == null || wayPoints.Length == 0) return;
        if (currentWpIndex >= wayPoints.Length)
        {
            ReachedEnd();
        }
        MoveTowardCurrentWaypoint();
        CheckReachedWp();
    
    }

    private void ReachedEnd()
    {
        Destroy(gameObject);
    }

    private void MoveTowardCurrentWaypoint()
    {
        Transform targetWp = wayPoints[currentWpIndex];

        transform.position = Vector2.MoveTowards(transform.position, targetWp.position, speed * Time.deltaTime);
    }

    private void CheckReachedWp()
    {
        float distanceToWp = Vector2.Distance(transform.position, wayPoints[currentWpIndex].position);

        if (distanceToWp < wpReachBuffer)
        {
            Debug.Log($"Reached WP {currentWpIndex + 1}");
            currentWpIndex++;
        }
    }
}
