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
            base.playSound("Sound/typewriter_drop");
            base.drop(exParentGameObject);
        }
    }
}
