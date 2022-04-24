using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCore : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("ShipPlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetDir = target.position - transform.position;
        
        transform.position = Vector3.MoveTowards(transform.position, targetDir, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ShipPlayer")
        {
            Destroy(gameObject);
        }
    }
}

