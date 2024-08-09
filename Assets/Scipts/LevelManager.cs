using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : GameManager
{
    public int expPerClick;
    public int expForNextLevel;
    [SerializeField] Image ProgressBar;
    public int Progress;
    public int Level;
    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text="Lv." + Level.ToString();
        ProgressBar.fillAmount=(float)Progress/expForNextLevel;
    }

    // Update is called once per frame
   
    public void GainExp()
    {
        Progress+=expPerClick;
        ProgressBar.fillAmount=(float)Progress/expForNextLevel;
        if(Progress>=expForNextLevel)
        {
            Level++;
            Progress=Progress-expForNextLevel;
            levelText.text="Lv." + Level.ToString();
            ProgressBar.fillAmount=(float)Progress/expForNextLevel;
        } 
        
    }
}
