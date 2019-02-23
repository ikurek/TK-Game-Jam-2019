using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractiveObject
{
    void activate();

    void pickup(Transform parent);

    void drop();
}
