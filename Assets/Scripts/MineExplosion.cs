using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    [SerializeField]
    private float _damage = 20;
    private Player playerDamage;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDamage = other.gameObject.GetComponent<Player>();
            playerDamage.GetDamageMine(_damage);
            Debug.Log(playerDamage.PlayerHealth);
            Destroy(gameObject);
        }
    }
    

}
