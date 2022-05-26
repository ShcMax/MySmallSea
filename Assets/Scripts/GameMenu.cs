using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    Button playGame, exitGame;

    // Start is called before the first frame update
    void Start()
    {
        playGame.onClick.AddListener(OnButtonPlay);
        exitGame.onClick.AddListener(OnButtonExit);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonPlay()
    {
        SceneManager.LoadScene(1);
    }
    void OnButtonExit()
    {
        Application.Quit();
    }
}
