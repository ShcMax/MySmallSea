using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BoatDestinationFort : MonoBehaviour
{
    [SerializeField]
    Transform _fort;
    private NavMeshAgent boatWay;
    // Start is called before the first frame update
    private void Awake()
    {
        boatWay = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {        
        boatWay.destination = GameObject.FindGameObjectWithTag("Fort").transform.position;        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fort"))
        {
            Destroy(gameObject);
        }
    }
}
