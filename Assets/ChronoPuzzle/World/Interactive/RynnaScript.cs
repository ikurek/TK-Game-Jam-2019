using ChronoPuzzle.Gamestate.Progress;
using ChronoPuzzle.Scripts;
using ChronoPuzzle.World.Player;
using UnityEngine;

namespace ChronoPuzzle.World.Interactive {

    public class RynnaScript : InteractiveObject, IEpochChangeListener
    {
        public bool pickable = false;
        [SerializeField] private GameObject waterMachine;
//    [SerializeField] private PlayerKillerScript playeKiller;

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

            if (heldObject.GetComponent<ObjectTypeClass>().objectType == ObjectType.garnek)
            {

                if (heldObject.GetComponent<PotScript>().isFilled)
                {
                    base.playSound("Sound/water_tap");
                    waterMachine.GetComponent<Animator>().enabled = true;
                    base.activate(activator);
//                playeKiller.IsDead = true;
                    epochChanged(Epoch.First);

                }


            }



        }

        public void epochChanged(Epoch epoch)
        {
            ;
        }
    }

}
