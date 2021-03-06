﻿using ChronoPuzzle.Puzzles.Modern;
using ChronoPuzzle.Scripts;
using ChronoPuzzle.World.Player;
using UnityEngine;

namespace ChronoPuzzle.World.Interactive {

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
                base.playSound("Sound/lightbulb_screw");
                bulb.SetActive(true);
                switchGo.GetComponent<LightBulbsPuzzle>().allBulbsAtSocket();
                activator.GetComponent<PlayerObjectInteractionScript>().heldObject.SetActive(false);
                activator.GetComponent<PlayerObjectInteractionScript>().heldObject = null;
            }
        
        
        }
    }

}
