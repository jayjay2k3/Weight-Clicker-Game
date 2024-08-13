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
        

        characterStats.currentBarbellWeight = PlayerPrefs.GetInt("currentBarbellWeight");
        characterStats.level = PlayerPrefs.GetInt("level");
        characterStats.expPerClick = PlayerPrefs.GetInt("expPerClick");
        characterStats.expProgress = PlayerPrefs.GetInt("expProgress");
        characterStats.expForNextLevel = PlayerPrefs.GetInt("expForNextLevel");
        characterStats.power = PlayerPrefs.GetInt("power");
        characterStats.stamina = PlayerPrefs.GetInt("stamina");
        characterStats.staminaRegen = PlayerPrefs.GetInt("staminaRegen");

        characterStats.currentSweat=PlayerPrefs.GetFloat("currentSweat");
        characterStats.sweatGainRate = PlayerPrefs.GetFloat("sweatGainRate");
        characterStats.sweatGainPerClick = PlayerPrefs.GetFloat("sweatGainPerClick");

        characterStats.powerLevel= PlayerPrefs.GetInt("powerLevel");
        characterStats.staminaLevel = PlayerPrefs.GetInt("staminaLevel");
        characterStats.staminaRegenLevel = PlayerPrefs.GetInt("staminaRegenLevel");
        characterStats.sweatGainLevel = PlayerPrefs.GetInt("sweatGainLevel");

        for(int i=0;i<characterStats.barbellUnlocked.Length;i++)
        {
            int value;
            value = PlayerPrefs.GetInt("barbellUnlocked"+"i");
            characterStats.barbellUnlocked[i]= value == 1;

        }
        
        characterStats.selectedBarbellIndex = PlayerPrefs.GetInt("selectedBarbellIndex");
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
