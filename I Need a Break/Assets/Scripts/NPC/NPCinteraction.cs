using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    [SerializeField] private Animator npcAnim;
    private State npcState;
    public bool isTalking;

    [SerializeField] private GameObject sign;

    public delegate void TimerStart();
    public event TimerStart timerStart;

    private enum State
    {
        idle, talking
    }

    private void UpdateState(State state)
    {
        switch(state)
        {
            case State.idle:
                npcState = State.idle;
                
                break;
            case State.talking:
                npcState = State.talking;
                isTalking = true;
                break;
        }
    }

    
    private void UpdateAnim()
    {
        if (npcState == State.idle)
        {
            npcAnim.SetBool("isTalking", false);
        }
        else if (npcState == State.talking)
        {
            npcAnim.SetBool("isTalking", true);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        curLineIndex = 0;
        UpdateState(State.idle);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnim();

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
        UpdateState(State.talking);
        sign.SetActive(false);
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
            CloseBox();
            MovePlayer();
        }
    }

    private void UpdateText()
    {
        diaText.text = curLines.lines[curLineIndex];
    }

    private void CloseBox()
    {
        curLineIndex = 0;
        dialogueBox.SetActive(false);
        cam.ResetSens();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateState(State.idle);
    }

    private void MovePlayer()
    {
        GameObject player = playerRb.gameObject;
        GameObject spawnPoint = GameObject.Find("Respawn Point"); 

        player.transform.position = spawnPoint.transform.position;
    }

    public bool TalkingBool()
    {
        return isTalking;   
    }

}


