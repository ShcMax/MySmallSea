using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMines : MonoBehaviour
{
    [SerializeField]
    private GameObject mine;
    // Start is called before the first frame update
    void Start()
    {
        var spawnMine = Instantiate(mine, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
