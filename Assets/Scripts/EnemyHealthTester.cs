using UnityEngine;

public class EnemyHealthTester : MonoBehaviour
{
    // damage amount to apply to the enemy
    [SerializeField] private float damageAmount = 6f;

    private void Update()
    {
        // Check for user input to apply damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyHealth enemy = FindFirstObjectByType<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
    }
}
