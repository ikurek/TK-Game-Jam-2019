using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialTransform : MonoBehaviour
{

    [SerializeField] Material material;

    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(material.HasProperty("_TargetPosition"))
            material.SetVector("_TargetPosition", target.position);
    }
}
