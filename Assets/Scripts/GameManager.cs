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
    public GameObject tutorialCanvas, skipCanvas;
    public GameObject damageSplashScreen;
    public Text eSkip;
    public MouseLook[] mouselooks;
    // Tutorial crabs
    public GameObject[] crabs;

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

    // skip tutorial
    bool skipTutorial;
    #endregion
    void Start()
    {
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

    }
}
