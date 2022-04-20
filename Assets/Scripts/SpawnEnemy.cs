using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]

    private GameObject enemyShip;
    // Start is called before the first frame update
    void Start()
    {
        var enemy =  Instantiate(enemyShip, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
