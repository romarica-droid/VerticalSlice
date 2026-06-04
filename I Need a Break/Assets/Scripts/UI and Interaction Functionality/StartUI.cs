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
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
    }

    private void StartGame()
    {
        if(Input.GetKey(startButton))
        {
            Time.timeScale = 1.0f;
            Instantiate(startSong);
            Destroy(startUI);
        }
    }
}
