using UnityEngine;

public class TowerControll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform m_target;
    [SerializeField] Transform m_head;
    [SerializeField] float m_rotationSpeed = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (m_target.position - m_head.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        m_head.rotation = Quaternion.Slerp(m_head.rotation, rotation, m_rotationSpeed * Time.deltaTime);
    }
}
