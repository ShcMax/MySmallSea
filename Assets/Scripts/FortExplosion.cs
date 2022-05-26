using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FortExplosion : MonoBehaviour
{
    [SerializeField]
    GameObject gate_1, gate_2;
    [SerializeField]
    GameObject whiteFlag;
    [SerializeField]
    Transform whiteFlagPosition_1, whiteFlagPosition_2;
    private NavMeshObstacle _fort;

    private void Awake()
    {
        _fort = GetComponent<NavMeshObstacle>();
    }

    // Start is called before the first frame update    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            var flag_1 = Instantiate(whiteFlag, whiteFlagPosition_1);
            var flag_2 = Instantiate(whiteFlag, whiteFlagPosition_2);
            Destroy(gate_1);
            Destroy(gate_2);
            _fort.enabled = false;
        }
    }
}
