using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] GameObject menuPause;
    [SerializeField] Button continueGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
            menuPause.SetActive(true);
        }        
    }

    public void OnClickContinue()
    {
        Time.timeScale = 1;
        menuPause.SetActive(false);
    }
}
