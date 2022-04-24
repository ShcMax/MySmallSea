using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField]    
    public float moveSpeed;
    public float rotateSpeed; 
    private float vInput;
    private float hInput;

    private float newSpeed = 1;
    private float newRotate = 0.5f;    

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * vInput * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.zero);
        }     
        transform.Rotate(Vector3.up *hInput * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Baff"))
        {
            moveSpeed += newSpeed;
            rotateSpeed += newRotate;
        }
    }

    
}
