using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] CompettionManager compettionManager;
    public bool isCompettionScene;

    public TextMeshProUGUI expGainText;
    public TextMeshProUGUI sweatGainText;
    public GameObject canvas;

    
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
        
        if(Input.touchCount>0 && gameManager.canPush && EventSystem.current.currentSelectedGameObject==null && gameManager.canClick )
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

        if (isCompettionScene)
        {
            compettionManager.pushCount++;
            compettionManager.UpdateCounter();
        }
        if (!isCompettionScene)
        {   
            levelManager.GainExp();
            sweatManager.GainSweat();

            expGainText.text=gameManager.characterStats.expPerClick.ToString();
            sweatGainText.text = (gameManager.characterStats.sweatGainPerClick * (1+gameManager.characterStats.sweatGainRate/100)).ToString();

            TextMeshProUGUI expText = Instantiate(expGainText,transform.position,Quaternion.identity) ;
            TextMeshProUGUI sweatText = Instantiate(sweatGainText,transform.position,Quaternion.identity);
            
            expText.rectTransform.SetParent(canvas.transform);
            expText.rectTransform.localScale = new Vector3(1,1,1);
            expText.rectTransform.localPosition = new Vector2(-25,-19);

            sweatText.rectTransform.SetParent(canvas.transform);
            sweatText.rectTransform.localScale = new Vector3(1,1,1);
            sweatText.rectTransform.localPosition  = new Vector2(-25,-70);

            
            
        }


        
    }
    void StopPush()
    {
        animator.SetBool("IsTouch",false);
    }


}
