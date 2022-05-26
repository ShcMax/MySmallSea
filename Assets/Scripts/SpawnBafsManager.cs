using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBafsManager : MonoBehaviour
{
    [SerializeField]
    GameObject bafs;    
    [SerializeField]
    List<Transform> posBafs;
    // Start is called before the first frame update
    void Start()
    {      
        foreach (var posBaf in posBafs)
        {
            Instantiate(bafs, posBaf.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
