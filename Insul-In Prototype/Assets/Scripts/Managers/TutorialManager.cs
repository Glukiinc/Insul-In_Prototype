using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private GameObject playerHudCanvas;
    [SerializeField] private GameObject controlCanvas;

    [SerializeField] private GameObject bslLabel;
    [SerializeField] private GameObject bslNumber;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject bloodSugarLevel;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject insulinBall;
    [SerializeField] private GameObject insulinLauncher;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject paddle;

    [SerializeField] private GameObject glukis;
    [SerializeField] private GameObject glukiSpawner;

    [SerializeField] private Dialogue dialogueList;
    [SerializeField] private GameObject textObject;

    private DialogueWindow dialogueWindow;

    public int tutorialStep;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueWindow = textObject.GetComponent<DialogueWindow>();
        playerHudCanvas = GameObject.Find("PlayerHUDCanvas");
        controlCanvas = GameObject.Find("ControlCanvas");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckLines();
        // Debug.Log(tutorialStep);
    }

    void PlayVoice()
    {
        audioManager.PlayAudio(tutorialStep + 1);
    }

    void CheckLines()
    {
        PlayVoice();

        tutorialStep = dialogueWindow.step;
        if (tutorialStep == 2)
        {
            glukis.SetActive(true);
            glukiSpawner.SetActive(true);
        }
        if (tutorialStep == 4)
        {
            insulinBall.SetActive(true);
        }
        if (tutorialStep == 5)
        {
            playerHudCanvas.GetComponent<Canvas>().sortingOrder = 1;
            bslLabel.SetActive(true);
            bslNumber.SetActive(true);
        }
        if (tutorialStep == 6)
        {
            controlCanvas.GetComponent<Canvas>().sortingOrder = 1;
            ammo.SetActive(true);
            insulinLauncher.SetActive(true);
        }
        if (tutorialStep == 7)
        {
            controlCanvas.GetComponent<Canvas>().sortingOrder = 1;
            paddle.SetActive(true);
        }
        if (tutorialStep == 8)
        {
            left.SetActive(true);
            right.SetActive(true);
        }
        if (tutorialStep == 10)
        {
            timer.SetActive(true);
        }
        if (tutorialStep == 11)
        {
            bloodSugarLevel.SetActive(true);
        }
        if (tutorialStep == 13)
        {
            SceneManager.LoadScene(1);
        }
    }
}
