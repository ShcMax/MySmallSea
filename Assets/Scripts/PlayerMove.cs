using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public float moveSpeed;
    public float rotateSpeed;    

    private float vInput;
    private float hInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        transform.Translate(Vector3.forward *vInput * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up *hInput * rotateSpeed * Time.deltaTime);
    }

    //private void FixedUpdate()
    //{
    //    Vector3 rotation = Vector3.up * hInput;
    //    Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
    //    rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
    //    rb.MoveRotation(rb.rotation * angleRot);
    //}
}
