using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : InteractiveObject
{

    [SerializeField] private ParticleSystem fire;
    [SerializeField] private Sprite PotSprite;

    public bool pickable = false;
    
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
        if (!isActive())
        {
            base.activate(activator);

            LightPoint_ShaderScript pointLightScript = GameObject.FindGameObjectWithTag("pointLight").GetComponent<LightPoint_ShaderScript>();

            pointLightScript.target2 = transform;
            pointLightScript.size1 = 0.1f;
            pointLightScript.size2 = 0.15f;

            fire.gameObject.SetActive(true);
            pickable = false;
        }
        else
        {
            GameObject heldObject = activator.GetComponent<PlayerObjectInteractionScript>().heldObject;

            if (heldObject.GetComponent<ObjectTypeClass>().objectType == ObjectType.glina)
            {
                heldObject.GetComponent<SpriteRenderer>().sprite = PotSprite;
                heldObject.GetComponent<ObjectTypeClass>().objectType = ObjectType.garnek;

            }

        }

    }
}
