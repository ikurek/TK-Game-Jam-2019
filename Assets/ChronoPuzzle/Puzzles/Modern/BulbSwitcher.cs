using ChronoPuzzle.Scripts;
using ChronoPuzzle.World.Interactive;
using ChronoPuzzle.World.Player;
using UnityEngine;

namespace ChronoPuzzle.Puzzles.Modern {

    public class BulbSwitcher : InteractiveObject
    {
        [SerializeField]
        private int switchNumber;

        [SerializeField]
        private GameObject parent;


        [SerializeField] 
        private Sprite fullSprite;
    
    
        [SerializeField]
        public bool isBasiqSwich;
    
    
        [SerializeField]
        public bool isActive;

        private bool pickable = false;
    
        [SerializeField]
        private bool woda = false;
        [SerializeField]
        private bool sol = false;
    
    
    
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
            if (activator.GetComponent<PlayerObjectInteractionScript>().heldObject == null || isBasiqSwich)
            {
                if ((sol && woda) || isBasiqSwich)
                {
                    isActive = !isActive;

        
        
                    switch (switchNumber)
                    {
                        case 1:
                            parent.GetComponent<LightBulbsPuzzle>().firstSwitch();
                            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                            break;
                        case 2:
                            parent.GetComponent<LightBulbsPuzzle>().secondSwitch();
                            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                            break;
                        case 3:
                            parent.GetComponent<LightBulbsPuzzle>().thirdSwitch();
                            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                            break;
                        case 4:
                            parent.GetComponent<LightBulbsPuzzle>().switchElectricity();
                            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                            break;
                        case 5:
                            //parent.GetComponent<LightBulbsPuzzle>().switchFourthBulb();
                            break;
                    }
                }
            
            }
            else
            {
                if (activator.GetComponent<PlayerObjectInteractionScript>().heldObject.GetComponent<ObjectTypeClass>().objectType == ObjectType.sol )
                {
                    sol = true;
                    activator.GetComponent<PlayerObjectInteractionScript>().heldObject.SetActive(false);
                    activator.GetComponent<PlayerObjectInteractionScript>().heldObject = null;
                }
                else
                {
                    if (activator.GetComponent<PlayerObjectInteractionScript>().heldObject.GetComponent<ObjectTypeClass>().objectType == ObjectType.garnek )
                    {
                        if (activator.GetComponent<PlayerObjectInteractionScript>().heldObject.GetComponent<PotScript>().isFilled)
                        {
                            woda = true;
                            activator.GetComponent<PlayerObjectInteractionScript>().heldObject.SetActive(false);
                            activator.GetComponent<PlayerObjectInteractionScript>().heldObject = null;
                            this.GetComponent<SpriteRenderer>().sprite = fullSprite;
                        }

                    }
                }
                activate(activator);

            }
        
        
        
            base.activate(activator);
        }

//    // Start is called before the first frame update
//    protected override void Start()
//    {
//        base.Start();
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        
//    }
    }

}
