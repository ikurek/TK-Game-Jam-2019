using ChronoPuzzle.Gamestate.Progress;
using ChronoPuzzle.World.Interactive;
using UnityEngine;

namespace ChronoPuzzle.World.Player {

    public class PlayerObjectInteractionScript : MonoBehaviour
    {
        string interactiveTag = "interactive";
        bool isTouchingAnything = false;
        public bool isTouchingInteractive = false;
        GameObject lastCollidedInteractive = null;
        public GameObject heldObject = null;
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();

            InputDispatcher inputDispatcher = FindObjectOfType<InputDispatcher>();
        
            inputDispatcher.AddKeyDownHandler(KeyCode.F, (KeyCode) => {
                activateLastCollidedInteractive();
                GameObject.Find("ProgressObject").GetComponent<ProgressController>().advanceIfPossible();
            });

            inputDispatcher.AddKeyDownHandler(KeyCode.E, (KeyCode) => {
                if(heldObject == null) {
                    pickupLastCollidedInteractive();
                } else {
                    if (!isTouchingAnything)
                    {
                        dropHeldObject();
                    }
                }
                GameObject.Find("ProgressObject").GetComponent<ProgressController>().advanceIfPossible();
            });
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            print("OnTriggerEnter with " + other.gameObject.name);
            isTouchingAnything = true;
            if(other.gameObject.tag == interactiveTag) {
                isTouchingInteractive = true;
                lastCollidedInteractive = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            print("OnTriggerExit with " + other.gameObject.name);
            isTouchingAnything = false;
            if(other.gameObject.tag == interactiveTag) {
                isTouchingInteractive = false;
            }
        }

        void OnCollisionEnter2D(Collision2D collision) 
        {
            print("OnCollisionEnter with " + collision.gameObject.name);

        }
 
        void OnCollisionExit2D(Collision2D collision) 
        {
            print("OnCollisionExit with " + collision.gameObject.name);

        }

        void activateLastCollidedInteractive()
        {        
            if(isTouchingInteractive) {
                InteractiveObject interactive = getLastCollidedInteractive();
                if(interactive != null) {
                    interactive.activate(gameObject);
                }
            }

        }

        void pickupLastCollidedInteractive()
        {
            if(heldObject == null && isTouchingInteractive) {
                InteractiveObject interactive = getLastCollidedInteractive();
                if(interactive != null) {
                    heldObject = interactive.pickup(gameObject);
                    if (heldObject != null)
                    {
                        animator.SetBool("PlayerHandsUp", true);
                    }
                
                }
            }
        }

        void dropHeldObject()
        {
            if(heldObject != null) {
                InteractiveObject interactive = heldObject.GetComponent<InteractiveObject>() as InteractiveObject;
                if(interactive != null) {
                    interactive.drop(gameObject);
                    heldObject = null;
                    animator.SetBool("PlayerHandsUp",  false);
                }
            }
        }

        private InteractiveObject getLastCollidedInteractive() {
            return lastCollidedInteractive.GetComponent<InteractiveObject>() as InteractiveObject;
        }
    }

}
