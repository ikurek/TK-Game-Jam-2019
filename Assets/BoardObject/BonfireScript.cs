﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : InteractiveObject
{
    public bool pickable = false;
    
    public override void pickup(GameObject parentGameObject)
    {
        if (pickable)
        {
            base.playSound("Sound/pick_wood");
            base.pickup(parentGameObject);
        }
    }

    public override void drop(GameObject exParentGameObject)
    {
        if (pickable)
        {
            base.playSound("Sound/drop_wood");
            base.drop(exParentGameObject);
        }
    }
}
