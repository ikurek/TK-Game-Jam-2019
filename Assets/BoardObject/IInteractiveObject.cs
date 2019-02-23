using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractiveObject
{
    void activate(GameObject activator);

    void pickup(GameObject parent);

    void drop(GameObject exParent);
}
