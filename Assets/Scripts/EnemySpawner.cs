using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab and spawn points
    [Header("Enemy Spawner Settings")]
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private Transform[] m_spawnPoint;

    // Enemy spawn settings
    [Header("Spawn Settings")]
    [SerializeField] private float m_spawnInterval = 2f;
    [SerializeField] private int m_maxEnemies = 10;

    [SerializeField] private Transform[] m_waypoints; // Array of waypoints for the enemies to follow 

    // private variables to keep track of the spawn timer and current enemy count
    private float m_spawnTimer = 0f;
    private float m_currentEnemyCount = 0;

    private void Update()
    {
        // Check if the current enemy count is less than the maximum allowed
        if (m_currentEnemyCount < m_maxEnemies)
        {
            m_spawnTimer += Time.deltaTime;
            // If the spawn timer exceeds the spawn interval, spawn a new enemy
            if (m_spawnTimer >= m_spawnInterval)
            {
                SpawnEnemy();
                m_spawnTimer = 0f;
            }
        }
    }

    private void SpawnEnemy()
    {
        //check if there are any spawn points available or if the enemy prefab is not assigned
        if (m_spawnPoint.Length == 0 || m_enemyPrefab == null)
        {
            Debug.LogWarning("No spawn points or enemy prefab assigned.");
            return;
        }

        // Randomly select a spawn point from the available spawn points
        int spawnIndex = Random.Range(0, m_spawnPoint.Length);
        Transform spawnPoint = m_spawnPoint[spawnIndex];
        GameObject enemy = Instantiate(m_enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Increment the current enemy count
        m_currentEnemyCount++;

        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        // Set the waypoints for the enemy to follow
        if (movement != null)
        {
            movement.SetWaypoints(m_waypoints);
        }
    }
}
