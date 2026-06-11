using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class GameControllerLocator : MonoBehaviour
{
    public static GameControllerLocator Instance { get; private set; }
    public NPCinteraction Npc { get; private set; }
    public GameTimer PlayerTimer { get; private set; }

    public GameEnder Ender { get; private set; }

    public delegate void GameStart();
    public event GameStart startgame;

    [SerializeField] private GameObject loseSFX;
    [SerializeField] private GameObject winSFX;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject npcObject = GameObject.FindGameObjectWithTag("NPC");
        if (npcObject == null)
        {
            Debug.LogError("NPC: no thing found with thing yada yada");
            return;
        }
        Npc = npcObject.GetComponent<NPCinteraction>();

        GameObject playerUI = GameObject.Find("PlayerUI");
        if (npcObject == null)
        {
            Debug.LogError("Player UI: no thing found with yada yada");
            return;
        }
        PlayerTimer = playerUI.GetComponent<GameTimer>();

        GameObject gameFinish = GameObject.Find("Game Ender");
        if (gameFinish == null)
        {
            Debug.LogError("GameFinish: no thing found with yada yada");
            return;
        }
        Ender = gameFinish.GetComponent<GameEnder>();
    }

    private void Start()
    {
        Instance.PlayerTimer.loseGame += PlayLoseSFX;
        Instance.Ender.gameWin += PlayWinSFX;
    }

    public void StartButtonPressed()
    {
        startgame?.Invoke();
    }

    private void PlayLoseSFX()
    {
        
        Destroy(GameObject.Find("LevelMusic(Clone)"));

        Instantiate(loseSFX);
    }

    private void PlayWinSFX()
    {
        Destroy(GameObject.Find("LevelMusic(Clone)"));

        Instantiate(winSFX);
    }
}
