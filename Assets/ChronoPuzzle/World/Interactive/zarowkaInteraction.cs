using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zarowkaInteraction : InteractiveObject
{
    private bool activatable = false;

    public override void activate(GameObject activator)
    {

    }
    
    public virtual GameObject pickup(GameObject parentGameObject)
    {
        return base.pickup(parentGameObject);
    }


}
