using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BafSpeed : MonoBehaviour
{
    [SerializeField] 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //var controllerBuf = other.gameObject.GetComponent<PlayerMove>();
            //controllerBuf.GetBaf(bafSpeed);
            Destroy(gameObject);
        }        
    }
    
}
