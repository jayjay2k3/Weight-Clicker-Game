using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SweatManager : GameManager
{
    public int sweatGainPerClick;
    public int currentSweat;

    public TextMeshProUGUI sweatPanelText;

    // Update is called once per frame
    private void Start() {
        sweatPanelText.text=currentSweat.ToString();
    }
    

    public void GainSweat()
    {
        currentSweat+=sweatGainPerClick;
        sweatPanelText.text=currentSweat.ToString();
    }
}
