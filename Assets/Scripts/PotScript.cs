using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotScript : InteractiveObject
{
    public bool pickable = false;
    [SerializeField] private GameObject fireToMakePot;
    [SerializeField] private Sprite PotSprite;

    public bool isFilled = false;


    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    if(collision.gameObject.Equals(fireToMakePot))
    //    {
    //        if(fireToMakePot.GetComponent<BonfireScript>().isActive())
    //        transform.GetComponent<SpriteRenderer>().sprite = PotSprite;
    //    }
    //}


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
            base.playSound("Sound/pot_drop");
            return base.drop(exParentGameObject);
        }
        else
        {
            return null;
        }
    }

    public override void activate(GameObject activator)
    {
        
        base.activate(activator);

    }
}
