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
            GameObject.Find("ProgressObject").GetComponent<ProgressController>().tryChangeEpoch();
        });

        inputDispatcher.AddKeyDownHandler(KeyCode.Return, (KeyCode) => {
            if(heldObject == null) {
                pickupLastCollidedInteractive();
            } else {
                dropLastCollidedinteractive();
            }
            GameObject.Find("ProgressObject").GetComponent<ProgressController>().tryChangeEpoch();
        });
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        print("OnCollisionEnter with " + collision.gameObject.name);
        if(collision.gameObject.tag == interactiveTag) {
            isTouchingInteractive = true;
            lastCollidedInteractive = collision.gameObject;
        }
    }
 
    void OnCollisionExit2D(Collision2D collision) 
    {
        print("OnCollisionExit with " + collision.gameObject.name);
        if(collision.gameObject.tag == interactiveTag) {
            isTouchingInteractive = false;
        }
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
                interactive.pickup(gameObject);
                heldObject = lastCollidedInteractive;
            }
        }
    }

    void dropLastCollidedinteractive()
    {
        if(heldObject != null) {
            InteractiveObject interactive = heldObject.GetComponent<InteractiveObject>() as InteractiveObject;
            if(interactive != null) {
                interactive.drop(gameObject);
                heldObject = null;
            }
        }
    }

    private InteractiveObject getLastCollidedInteractive() {
        return lastCollidedInteractive.GetComponent<InteractiveObject>() as InteractiveObject;
    }
}
