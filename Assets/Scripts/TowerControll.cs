using UnityEngine;

public enum TurretState 
{
    Idle,
    Shoot,
}
public class TowerControll : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject m_target;
    [SerializeField] Transform m_head;
    [SerializeField] float m_rotationSpeed = 1.0f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
          
            //TrackEnemy();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
        }
    }
    private void TrackEnemy()
    {
        Vector3 direction = (m_target.transform.position - m_head.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        m_head.rotation = Quaternion.Slerp(m_head.rotation, rotation, m_rotationSpeed * Time.deltaTime);
    }
}
