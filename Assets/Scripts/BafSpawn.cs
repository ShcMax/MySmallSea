using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BafSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject baff;
    
    // Start is called before the first frame update
    void Start()
    {
       Instantiate(baff, transform);
    }

    
}
