using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectScript : MonoBehaviour, IInteractiveObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate() {
        print("Activated");
    }

    public void pickup(Transform parent) {
        gameObject.transform.SetParent(parent);
        gameObject.SetActive(false);
        print("Picked up");
    }

    public void drop() {
        gameObject.transform.SetParent(null);
        gameObject.SetActive(true);
        print("Dropped");
    }
}
