using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private KeyCode startButton;
    [SerializeField] private GameObject startSong;


    

    void Start()
    {
        

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

        GameControllerLocator.Instance.startgame += StartGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1.0f;
            Instantiate(startSong);
            Destroy(startUI);
    }

}
