using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public bool canPush=true;
    public CharacterStats characterStats;
    public bool canClick=true;
    
    public int statGainPerUpgrade;
    // Start is called before the first frame update
    
    [Header("Upgrade Barbell Text")]

    public TextMeshProUGUI[] barbellText;
    public Button[] barbellButton;
    public TextMeshProUGUI[] weightText;
    public Image[] barbellImage;
    public SpriteRenderer characterCurrentBarbellImage;
    private void Start() {
        LoadData();
    }

    void LoadData()
    {
        

        PlayerPrefs.GetInt("currentBarbellWeight",characterStats.currentBarbellWeight);
        PlayerPrefs.GetInt("level",characterStats.level);
        PlayerPrefs.GetInt("expPerClick",characterStats.expPerClick);
        PlayerPrefs.GetInt("expProgress",characterStats.expProgress);
        PlayerPrefs.GetInt("expForNextLevel",characterStats.expForNextLevel);
        PlayerPrefs.GetInt("power",characterStats.power);
        PlayerPrefs.GetInt("stamina",characterStats.stamina);
        PlayerPrefs.GetInt("staminaRegen",characterStats.staminaRegen);

        PlayerPrefs.GetFloat("currentSweat",characterStats.currentSweat);
        PlayerPrefs.GetFloat("sweatGainRate",characterStats.sweatGainRate);
        PlayerPrefs.GetFloat("sweatGainPerClick",characterStats.sweatGainPerClick);

        PlayerPrefs.GetInt("powerLevel",characterStats.powerLevel);
        PlayerPrefs.GetInt("staminaLevel",characterStats.staminaLevel);
        PlayerPrefs.GetInt("staminaRegenLevel",characterStats.staminaRegenLevel);
        PlayerPrefs.GetInt("sweatGainLevel",characterStats.sweatGainLevel);

        for(int i=0;i<characterStats.barbellUnlocked.Length;i++)
        {
            int value=0;
            PlayerPrefs.GetFloat("barbellUnlocked"+"i",value);
            characterStats.barbellUnlocked[i]= value==1 ? true : false;

        }
        
        PlayerPrefs.SetInt("selectedBarbellIndex",characterStats.selectedBarbellIndex);
        PlayerPrefs.Save();

        characterCurrentBarbellImage.sprite=barbellImage[characterStats.selectedBarbellIndex].sprite;
        
    }

    protected void setCanPush(bool canPush)
    {
        GameManager[] gameManager=FindObjectsOfType<GameManager>();
        foreach(GameManager child in gameManager)
        {
            child.canPush=canPush;
        }
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("currentBarbellWeight",characterStats.currentBarbellWeight);
        PlayerPrefs.SetInt("level",characterStats.level);
        PlayerPrefs.SetInt("expPerClick",characterStats.expPerClick);
        PlayerPrefs.SetInt("expProgress",characterStats.expProgress);
        PlayerPrefs.SetInt("expForNextLevel",characterStats.expForNextLevel);
        PlayerPrefs.SetInt("power",characterStats.power);
        PlayerPrefs.SetInt("stamina",characterStats.stamina);
        PlayerPrefs.SetInt("staminaRegen",characterStats.staminaRegen);

        PlayerPrefs.SetFloat("currentSweat",characterStats.currentSweat);
        PlayerPrefs.SetFloat("sweatGainRate",characterStats.sweatGainRate);
        PlayerPrefs.SetFloat("sweatGainPerClick",characterStats.sweatGainPerClick);

        PlayerPrefs.SetInt("powerLevel",characterStats.powerLevel);
        PlayerPrefs.SetInt("staminaLevel",characterStats.staminaLevel);
        PlayerPrefs.SetInt("staminaRegenLevel",characterStats.staminaRegenLevel);
        PlayerPrefs.SetInt("sweatGainLevel",characterStats.sweatGainLevel);

        for(int i=0;i<characterStats.barbellUnlocked.Length;i++)
        {
            int value= characterStats.barbellUnlocked[i] ? 1 : 0;
            PlayerPrefs.SetInt("barbellUnlocked"+"i",value);
        }
        
        PlayerPrefs.SetInt("selectedBarbellIndex",characterStats.selectedBarbellIndex);
        PlayerPrefs.Save();

    }

    
}
