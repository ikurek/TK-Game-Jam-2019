using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RynnaScript : InteractiveObject
{
    public bool pickable = false;
    [SerializeField] private GameObject waterMachine;

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
            base.playSound("Sound/drop_wood");
            return base.drop(exParentGameObject);
        }
        else
        {
            return null;
        }
    }

    public override void activate(GameObject activator)
    {
        Debug.Log("cos w ryncach");

        GameObject heldObject = activator.GetComponent<PlayerObjectInteractionScript>().heldObject;

        if (heldObject.GetComponent<ObjectTypeClass>().objectType == ObjectType.garnek)
        {

            Debug.Log("garnek w ryncach");
            if (heldObject.GetComponent<PotScript>().isFilled)
            {
                Debug.Log("garnek w ryncach  z woda");
                waterMachine.GetComponent<Animator>().enabled = true;
                base.activate(activator);
            }


        }



    }
}
