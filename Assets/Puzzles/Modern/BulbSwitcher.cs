﻿using System.Collections;
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

    private bool pickable = false;
    
    public override GameObject pickup(GameObject parentGameObject)
    {
        if (pickable)
        {
            base.playSound("Sound/pick_wood");
            return base.pickup(parentGameObject);
        }
        else
        {
            return null;
        }
    }
    
    
    public override void activate(GameObject activator)
    {
        isActive = !isActive;

        
        
        switch (switchNumber)
        {
            case 1:
                parent.GetComponent<LightBulbsPuzzle>().firstSwitch();
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                break;
            case 2:
                parent.GetComponent<LightBulbsPuzzle>().secondSwitch();
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                break;
            case 3:
                parent.GetComponent<LightBulbsPuzzle>().thirdSwitch();
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                break;
            case 4:
                parent.GetComponent<LightBulbsPuzzle>().switchElectricity();
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                break;
            case 5:
                //parent.GetComponent<LightBulbsPuzzle>().switchFourthBulb();
                break;
        }
        
        base.activate(activator);
    }

//    // Start is called before the first frame update
//    protected override void Start()
//    {
//        base.Start();
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        
//    }
}
