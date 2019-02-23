using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;

public class PlayerObjectActivationScript : MonoBehaviour
{
    string interactiveTag = "interactive";
    bool isTouchingInteractive = false;
    GameObject lastCollidedInteractive = null;

    void Start()
    {
        FindObjectOfType<InputDispatcher>().AddKeyDownHandler(KeyCode.Space, (KeyCode) => {
            activateLastCollidedInteractive();
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
            IInteractiveObject interactive = lastCollidedInteractive.GetComponent<InteractiveObjectScript>() as IInteractiveObject;
            interactive.activate();
        }

    }
}
