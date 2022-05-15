using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisit : MonoBehaviour
{
    [SerializeField]
    GameObject boat;
    [SerializeField]
    Transform boatSpawn;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var boomBoat = Instantiate(boat, boatSpawn.transform);
        }
    }
}
