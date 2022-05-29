using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisit : MonoBehaviour
{
    [SerializeField]
    GameObject boat;
    [SerializeField]
    Transform boatSpawn;
    [SerializeField] BoxCollider box;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            var boomBoat = Instantiate(boat, boatSpawn.transform);
            box.enabled = false;
        }
    }
}
