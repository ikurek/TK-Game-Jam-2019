using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Progress;

public class ProgressController : MonoBehaviour
{

    private RoomManager roomManager;
    private GameObject playerCharacter;
    private Epoch currentEpoch = Epoch.Intro;

    void Start() {
        roomManager = FindObjectOfType<RoomManager>();
        if (roomManager == null) {
            Debug.LogError("No RoomManager found in scene");
        }
        playerCharacter = GameObject.Find("Player Character");
        updateTheme();
        print("Currently running epoch " + EpochUtil.epochName(currentEpoch));
        tryChangeEpoch();
    }

    void lockPlayerAndChangeUI()
    {
        playerCharacter.SetActive(false);
        
        FadeController.Instance.FadeOut(1.0f, Color.black, () =>
        {
            updateTheme();
            FadeController.Instance.FadeIn(1.0f, Color.black);
            
        });
    }

    void updateTheme()
    {
        roomManager.prepareEpoch(currentEpoch);

    }

    public void tryChangeEpoch()
    {
        if (checkCurrentEpochChangeConditions())
        {
            changeEpoch();
        }
    }

    void changeEpoch()
    {   
        lockPlayerAndChangeUI();
        currentEpoch = EpochUtil.next(currentEpoch);
        print("Currently running epoch " + EpochUtil.epochName(currentEpoch));
    }

    bool checkCurrentEpochChangeConditions()
    {
        switch (currentEpoch) {
            case Epoch.Intro: return isIntroEpochFinished();
            case Epoch.First: return isFirstEpochFinished();
            case Epoch.Second: return isSecondEpochFinished();
            default: return false;
        }
    }

    bool isIntroEpochFinished() {
        return true;
    }

    bool isFirstEpochFinished() {
        //return true; // Test
        /*
        if (GameObject.Find("rynna starozytnosc").GetComponent<RynnaScript>().isActive())
        {
            return true;
        }
        else
        {
            return false;
        }
        */
        return false;
    }

    bool isSecondEpochFinished()
    {
        return false;
    }

}
