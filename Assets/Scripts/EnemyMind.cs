using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMind : MonoBehaviour
{
    //private Animation enemyDead;
    [SerializeField]    
    public float enemyMaxHealth = 70;
    [SerializeField]
    Transform playerPos;
    //[SerializeField]
    //private float moveSpeed = 8; 
    //[SerializeField]
    //private float rotateSpeed = 2;
    [SerializeField]
    Transform[] patrolWay;

    private float _damage = 1;
    private float _damagePerSec = 0.2f;
    private Player playerDamage;
    private float _timeDamage;
    private float cooldownDamage = 1;

    private float stopDistance = 6f;

    private NavMeshAgent enemyPatrol;
    [SerializeField]
    private int zeroPatrolPoint = 1;


    private float _enemyHealth;
    public float EnemyHealth { get => _enemyHealth; }


    // Start is called before the first frame update

    private void Awake()
    {
        //enemyDead = GetComponent<Animation>();
        enemyPatrol = GetComponent<NavMeshAgent>();        
    }
    void Start()
    {        
        _enemyHealth = enemyMaxHealth;
        enemyPatrol.destination = patrolWay[zeroPatrolPoint].position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyPatrol.pathPending && enemyPatrol.remainingDistance < enemyPatrol.stoppingDistance + stopDistance)
        {
            zeroPatrolPoint = (zeroPatrolPoint + 1) % patrolWay.Length;
            enemyPatrol.destination = patrolWay[zeroPatrolPoint].position;
        }
        //if(playerPos != null)
        //{
        //    var dir = playerPos.position - enemyShipPos.position;
        //    var targetRot = Quaternion.LookRotation(dir.normalized);
        //    enemyShipPos.rotation = Quaternion.Lerp(enemyShipPos.rotation, targetRot, rotateSpeed * Time.deltaTime);
        //    enemyShipPos.position = Vector3.MoveTowards(enemyShipPos.position, playerPos.position, moveSpeed * Time.deltaTime);
        //}        
    }

    public void GetDamageCorePlayer(float damage)
    {
        _enemyHealth -= damage;
        if (EnemyHealth <= 0)        
        {
            //gameObject.transform.SetParent(null);            
            //enemyDead.Play();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPos = other.gameObject.transform;
            enemyPatrol.destination = playerPos.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPos = other.gameObject.transform;
            enemyPatrol.destination = playerPos.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDamage = collision.gameObject.GetComponent<Player>();
            playerDamage.GetDamageMine(_damage);
            Debug.Log(playerDamage.PlayerHealth);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _timeDamage > cooldownDamage)
            _timeDamage = 0;
            playerDamage = collision.gameObject.GetComponent<Player>();
            playerDamage.GetDamageMine(_damagePerSec);
            Debug.Log(playerDamage.PlayerHealth);
    }
}
