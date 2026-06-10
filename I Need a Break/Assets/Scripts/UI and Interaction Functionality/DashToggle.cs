using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashToggle : MonoBehaviour
{
    [SerializeField] private TMP_Text dashTest;

    [SerializeField] private Image dashImage;

    [SerializeField] private PlayerMovement playerMove;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateDashIcon();
    }

    private void UpdateDashIcon()
    {
        if (playerMove.canBoost)
        {
            dashImage.color = Color.green;
            dashTest.text = "Dash: Ready";
        }
        else
        {
            dashImage.color = Color.grey;
            dashTest.text = "Dash: Charging";
        }
    }

}
