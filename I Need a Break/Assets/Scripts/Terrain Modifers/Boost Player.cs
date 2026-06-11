using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoostPlayer : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost()
    {
        float tempWalk = player.walkSpeed;
        float tempSprint = player.sprintSpeed;

        player.walkSpeed *= 2;
        player.sprintSpeed *= 2;

        yield return new WaitForSeconds(3);

        player.walkSpeed = tempWalk;
        player.sprintSpeed = tempSprint;
    }
}
