using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SweatManager : GameManager
{
   
    

    public TextMeshProUGUI sweatPanelText;

    // Update is called once per frame
    private void Start() {
        sweatPanelText.text=characterStats.currentSweat.ToString();
    }
    

    public void GainSweat()
    {
        characterStats.currentSweat+=characterStats.sweatGainPerClick*(1+characterStats.sweatGainRate/100);
        sweatPanelText.text=((int)characterStats.currentSweat).ToString();
    }
}
