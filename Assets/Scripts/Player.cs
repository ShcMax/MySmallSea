using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject welcom;
    [SerializeField] Button begin;
    [SerializeField] GameObject defeatMenu;
    [SerializeField] Button againPlay;
    [SerializeField]
    public float playerMaxHealth = 100;
    public float moveSpeed;
    public float rotateSpeed; 
    private float vInput;
    private float hInput;

    public Action<float> changeHealth; // ??????? ??? ??????????? ??????????? ????????

    [SerializeField] AudioSource fireCannonMusicLeft;
    [SerializeField] AudioSource fireCannonMusicRight;

    [SerializeField] ParticleSystem fireLeft;
    [SerializeField] ParticleSystem fireRight;

    #region ???? ? ????????
    [SerializeField]
    private GameObject core;
    [SerializeField]
    private Transform cannonRight, cannonLeft;
    public float powerFire = 30;

    // ??????????? 
    private float _timerRechargeRight;
    private float _timerRechargeLeft;
    private float _timer = 2;
    #endregion    

    private float _playerHealth;
    private float _playerMove;
    private float _playerRotate;
    public float PlayerHealth { get => _playerHealth; }
    public float PlayerMove { get => _playerMove; }
    public float PlayerRotate { get => _playerRotate; }

    public float PlayerMaxHealth => playerMaxHealth; // ???????? ??? ??????????? ????????
    private void Awake()
    {
        _playerHealth = playerMaxHealth;
    }
    private void Start()
    {
        _playerMove = moveSpeed;
        _playerRotate = rotateSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        _timerRechargeRight += Time.deltaTime;
        _timerRechargeLeft += Time.deltaTime;
        MovementPlayer();
        FireCannonPlayer();        
    }
    public void GetDamageMine(float damage) //???? ?? ????
    {
        _playerHealth -= damage;
        changeHealth?.Invoke(_playerHealth);
        if(_playerHealth <= 0)
        {
            defeatMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }    
    public void GetBaff (float move, float rotate) //?????? ???? ?? ???????? ? ???????
    {
        _playerMove += move;
        _playerRotate += rotate;
    }    
    public void MovementPlayer() // ???????? ??????
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
    public void FireCannonPlayer() // ????????
    {
        var rayShootRigth = new Ray(cannonRight.position, cannonRight.forward);
        var rayShootLeft = new Ray(cannonLeft.position, cannonLeft.forward);
        //Debug.DrawRay(cannonRight.position, cannonRight.forward * 100, Color.green);
        //Debug.DrawRay(cannonLeft.position, cannonLeft.forward * 100, Color.green);

        if (Input.GetMouseButtonDown(1) && _timerRechargeRight > _timer)
        {            
            _timerRechargeRight = 0;
            fireCannonMusicRight.Play();
            fireRight.Play();
            GameObject rightCore = Instantiate(core, cannonRight.position, Quaternion.identity);            
            rightCore.GetComponent<Rigidbody>().AddForce(rayShootRigth.direction * powerFire, ForceMode.Impulse);
            Destroy(rightCore, 5f);
        }

        if (Input.GetMouseButtonDown(0) && _timerRechargeLeft > _timer)
        {            
            _timerRechargeLeft = 0;
            fireCannonMusicLeft.Play();
            fireLeft.Play();
            GameObject leftCore = Instantiate(core, cannonLeft.position, Quaternion.identity);            
            leftCore.GetComponent<Rigidbody>().AddForce(rayShootLeft.direction * powerFire, ForceMode.Impulse);
            Destroy(leftCore, 5f);
        }        
    }
    public void OnClickAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
