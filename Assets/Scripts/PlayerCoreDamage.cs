using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoreDamage : MonoBehaviour
{
    [SerializeField]
    private float _damage = 10;
    private EnemyMind enemyDamage;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyShip"))
        {
            enemyDamage = collision.gameObject.GetComponent<EnemyMind>();
            enemyDamage.GetDamageCorePlayer(_damage);
            Debug.Log(enemyDamage.EnemyHealth);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Land"))
        {
            Destroy(gameObject);
        }
    }
}
