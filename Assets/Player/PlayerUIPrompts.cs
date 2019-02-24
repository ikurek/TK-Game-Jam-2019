using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerObjectInteractionScript))]
public class PlayerUIPrompts : MonoBehaviour
{
    [SerializeField]
    private GameObject UpPrompt;
    [SerializeField]
    private GameObject Activate;    

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
        Activate.SetActive(false);
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
            
            Activate.SetActive(true);
            Activate.transform.position = transform.position + new Vector3(playerPromptOffsetX,playerPromptOffsetY,-9.48f);
        }
        else
        {
            Activate.SetActive(false);
        }
        
        if (playerInteraction.heldObject!=null)
        {
            UpPrompt.SetActive(true);
            UpPrompt.transform.position = transform.position + new Vector3(playerPromptHoldOffsetX,playerPromptHoldOffsetY,-9.48f);
        }
        else
        {
            UpPrompt.SetActive(false);
        }
        
    }
}
