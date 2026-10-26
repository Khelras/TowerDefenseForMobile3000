using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour 
{
    private EnemyHealth m_target;
    private int m_damage;
    private float m_moveSpeed;

    public GameObject m_hitSpawnPrefab;
    public void Initialize(EnemyHealth target, int damage, float moveSpeed) 
    {
        this.m_target = target;
        this.m_damage = damage;
        this.m_moveSpeed = moveSpeed;
    }
    public void Update()
    {
        if (m_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_moveSpeed * Time.deltaTime);
            transform.LookAt(m_target.transform);

            if (Vector3.Distance(transform.position, m_target.transform.position) < 0.2f)
            {
                m_target.TakeDamage(m_damage);
                if (m_hitSpawnPrefab != null)
                Instantiate(m_hitSpawnPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
           
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
