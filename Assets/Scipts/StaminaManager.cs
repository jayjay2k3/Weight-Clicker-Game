using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : GameManager
{

    public int staminaCostPerClick;
    public float characterStamina;
    public float staminaRegenAmount;
    [SerializeField] Image ProgressBar;
    public float currentStamina;
    public TextMeshProUGUI staminaText;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina=characterStamina;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(currentStamina<characterStamina)
        {
            currentStamina+=staminaRegenAmount*Time.deltaTime;
            ProgressBar.fillAmount=(float)currentStamina/characterStamina;
            if(currentStamina>characterStamina)
            {
                currentStamina=characterStamina;
            }
        }
        

        if(currentStamina<staminaCostPerClick)
            {
                setCanPush(false);
            }
        else
            {
                setCanPush(true);
            }   
    }

    public void StaminaCost()
    {
        currentStamina-=staminaCostPerClick;
        ProgressBar.fillAmount=(float)currentStamina/characterStamina;
    }
}
