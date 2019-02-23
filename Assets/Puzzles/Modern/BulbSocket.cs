using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulbSocket
{
    public bool IsLighBulbOn;

    public bool IsBulbInSocket;

    public GameObject BulbGameObject;

    public BulbSocket(bool isLighBulbOn, bool isBulbInSocket)
    {
        this.IsLighBulbOn = isLighBulbOn;
        this.IsBulbInSocket = isBulbInSocket;
    }
}
