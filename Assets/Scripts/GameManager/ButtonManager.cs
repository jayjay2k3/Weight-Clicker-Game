using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    GameManager gameManager;

   [Header("Stat Text")]
    [SerializeField] TextMeshProUGUI characterPowerText;
    [SerializeField] TextMeshProUGUI characterStaminaText;
    [SerializeField] TextMeshProUGUI characterStaminaRegenText;
    [SerializeField] TextMeshProUGUI characterSweatGainText;
    [SerializeField] TextMeshProUGUI sweatPanelText;
    
    
    [Header("Sweat Cost Text")]
   [SerializeField] TextMeshProUGUI characterPowerCostText;
   [SerializeField] TextMeshProUGUI characterStaminaCostText;
   [SerializeField] TextMeshProUGUI characterStaminaRegenCostText;
   [SerializeField] TextMeshProUGUI characterSweatGainCostText;

   [Header("Upgrade Stat Buttons")]

   [SerializeField] Button powerUpgradeButton;
   [SerializeField] Button staminaUpgradeButton;
   [SerializeField] Button staminaRegenUpgradeButton;
   [SerializeField] Button sweatGainUpgradeButton;

   

    
   private void Start() {
      gameManager=GetComponent<GameManager>();
   }
    public void OpenPanel(GameObject panel)
    {
       panel.SetActive(true);
       gameManager.canClick=false;
    }

    public void ClosePanel(GameObject panel)
    {
       panel.SetActive(false);
       gameManager.canClick=true;
    }

   public void UpdateUpgradeStatData()
   {
      characterPowerText.text="Power"+" Lv." +gameManager.characterStats.powerLevel.ToString()+":\n"
                              +gameManager.characterStats.power.ToString() + " -> " + (gameManager.characterStats.power+10).ToString();

      characterStaminaText.text="Stamina"+" Lv." +gameManager.characterStats.staminaLevel.ToString()+":\n"
                                 +gameManager.characterStats.stamina.ToString() + " -> " + (gameManager.characterStats.stamina+20).ToString();

      characterStaminaRegenText.text="Stamina Regen"+" Lv." +gameManager.characterStats.staminaRegenLevel.ToString()+":\n"
                                    +gameManager.characterStats.staminaRegen.ToString() + " -> " + (gameManager.characterStats.staminaRegen+10).ToString();

      characterSweatGainText.text="Sweat Gain"+" Lv." +gameManager.characterStats.sweatGainLevel.ToString()+":\n"
                                 +gameManager.characterStats.sweatGainRate.ToString() + " -> " + (gameManager.characterStats.sweatGainRate+5).ToString();


      characterPowerCostText.text=(gameManager.characterStats.powerLevel*100).ToString();
      characterStaminaCostText.text=(gameManager.characterStats.staminaLevel*100).ToString();
      characterStaminaRegenCostText.text=(gameManager.characterStats.staminaRegenLevel*100).ToString();
      characterSweatGainCostText.text=(gameManager.characterStats.sweatGainLevel*100).ToString();

      powerUpgradeButton.interactable= gameManager.characterStats.currentSweat<gameManager.characterStats.powerLevel*100 ? false : true;
      staminaUpgradeButton.interactable= gameManager.characterStats.currentSweat<gameManager.characterStats.staminaLevel*100 ? false : true;
      staminaRegenUpgradeButton.interactable= gameManager.characterStats.currentSweat<gameManager.characterStats.staminaRegenLevel*100 ? false : true;
      sweatGainUpgradeButton.interactable= gameManager.characterStats.currentSweat<gameManager.characterStats.sweatGainLevel*100 ? false : true;
   }

   public void UpgradeStat(string stat)
   {
      switch (stat)
      {
         case "Power":
            gameManager.characterStats.power+=gameManager.statGainPerUpgrade;
            gameManager.characterStats.currentSweat-=gameManager.characterStats.powerLevel*100;
            sweatPanelText.text=gameManager.characterStats.currentSweat.ToString();
            gameManager.characterStats.powerLevel++;
          
            
            break;
         case "Stamina":
            gameManager.characterStats.stamina+=gameManager.statGainPerUpgrade*2;
            gameManager.characterStats.currentSweat-=gameManager.characterStats.staminaLevel*100;
            sweatPanelText.text=gameManager.characterStats.currentSweat.ToString();
            gameManager.characterStats.staminaLevel++;

            break;
         case "StaminaRegen":
            gameManager.characterStats.staminaRegen+=gameManager.statGainPerUpgrade;
            gameManager.characterStats.currentSweat-=gameManager.characterStats.staminaRegenLevel*100;
            sweatPanelText.text=gameManager.characterStats.currentSweat.ToString();
            gameManager.characterStats.staminaRegenLevel++;
            
            break;
         case "SweatGain":
            gameManager.characterStats.sweatGainRate+=gameManager.statGainPerUpgrade/2;
            gameManager.characterStats.currentSweat-=gameManager.characterStats.sweatGainLevel*100;
            sweatPanelText.text=gameManager.characterStats.currentSweat.ToString();
            gameManager.characterStats.sweatGainLevel++;
            
            break;
      }

      UpdateUpgradeStatData();
   }


   
   
   
   
   public void UpdateBarbellData()
   {
      for(int i=0; i<gameManager.barbellText.Length;i++)
      {
         if(gameManager.characterStats.barbellUnlocked[i])
         {
            if(gameManager.characterStats.selectedBarbellIndex==i)
            {
               gameManager.barbellText[i].text="Selected";
               gameManager.barbellButton[i].interactable=false;
            }
            else
            {
               gameManager.barbellText[i].text="Select";
               gameManager.barbellButton[i].interactable=true;
            }
            
         }
         else
         {
             gameManager.barbellText[i].text="Unlock";
             bool unlockable=int.Parse(gameManager.weightText[i].text.Replace("kg",""))/2<=gameManager.characterStats.power;

             gameManager.barbellButton[i].interactable=unlockable;
             
         }

         
      }
   }

   public void SelectBarbell(Button button)
   {
      for(int i=0;i<gameManager.barbellButton.Length;i++)
      {
         if(button==gameManager.barbellButton[i])
         {
     
                     if(gameManager.barbellText[i].text=="Select")
                     {
                        gameManager.barbellText[i].text="Selected";
                        gameManager.characterStats.selectedBarbellIndex=i;
                        button.interactable=false;
                        //Change current weight
                        gameManager.characterStats.currentBarbellWeight=int.Parse(gameManager.weightText[i].text.Replace("kg",""));
                        //Change expPerClick
                        gameManager.characterStats.expPerClick=gameManager.characterStats.currentBarbellWeight/5;
                        //Change sprite
                        gameManager.characterCurrentBarbellImage.sprite=gameManager.barbellImage[i].sprite;
                        //Change sweatGainPerClick
                        gameManager.characterStats.sweatGainPerClick=gameManager.characterStats.currentBarbellWeight/2;
                     }
         }
               
         }
      

      UpdateBarbellData();
      
   }
}
