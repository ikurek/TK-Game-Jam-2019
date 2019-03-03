using ChronoPuzzle.Scripts;
using ChronoPuzzle.World.Player;
using UnityEngine;

namespace ChronoPuzzle.World.Interactive {

    public class SinkScript : InteractiveObject
    {

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

            GameObject heldObject = activator.GetComponent<PlayerObjectInteractionScript>().heldObject;

            if (heldObject != null)
            {
                if (heldObject.GetComponent<ObjectTypeClass>().objectType == ObjectType.garnek)
                {
                    heldObject.GetComponent<PotScript>().isFilled = true;
                    base.playSound("Sound/water_tap");

                }
            }



        }
    }

}
