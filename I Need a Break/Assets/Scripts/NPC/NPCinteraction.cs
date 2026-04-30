using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCinteraction : MonoBehaviour
{
    public delegate void GameStart();
    public event GameStart startUp;

    [Header("Dialogue Properties")]
    [SerializeField] private Button button;
    [SerializeField] private DialogueData curLines;
    [SerializeField] private TMP_Text diaText;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private PlayerCam cam;
    private int curLineIndex;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        curLineIndex = 0;

        
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
        Cursor.visible = true;
        playerRb.velocity = Vector3.zero;
        UpdateText();
    }

    public void AdvanceDialogue()
    {
        if (curLineIndex < curLines.lines.Length - 1)
        {
            curLineIndex++;
            UpdateText();
        }
        else
        {
            startUp?.Invoke();
        }
    }

    private void UpdateText()
    {
        diaText.text = curLines.lines[curLineIndex];
    }

}


