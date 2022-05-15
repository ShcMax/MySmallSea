using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    public float playerMaxHealth = 100;
    public float moveSpeed;
    public float rotateSpeed; 
    private float vInput;
    private float hInput;

    #region Ядра и стрельба
    [SerializeField]
    private GameObject core;
    [SerializeField]
    private Transform cannonRight, cannonLeft;
    public float powerFire = 30;
    #endregion


    private float _playerHealth;
    private float _playerMove;
    private float _playerRotate;
    public float PlayerHealth { get => _playerHealth; }
    public float PlayerMove { get => _playerMove; }
    public float PlayerRotate { get => _playerRotate; }

    private void Start()
    {
        _playerHealth = playerMaxHealth;
        _playerMove = moveSpeed;
        _playerRotate = rotateSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        FireCannonPlayer();        
    }
    public void GetDamageMine(float damage) //Урон от мины
    {
        _playerHealth -= damage;
        if(PlayerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }    
    public void GetBaff (float move, float rotate) //Подбор бафа на скорость и поворот
    {
        _playerMove += move;
        _playerRotate += rotate;
    }    
    public void MovementPlayer() // Движение игрока
    {
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * vInput * _playerMove * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.zero);
        }
        transform.Rotate(Vector3.up * hInput * _playerRotate * Time.deltaTime);
    }
    public void FireCannonPlayer() // Стрельба
    {
        var rayShootRigth = new Ray(cannonRight.position, cannonRight.forward);
        var rayShootLeft = new Ray(cannonLeft.position, cannonLeft.forward);
        //Debug.DrawRay(cannonRight.position, cannonRight.forward * 100, Color.green);
        //Debug.DrawRay(cannonLeft.position, cannonLeft.forward * 100, Color.green);

        if (Input.GetMouseButtonDown(1))
        {
            GameObject rightCore = Instantiate(core, cannonRight.position, Quaternion.identity);            
            rightCore.GetComponent<Rigidbody>().AddForce(rayShootRigth.direction * powerFire, ForceMode.Impulse);
            Destroy(rightCore, 5f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject leftCore = Instantiate(core, cannonLeft.position, Quaternion.identity);            
            leftCore.GetComponent<Rigidbody>().AddForce(rayShootLeft.direction * powerFire, ForceMode.Impulse);
            Destroy(leftCore, 5f);
        }
    }
}
