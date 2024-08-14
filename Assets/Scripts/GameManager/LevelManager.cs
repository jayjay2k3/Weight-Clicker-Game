using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : GameManager
{
    [SerializeField] Image ProgressBar;
    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Awake()
    {
        levelText.text="Lv." + characterStats.level.ToString();
        ProgressBar.fillAmount=(float)characterStats.expProgress/characterStats.expForNextLevel;
    }

    // Update is called once per frame
   
    public void GainExp()
    {
        characterStats.expProgress+=characterStats.expPerClick;
        ProgressBar.fillAmount=(float)characterStats.expProgress/characterStats.expForNextLevel;
        if(characterStats.expProgress>=characterStats.expForNextLevel)
        {
            characterStats.level++;
            characterStats.expProgress=characterStats.expProgress-characterStats.expForNextLevel;
            levelText.text="Lv." + characterStats.level.ToString();
            ProgressBar.fillAmount=(float)characterStats.expProgress/characterStats.expForNextLevel;
            characterStats.expForNextLevel+=50*characterStats.level;
        } 
        
    }
}
