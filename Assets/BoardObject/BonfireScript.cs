using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : InteractiveObject
{
    public override void pickup(GameObject parentGameObject)
    {
        base.playSound("Sound/pick_wood");
        base.pickup(parentGameObject);
    }

    public override void drop(GameObject exParentGameObject)
    {
        base.playSound("Sound/drop_wood");
        base.drop(exParentGameObject);
    }

    public override void activate(GameObject activator)
    {
        base.activate(activator);
    }
}
