using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    FadeController fadeController;
    int currentEpoch = 0;
    List<string> listOfEpochs = new List<string>() { "first", "second", "etc" };

    void Start()
    {
        fadeController = FadeController.Instance;
    }

    void fadeIn()
    {
        fadeController.FadeIn(1.0f, Color.black);
    }

    void fadeOut()
    {
        fadeController.FadeOut(1.0f, Color.black);
    }

    void tryChangeEpoch()
    {
        if (checkCurrentEpochChangeConditions())
        {
            changeEpoch();
        }
    }

    void changeEpoch()
    {
        // TODO
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
        return true;
    }

    bool isSecondEpochFinished()
    {
        return false;
    }

}
