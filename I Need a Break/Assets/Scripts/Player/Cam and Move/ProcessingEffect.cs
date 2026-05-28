using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ProcessingEffect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PostProcessVolume postProcess;

    [SerializeField] private float maxValue;
    [SerializeField] private float addedValue;

    private float curValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
        UpdateIntensity();
    }

    private void Effect()
    {
        PlayerMovement playerMove = player.GetComponent<PlayerMovement>();

        if (playerMove)
        {
            curValue += addedValue * Time.deltaTime;
            if (curValue > maxValue)
            {
                curValue = maxValue;
            }
        }
        else
        {
            curValue += addedValue * Time.deltaTime;
            if (curValue > maxValue)
            {
                curValue = maxValue;
            }
        }
    }    

    private void UpdateIntensity()
    {
        
    }
}
