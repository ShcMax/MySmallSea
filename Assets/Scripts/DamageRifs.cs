using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRifs : MonoBehaviour
{
    [SerializeField]
    private float _damage = 1;
    private Player rifsDamage;
    private float _timeDamage;
    private float cooldownDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeDamage += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _timeDamage > cooldownDamage)
        {
            _timeDamage = 0;
            rifsDamage = collision.gameObject.GetComponent<Player>();
            rifsDamage.GetDamageMine(_damage);
            Debug.Log(rifsDamage.PlayerHealth);
        }
    }
}
