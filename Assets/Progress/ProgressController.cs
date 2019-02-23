using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    FadeController fadeController;
    private GameObject playerCharacter;
    int currentEpoch = 0;
    List<string> listOfEpochs = new List<string>() { "first", "second", "etc" };

    void Start()
    {
        playerCharacter = GameObject.Find("Player Character");
        print("Currently running epoch " + listOfEpochs[currentEpoch]);
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
        currentEpoch++;
        print("Currently running epoch " + listOfEpochs[currentEpoch]);
    }

    bool checkCurrentEpochChangeConditions()
    {
        if (currentEpoch == 0)
        {
            return isFirstEpochFinished();
        }
        else if (currentEpoch == 1)
        {
            return isSecondEpochFinished();
        }
        else
        {
            return false;
        }
    }

    bool isFirstEpochFinished()
    {
//        if (GameObject.Find("Typewriter").GetComponent<TypewriterScript>().isActive())
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

    IEnumerator waitFor(int time)
    {
        yield return new WaitForSeconds(time);
    }

}
