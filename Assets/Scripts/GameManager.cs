using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Tutorial Variables
    [Header("Tutorial")]
    bool tutorialComplete;
    public Text[] tutTexts;
    public int speechIndex;
    public GameObject tutorialCanvas;
    public GameObject damageSplashScreen;
    public Text eSkip;
    public MouseLook[] mouselooks;

    //timer
    public float storyTimer;
    public float timer;
    float completeTimer = 4f;
    float moveTimer = 4;
    float extractTimer = 3;
    float followTimer = 0.5f;
    public bool runTimer;
    #endregion

    #region References
    PlayerMovment playerMove;
    PlayerStats playerStats;
    Weapon weapon;
    Enemy enemy;
    Wisp wisp;

    bool canLook;
    private bool learnedToWalk;
    private bool learnedToExtractHealth;
    public bool learnedToReload;
    public bool learnToShoot;
    public bool learnToMelee;
    #endregion
    void Start()
    {
        #region Tutorial
        SelectText(speechIndex);

        for (int i = 0; i < mouselooks.Length; i++)
        {
            mouselooks[i].enabled = false;
        }
        #endregion

        #region References
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovment>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        wisp = GameObject.Find("Wisp").GetComponent<Wisp>();
        weapon = GameObject.Find("Extraction_Rifle").GetComponent<Weapon>();
        enemy = GameObject.FindGameObjectWithTag("Crab").GetComponent<Enemy>();
        #endregion
    }

    void Update()
    {
        SelectText(speechIndex);
        #region Tutorial Input
        if (Input.GetKeyDown(KeyCode.E) && (speechIndex == 0 || speechIndex == 2 || speechIndex == 4 || speechIndex == 11))
        {
            // Skip to next speech in tutorial
            speechIndex++;
        }
        if (Input.GetKeyDown(KeyCode.E) && (speechIndex == 7))
        {
            // Skip to next speech in tutorial
            speechIndex++;
            timer = followTimer;
            runTimer = true;
            wisp.waypointIndex++;
        }
        if(speechIndex == 12)
        {
            tutorialComplete = true;
            tutorialCanvas.SetActive(false);
        }
        //if (Input.GetKeyDown(KeyCode.E) && (speechIndex == 11))
        //{
        //    Skip to next speech in tutorial
        //    tutorialComplete = true;
        //    tutorialCanvas.SetActive(false);
        //}
        #region Look Around
        // Look around
        // if mouse input
        if (!canLook && speechIndex == 1)
        {
            for (int i = 0; i < mouselooks.Length; i++)
            {
                mouselooks[i].enabled = true;
            }
            if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
            {
                // increase speechIndex
                speechIndex++;
                // set canLook to true
                canLook = true;
                Debug.Log("Mouse Movement");

            }
        }
        #endregion
        #region Learn to Walk
        // Learn to walk 
        if (!learnedToWalk)
        {
            if (speechIndex == 3)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    timer = moveTimer;
                    learnedToWalk = true;
                    playerMove.restrainMovement = false;
                    runTimer = true;
                    wisp.waypointIndex = +2;
                }
            }
        }
        #endregion
        #region Extract Health
        if (!learnedToExtractHealth && (speechIndex == 4 || speechIndex == 5))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Extract is now true
                timer = extractTimer;
                runTimer = true;
                wisp.waypointIndex++;
                learnedToExtractHealth = true;
            }
        }
        #endregion
        #region Learn to Reload
        if (!learnedToReload)
        {
            if (speechIndex == 6)
            {
                if (Input.GetKeyDown(KeyCode.R) && weapon.javAmmoCartridge > 0)
                {
                    //timer = followTimer;
                    //runTimer = true;
                    // wisp.waypointIndex++;
                    speechIndex++;
                    learnedToReload = true;
                }
            }
        }
        // After reload skip
        #endregion
        #region Learn to Shoot
        if (!learnToShoot)
        {
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.Mouse0) && speechIndex == 9)
            {
                //if (Enemy.enemyKillCount == 1)
                //{
                    wisp.waypointIndex++;
                    speechIndex++;
                    learnToShoot = true;
                //}
            }
        }
        #endregion
        #region Learn to Melee
        if(!learnToMelee)
        {
            playerMove.restrainMelee = false;
            if(Input.GetKeyDown(KeyCode.Mouse2))
            {
                timer = completeTimer;
                speechIndex++;
                wisp.waypointIndex++;
                learnToMelee = true;
            }
        }
        #endregion
        #region Timers
        if (runTimer == true)
        {
            storyTimer += Time.deltaTime;
            if (storyTimer >= timer)
            {
                speechIndex++;
                runTimer = false;
                storyTimer = 0;
            }
        }
        #endregion
        #endregion
        if((speechIndex ==1 || speechIndex == 3 || speechIndex == 6 || speechIndex == 9 ) && eSkip.enabled == true)
        {
            eSkip.enabled = false;
        }
        if ((speechIndex == 2 || speechIndex == 7 || speechIndex == 11 ) && eSkip.enabled == false)
        {
            eSkip.enabled = true;
        }
        if (Time.timeScale == 0)
        {
            tutorialCanvas.SetActive(false);
            damageSplashScreen.SetActive(false);
        }
            if (Time.timeScale == 1 && tutorialComplete == false)
            {
                tutorialCanvas.SetActive(true);
            }
            if(Time.timeScale == 1)
            {
                damageSplashScreen.SetActive(true);
            }

    }
    #region Tutorial Method
    void SelectText(int selectedIndex)
    {
        for (int i = 0; i < tutTexts.Length; i++)
        {
            tutTexts[i].enabled = false;
            if(i == selectedIndex)
            {
                tutTexts[i].enabled = true;
            }
        }
    }
    #endregion
}
