using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Serialized fields for waypoints and speed
    [SerializeField] private Transform[] m_waypoints;
    [SerializeField] private float m_speed = 2f;

    // private int to keep track of the current waypoint index
    private int m_currentWaypoint = 0;

    private void Update()
    {
        if (m_currentWaypoint >= m_waypoints.Length)
        {
            Destroy(gameObject); // Destroy the enemy if it has reached the last waypoint
            return;
        }

        // Get the current target waypoint
        Transform target = m_waypoints[m_currentWaypoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, m_speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            m_currentWaypoint++;
        }
    }
}
