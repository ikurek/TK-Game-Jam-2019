﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerObjectInteractionScript))]
public class PlayerUIPrompts : MonoBehaviour
{
    [SerializeField]
    private GameObject UpPrompt;
    [SerializeField]
    private GameObject PutPrompt;

    [SerializeField]
    private GameObject PutActivatePrompt;
    
    [SerializeField]
    private float playerPromptOffsetY = 0;
    
    [SerializeField]
    private float playerPromptOffsetX = 0;
    
    [SerializeField]
    private float playerPromptHoldOffsetY = 0;
    
    [SerializeField]
    private float playerPromptHoldOffsetX = 0;
    
    
    private PlayerObjectInteractionScript playerInteraction;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpPrompt.SetActive(false);
        PutPrompt.SetActive(false);
//        PutActivatePrompt.SetActive(false);
        playerInteraction = GetComponent<PlayerObjectInteractionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteraction.isTouchingInteractive == true)
        {
//            if (playerInteraction.)
//            {
//                
//            }
            
            UpPrompt.SetActive(true);
            UpPrompt.transform.position = transform.position + new Vector3(playerPromptOffsetX,playerPromptOffsetY,0);
        }
        else
        {
            UpPrompt.SetActive(false);
        }
        
        if (playerInteraction.heldObject!=null)
        {
            PutPrompt.SetActive(true);
            PutPrompt.transform.position = transform.position + new Vector3(playerPromptHoldOffsetX,playerPromptHoldOffsetY,0);
        }
        else
        {
            PutPrompt.SetActive(false);
        }
        
    }
}
