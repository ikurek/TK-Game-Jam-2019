using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketInteraction : InteractiveObject
{
    [SerializeField]
    private GameObject bulb;

    [SerializeField]
    private GameObject switchGo;
    
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
        base.activate(activator);

        if(activator.GetComponent<PlayerObjectInteractionScript>().heldObject.GetComponent<ObjectTypeClass>().objectType == ObjectType.zarowka)
        {
            bulb.SetActive(true);
            switchGo.GetComponent<LightBulbsPuzzle>().allBulbsAtSocket();
            activator.GetComponent<PlayerObjectInteractionScript>().heldObject.SetActive(false);
            activator.GetComponent<PlayerObjectInteractionScript>().heldObject = null;
        }
        
        
    }
}
