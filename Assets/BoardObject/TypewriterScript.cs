using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypewriterScript : InteractiveObject
{
    public bool pickable = true;
    
    public override void activate(GameObject activator)
    {
        base.playSound("Sound/typewriter_typing");
        base.activate(activator);
    }

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

    public override GameObject drop(GameObject exParentGameObject)
    {
        if (pickable)
        {
            base.playSound("Sound/typewriter_drop");
            return base.drop(exParentGameObject);
        }
        else
        {
            return null;
        }
    }
}
