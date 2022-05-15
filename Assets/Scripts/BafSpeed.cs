using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BafSpeed : MonoBehaviour
{
    [SerializeField]    
    private float _move = 4f;
    [SerializeField]
    private float _rotate = 2.5f;
    [SerializeField]
    public float speedRotate = 1;

    private Player playerGetBaff;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerGetBaff = other.gameObject.GetComponent<Player>();
            playerGetBaff.GetBaff(_move, _rotate);
            Debug.Log(playerGetBaff.PlayerMove);
            Debug.Log(playerGetBaff.PlayerRotate);
            Destroy(gameObject);
        }        
    }

    private void Update()
    {
        transform.Rotate(0, speedRotate * Time.deltaTime, 0, Space.Self);
    }

}
