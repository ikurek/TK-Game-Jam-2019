using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbSwitcher : InteractiveObject
{
    [SerializeField]
    private int switchNumber;

    [SerializeField]
    private GameObject parent;
    
    public override void activate(GameObject activator)
    {
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
