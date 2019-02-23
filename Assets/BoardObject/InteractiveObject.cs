using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject: MonoBehaviour
{
    private bool isActivated;
    private AudioClip sound;

    public bool isActive()
    {
        return isActivated;
    }
    
    public virtual void activate(GameObject activator) {
        print("Activated " + gameObject.name);
        isActivated = true;
    }

    public virtual void pickup(GameObject parentGameObject) {
        gameObject.GetComponent<Collider2D>().enabled = false;
        setNewPositionAbovePlayer(parentGameObject);
        gameObject.transform.SetParent(parentGameObject.transform);
        print("Picked up " + gameObject.name);
    }

    public virtual void drop(GameObject exParentGameObject) {
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
        
        gameObject.transform.position = new Vector3(playerGameObject.transform.position.x, playerTop + 0.2f);
    }

    private void setNewPositionBelowPlayer(GameObject playerGameObject)
    {
        float playerCenter = playerGameObject.transform.position.y;
        float playerSize = playerGameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        float playerBottom = playerCenter - playerSize / 2;
        
        gameObject.transform.position = new Vector3(playerGameObject.transform.position.x, playerBottom - 0.2f);
    }

    public virtual void playSound(string soundPath)
    {
        sound = Resources.Load<AudioClip>(soundPath);
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound, 1.0f);
    }
}
