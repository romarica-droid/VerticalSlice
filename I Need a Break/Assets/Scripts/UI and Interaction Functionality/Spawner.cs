using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private void Start()
    {
        GameControllerLocator.Instance.Npc.startUp += SpawnPlayer;
    }

    private void SpawnPlayer()
    {
        player.transform.position = this.transform.position;
    }
}
