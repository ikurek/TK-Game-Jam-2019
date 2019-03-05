using System.Collections.Generic;
using ChronoPuzzle.Gamestate.Progress;
using UnityEngine;

namespace ChronoPuzzle.Puzzles.Modern {

    public class LightBulbsPuzzle : MonoBehaviour
    {
        [SerializeField]
        private List<BulbSocket> socketList;

    
        [SerializeField]
        private float electricityPowerOnFactor = 0.2f;
        [SerializeField]
        private float electricityPowerOffFactor = 0.8f;
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
                socket.bulbGameObject.GetComponent<SpriteRenderer>().color = colorOff;
            }

            targetColor = colorOff;
        }


        void TestingOnKeykodes()
        {
        
//        Debug.Log("keycode");
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
            socketList[0].isLighBulbOn = !socketList[0].isLighBulbOn;
            Debug.Log("light 0 is" + socketList[0].isLighBulbOn);
        }
    
        private void switchSecondBulb()
        {
            socketList[1].isLighBulbOn = !socketList[1].isLighBulbOn;
            Debug.Log("light 1 is" + socketList[1].isLighBulbOn);
        }
    
        private void switchThirdBulb()
        {
            socketList[2].isLighBulbOn = !socketList[2].isLighBulbOn;
            Debug.Log("light 2 is" + socketList[2].isLighBulbOn);
        }
    
        private void switchFourthBulb()
        {
            socketList[3].isLighBulbOn = !socketList[3].isLighBulbOn;
            Debug.Log("light 3 is" + socketList[3].isLighBulbOn);
        }
    
        public void switchElectricity()
        {
            isElectricityOn = !isElectricityOn;
            Debug.Log("electricity is" + isElectricityOn);
        }
    
        public void allBulbsAtSocket()
        {
            foreach (BulbSocket bulbSocket in socketList)
            {
                socketList[3].isBulbInSocket = true;
                Debug.Log("electricity is" + isElectricityOn);
            }
        }

        public bool checkAllSocketsForWin()
        {
            foreach (var socket in socketList)
            {
                if (socket.bulbGameObject.GetComponent<SpriteRenderer>().color != colorOn)
                {
                    return false;
                }
            }
        
            Debug.Log("win");
            return true;
        }
    
    
        // Update is called once per frame
        void Update()
        {
        
//        TestingOnKeykodes();
//        Debug.Log("update");
        
            foreach (var socket in socketList)
            {
                t = 0;
            
                if (!socket.isBulbInSocket)
                {
                    targetColor = colorOff;
                    t += Time.deltaTime / electricityPowerOffFactor;
                }
                else
                {
                    if (isElectricityOn)
                    {
                        if (socket.listOfNeededSwitches.Count==0)
                        {
                            if (socket.isLighBulbOn)
                            {
                                targetColor = colorOn;
                                t += Time.deltaTime / electricityPowerOnFactor;
                            }
                            else
                            {
                                targetColor = colorOff;
                                t += Time.deltaTime / electricityPowerOffFactor;
                            }
                        }
                        else
                        {
                            bool allSwitches = true;
                            foreach (GameObject socketListOfNeededSwitch in socket.listOfNeededSwitches)
                            {
                                if (!socketListOfNeededSwitch.GetComponent<BulbSwitcher>().isActive)
                                {
                                    allSwitches = false;
                                }
                            }

                            if (allSwitches)
                            {
                                if (socket.isLighBulbOn)
                                {
                                    targetColor = colorOn;
                                    t += Time.deltaTime / electricityPowerOnFactor;
                                }
                                else
                                {
                                    targetColor = colorOff;
                                    t += Time.deltaTime / electricityPowerOffFactor;
                                }
                            }
                            else
                            {
                                targetColor = colorOff;
                                t += Time.deltaTime / electricityPowerOffFactor; 
                            }
                        }
                    }
                    else
                    {
                        targetColor = colorOff;
                        t += Time.deltaTime / electricityPowerOffFactor;
                    }
                }
            
                socket.bulbGameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(socket.bulbGameObject.GetComponent<SpriteRenderer>().color,targetColor,t);

            }

            // really?
            //GameObject.Find("ProgressObject").GetComponent<ProgressController>().advanceIfPossible();
            
            
            //checkAllSocketsForWin();
        }
    }

}
