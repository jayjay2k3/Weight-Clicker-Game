using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CharacterController : MonoBehaviour
{

    enum PowerState{
                weak=0,
                strong=1,
                veryStrong=2,
            }   
    [SerializeField] PowerState characterPowerState;
    int WeightValue;
    int currentPower;
    Touch touch;
    Animator animator;
    [SerializeField] GameManager gameManager;
    [SerializeField] StaminaManager staminaManager;
    [SerializeField] LevelManager levelManager;
    [SerializeField] SweatManager sweatManager;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Push();
        
    }

    void Push()
    {
        
        if(Input.touchCount>0 && gameManager.canPush && EventSystem.current.currentSelectedGameObject==null && gameManager.canClick)
        {    
          
            if ((gameManager.characterStats.power*4/gameManager.characterStats.currentBarbellWeight)>=2)
            {
                characterPowerState=PowerState.veryStrong;
            }
            else if((gameManager.characterStats.power*4/gameManager.characterStats.currentBarbellWeight)<1)
            {
                characterPowerState=PowerState.weak;
            }
            else if((gameManager.characterStats.power*4/gameManager.characterStats.currentBarbellWeight)<2)
            {
                characterPowerState=PowerState.strong;
            }
            animator.SetFloat("Power",(int)characterPowerState);
            touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                animator.SetBool("IsTouch",true);
            }
        }
    }

    void GainProgress()
    {
        staminaManager.StaminaCost();
        levelManager.GainExp();
        sweatManager.GainSweat();
    }
    void StopPush()
    {
        animator.SetBool("IsTouch",false);
    }


}
