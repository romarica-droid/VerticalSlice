using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private GameObject uiThing;

    void Start()
    {
        uiThing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0.0f;
            uiThing.SetActive(true);
        }
    }
}
