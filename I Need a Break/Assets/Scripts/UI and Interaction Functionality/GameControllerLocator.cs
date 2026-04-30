using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerLocator : MonoBehaviour
{
    public static GameControllerLocator Instance { get; set; }
    public NPCinteraction npc { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        GameObject npcObject = GameObject.FindGameObjectWithTag("NPC");
        if(npcObject == null)
        {
            Debug.LogError("NPC: no thing found with thing yada yada");
            return;
        }
        npc = npcObject.GetComponent<NPCinteraction>();
    }
}
