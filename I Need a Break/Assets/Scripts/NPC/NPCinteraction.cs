using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPCinteraction : MonoBehaviour
{


    [Header("Dialogue Properties")]
    [SerializeField] private DialogueData lines;
    [SerializeField] private TMP_Text diaText;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private PlayerCam cam;



    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 

    }

    private void OnMouseDown()
    {
        OpenBox();
    }

    private void OpenBox()
    {
        dialogueBox.SetActive(true);
        cam.StopRotating();
        Cursor.lockState = CursorLockMode.None;
        playerRb.velocity = Vector3.zero;
    }
}


