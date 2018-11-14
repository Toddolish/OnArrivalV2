using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Tutorial")]
    public Text[] tutTexts;
    public int speechIndex;
    void Start()
    {
        SelectText(speechIndex);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            // Skip to next speech in tutorial
            speechIndex++;
            SelectText(speechIndex);
        }
    }

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
}
