using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbSwitcher : InteractiveObject
{
    [SerializeField]
    private int switchNumber;

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    public bool isActive;
    
    public override void activate(GameObject activator)
    {
        isActive = !isActive;
        
        switch (switchNumber)
        {
            case 1:
                parent.GetComponent<LightBulbsPuzzle>().firstSwitch();
                break;
            case 2:
                parent.GetComponent<LightBulbsPuzzle>().secondSwitch();
                break;
            case 3:
                parent.GetComponent<LightBulbsPuzzle>().thirdSwitch();
                break;
            case 4:
                parent.GetComponent<LightBulbsPuzzle>().switchElectricity();
                break;
            case 5:
                //parent.GetComponent<LightBulbsPuzzle>().switchFourthBulb();
                break;
        }
        
        base.activate(activator);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
