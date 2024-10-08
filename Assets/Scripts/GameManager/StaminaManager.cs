using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : GameManager
{

    public int staminaCostPerClick;
    [SerializeField] Image ProgressBar;
    public float currentStamina;

    // Start is called before the first frame update
    void Awake()
    {
        currentStamina=characterStats.stamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaCostPerClick=characterStats.currentBarbellWeight/3;
        
        if(currentStamina<characterStats.stamina)
        {
            currentStamina+=characterStats.staminaRegen*Time.deltaTime;
            ProgressBar.fillAmount=(float)currentStamina/characterStats.stamina;
            if(currentStamina>characterStats.stamina)
            {
                currentStamina=characterStats.stamina;
            }
        }
        

        if(currentStamina<staminaCostPerClick)
            {
                
                setCanPush(false);
                ProgressBar.color = Color.red;
                
            }
        else
            {
                setCanPush(true);
                TurnNormalColor();
            }   
    }

    void TurnNormalColor()
    {
        ProgressBar.color=new Color(0.4185208f,0.43353f,0.9339623f);
    }
    public void StaminaCost()
    {
        currentStamina-=staminaCostPerClick;
        ProgressBar.fillAmount=(float)currentStamina/characterStats.stamina;
    }
}
