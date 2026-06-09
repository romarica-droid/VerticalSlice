using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameControllerLocator : MonoBehaviour
{
    public static GameControllerLocator Instance { get; private set; }
    public NPCinteraction Npc { get; private set; }

    public delegate void GameStart();
    public event GameStart startgame;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject npcObject = GameObject.FindGameObjectWithTag("NPC");
        if(npcObject == null)
        {
            Debug.LogError("NPC: no thing found with thing yada yada");
            return;
        }
        Npc = npcObject.GetComponent<NPCinteraction>();
        
    }

    public void StartButtonPressed()
    {
        startgame?.Invoke();
    }
}
