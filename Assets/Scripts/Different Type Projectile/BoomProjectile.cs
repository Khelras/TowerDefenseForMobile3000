using UnityEngine;

public class BoomProjectile : MonoBehaviour
{
    private EnemyHealth m_target;
    private int m_damage;
    private float m_moveSpeed;
    private float m_blastRadius;

    public GameObject m_hitSpawnPrefab;
    
    public void Initialize(EnemyHealth target, int damage, float moveSpeed, float blastRadius)
    {
        this.m_target = target;
        this.m_damage = damage;
        this.m_moveSpeed = moveSpeed;
        this.m_blastRadius = blastRadius;
    }
    public void Update()
    {
        if (m_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_moveSpeed * Time.deltaTime);
            transform.LookAt(m_target.transform);

            if (Vector3.Distance(transform.position, m_target.transform.position) < 0.2f)
            {
                Explode();
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Explode() 
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, m_blastRadius);

        foreach (Collider hit in hits)
        {
            EnemyHealth enemy = hit.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(m_damage);
            }
        }

        if (m_hitSpawnPrefab != null)
            Instantiate(m_hitSpawnPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
