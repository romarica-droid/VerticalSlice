using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private GameObject Player;

    private PlayerMovement playerMove;

    private float curValue;
    [SerializeField] private float maxValue;


    void Start()
    {
        playerMove = Player.GetComponent<PlayerMovement>();
    }


    void Update()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        curValue = playerMove.moveSpeed;

        speedSlider.value = curValue;
    }
}
