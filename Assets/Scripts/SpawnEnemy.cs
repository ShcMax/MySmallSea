using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]

    GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        var shipEnemy = Instantiate(ship, transform);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
