using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{

    private enum Epoch {
        First,
        Second,
        Third,
        Final
    }

    FadeController fadeController;
    private GameObject playerCharacter;
    private Epoch currentEpoch = Epoch.First;

    void Start()
    {
        playerCharacter = GameObject.Find("Player Character");
        print("Currently running epoch " + epochName(currentEpoch));
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
        // TODO: Change UI
        playerCharacter.SetActive(true);

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
        currentEpoch = next(currentEpoch);
        print("Currently running epoch " + epochName(currentEpoch));
    }

    bool checkCurrentEpochChangeConditions()
    {
        switch (currentEpoch) {
            case Epoch.First: return isFirstEpochFinished();
            case Epoch.Second: return isSecondEpochFinished();
            default: return false;
        }
    }

    bool isFirstEpochFinished()
    {
//        if (GameObject.Find("rynna starozytnosc").GetComponent<RynnaScript>().isActive())
//        {
//            return true;
//
//        }
//        else
//        {
//            return false;
//        }
        return false;
    }

    bool isSecondEpochFinished()
    {
        return false;
    }

    private string epochName(Epoch epoch) {
        switch (epoch) {
            case Epoch.First: return "First";
            case Epoch.Second: return "Second";
            case Epoch.Third: return "Third";
            case Epoch.Final: return "Final";
            default: return "You Forgot To Give It A Name, Dummy";
        }
    }

    private Epoch next(Epoch epoch) {
        switch (epoch) {
            case Epoch.First: return Epoch.Second;
            case Epoch.Second: return Epoch.Third;
            case Epoch.Third: return Epoch.Final;
            default: throw new NotImplementedException("No epoch to progress to");
        }
    }
    
    IEnumerator waitFor(int time)
    {
        yield return new WaitForSeconds(time);
    }

}
