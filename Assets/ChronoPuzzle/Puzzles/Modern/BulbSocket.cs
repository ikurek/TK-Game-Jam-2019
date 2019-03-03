using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulbSocket
{
    public bool isLighBulbOn;

    public bool isBulbInSocket;

    public GameObject bulbGameObject;

    public List<GameObject> listOfNeededSwitches;

    public BulbSocket(bool isLighBulbOn, bool isBulbInSocket)
    {
        this.isLighBulbOn = isLighBulbOn;
        this.isBulbInSocket = isBulbInSocket;
    }
}
