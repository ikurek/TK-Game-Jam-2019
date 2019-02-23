using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectScript : MonoBehaviour, IInteractiveObject
{

    public void activate(GameObject activator) {
        print("Activated " + gameObject.name);
    }

    public void pickup(GameObject parentGameObject) {
        gameObject.GetComponent<Collider2D>().enabled = false;
        setNewPositionAbovePlayer(parentGameObject);
        gameObject.transform.SetParent(parentGameObject.transform);
        print("Picked up " + gameObject.name);
    }

    public void drop(GameObject exParentGameObject) {
        setNewPositionBelowPlayer(exParentGameObject);
        gameObject.transform.SetParent(null);
        gameObject.GetComponent<Collider2D>().enabled = true;
        print("Dropped " + gameObject.name);
    }

    private void setNewPositionAbovePlayer(GameObject playerGameObject)
    {
        float playerCenter = playerGameObject.transform.position.y;
        float playerSize = playerGameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        float playerTop = playerCenter + playerSize / 2;
        
        gameObject.transform.position = new Vector3(playerGameObject.transform.position.x, playerTop);
    }

    private void setNewPositionBelowPlayer(GameObject playerGameObject)
    {
        float playerCenter = playerGameObject.transform.position.y;
        float playerSize = playerGameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        float playerBottom = playerCenter - playerSize / 2;
        
        gameObject.transform.position = new Vector3(playerGameObject.transform.position.x, playerBottom);
    }
}
