using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] GameObject menuPause;
    [SerializeField] Button continueGame;
    [SerializeField] Button returnGameMenu;
    [SerializeField] GameObject welcom;
    [SerializeField] Button begin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
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

    public void ReturnGameMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ClickBeginButton()
    {
        welcom.SetActive(false);
    }

}
