using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbsPuzzle : MonoBehaviour
{
    [SerializeField]
    private List<BulbSocket> socketList;

//    [SerializeField]
//    private List<GameObject> socketGameObjectList;
    
    [SerializeField]
    private float electricity = 0;
    [SerializeField]
    private float electricityPowerOnFactor = 0.2f;
    [SerializeField]
    private float t = 0;
    [SerializeField] 
    private bool isElectricityOn = false;

    [SerializeField]
    private Color colorOn;
    [SerializeField]
    private Color colorOff;
    private Color targetColor;
    

    private void Awake()
    {
//        socketList.Add(new BulbSocket(false,false));
//        socketList.Add(new BulbSocket(false,true));
//        socketList.Add(new BulbSocket(false,false));
//        socketList.Add(new BulbSocket(true,true));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (BulbSocket socket in socketList)
        {
            socket.BulbGameObject.GetComponent<SpriteRenderer>().color = colorOff;
        }

        targetColor = colorOff;
    }


    void TestingOnKeykodes()
    {
        
        Debug.Log("keycode");
        if (Input.GetKeyDown(KeyCode.U))
        {
            firstSwitch();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            secondSwitch();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            thirdSwitch();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            isElectricityOn = !isElectricityOn;
        }

        t = 0;

    }
    
    public void firstSwitch()
    {
        switchFirstBulb();
        switchThirdBulb();
    }
    
    public void secondSwitch()
    {
        switchFirstBulb();
        switchSecondBulb();
        switchFourthBulb();
    }
    
    public void thirdSwitch()
    {
        switchThirdBulb();
        switchFourthBulb();
    }

    private void switchFirstBulb()
    {
        socketList[0].IsLighBulbOn = !socketList[0].IsLighBulbOn;
        Debug.Log("light 0 is" + socketList[0].IsLighBulbOn);
    }
    
    private void switchSecondBulb()
    {
        socketList[1].IsLighBulbOn = !socketList[1].IsLighBulbOn;
        Debug.Log("light 1 is" + socketList[1].IsLighBulbOn);
    }
    
    private void switchThirdBulb()
    {
        socketList[2].IsLighBulbOn = !socketList[2].IsLighBulbOn;
        Debug.Log("light 2 is" + socketList[2].IsLighBulbOn);
    }
    
    private void switchFourthBulb()
    {
        socketList[3].IsLighBulbOn = !socketList[3].IsLighBulbOn;
        Debug.Log("light 3 is" + socketList[3].IsLighBulbOn);
    }

    // Update is called once per frame
    void Update()
    {
        
        TestingOnKeykodes();
        Debug.Log("update");
        
        foreach (var socket in socketList)
        {
            if (!socket.IsBulbInSocket)
            {
                targetColor = colorOff;
            }
            else
            {
                if (isElectricityOn)
                {
                    if (socket.IsLighBulbOn)
                    {
                        targetColor = colorOn;
                    }
                    else
                    {
                        targetColor = colorOff;
                    }
                }
                else
                {
                    targetColor = colorOff;
                }
            }

            t += Time.deltaTime / electricityPowerOnFactor;
            socket.BulbGameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(socket.BulbGameObject.GetComponent<SpriteRenderer>().color,targetColor,t);

        }
    }
}
