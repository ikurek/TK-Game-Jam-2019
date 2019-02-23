using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;

public class PlayerObjectInteractionScript : MonoBehaviour
{
    string interactiveTag = "interactive";
    bool isTouchingInteractive = false;
    GameObject lastCollidedInteractive = null;
    GameObject heldObject = null;

    void Start()
    {
        InputDispatcher inputDispatcher = FindObjectOfType<InputDispatcher>();
        
        inputDispatcher.AddKeyDownHandler(KeyCode.Space, (KeyCode) => {
            activateLastCollidedInteractive();
        });

        inputDispatcher.AddKeyDownHandler(KeyCode.F, (KeyCode) => {
            pickupLastCollidedInteractive();
        });
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == interactiveTag) {
            isTouchingInteractive = true;
            lastCollidedInteractive = collision.gameObject;
        }
    }
 
    void OnCollisionExit(Collision collision) 
    {
        if(collision.gameObject.tag == interactiveTag) {
            isTouchingInteractive = false;
        }
    }

    void activateLastCollidedInteractive()
    {
        if(isTouchingInteractive) {
            IInteractiveObject interactive = getLastCollidedInteractive();
            if(interactive != null) {
                interactive.activate();
            }
        }

    }

    void pickupLastCollidedInteractive()
    {
        if(heldObject == null && isTouchingInteractive) {
            IInteractiveObject interactive = getLastCollidedInteractive();
            if(interactive != null) {
                interactive.pickup(gameObject.transform);
                heldObject = lastCollidedInteractive;
            }
        }
    }

    void dropLastCollidedinteractive()
    {
        if(heldObject != null) {
            IInteractiveObject interactive = heldObject.GetComponent<InteractiveObjectScript>() as IInteractiveObject;
            if(interactive != null) {
                interactive.drop();
                heldObject = null;
            }
        }
    }

    private IInteractiveObject getLastCollidedInteractive() {
        return lastCollidedInteractive.GetComponent<InteractiveObjectScript>() as IInteractiveObject;
    }
}
