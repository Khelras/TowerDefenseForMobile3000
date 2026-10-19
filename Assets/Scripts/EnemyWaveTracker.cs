using UnityEngine;

public class EnemyWaveTracker : MonoBehaviour
{
    private EnemySpawner m_spawner;

    public void SetSpawner(EnemySpawner spawner)
    {
        m_spawner = spawner;
    }

    private void OnDestroy()
    {
        if (m_spawner != null)
        {
            m_spawner.EnemyRemoved();
        }
    }
}
