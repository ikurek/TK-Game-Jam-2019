using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourScript : InteractiveObject
{

    public override GameObject pickup(GameObject parentGameObject)
    {
            return null;
    }

    public override GameObject drop(GameObject exParentGameObject)
    {
            return null;
    }

    public override void activate(GameObject activator)
    {
        if (!isActive())
        {
            base.activate(activator);
            
        }
        else
        {
            
        }
    }
}