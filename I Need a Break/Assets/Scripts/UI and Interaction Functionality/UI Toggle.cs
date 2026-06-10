using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);

        GameControllerLocator.Instance.startgame += ToggleUI;
    }

    private void ToggleUI()
    {
        this.gameObject.SetActive(true);
    }
}
