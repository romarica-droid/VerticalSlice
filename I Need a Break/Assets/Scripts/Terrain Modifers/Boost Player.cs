using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoostPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;

    private float orgWalkSpeed = 0;
    private float orgSprintSpeed = 0;

    private bool boost;

    void Start()
    {
        resetPlayerSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if(boost)
        {
            boostPlayer();

            float time = 0;

            if(time > 3)
            {
                resetPlayerSpeed();
                boost = false;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        boost = true;
    }

    private void boostPlayer()
    {
        PlayerMovement pMove = player.GetComponent<PlayerMovement>();

        pMove.SetWalkSpeed(orgWalkSpeed * 2);
        pMove.SetWalkSpeed(orgSprintSpeed * 2);

    }

    private void resetPlayerSpeed()
    {
        orgWalkSpeed = player.GetComponent<PlayerMovement>().GetWalkSpeed();
        orgSprintSpeed = player.GetComponent<PlayerMovement>().GetWalkSpeed();
    }
}
