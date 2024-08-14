using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class CompettionManager : MonoBehaviour
{
    public CharacterStats characterStats;
    public int pushCount;
    public float timeLimit=5;
    float time;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Image timeBar;

    public GameObject failedPanel;
     public GameObject successPanel;
    // Start is called before the first frame update
    void Awake()
    {
        pushCount=0;
        time=timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        StartCountDown();
        if(pushCount==1)
        {
            Success();
        }
    }

    void StartCountDown()
    {
        time-=Time.deltaTime*1f;
        timeText.text=time.ToString("0.00");
        timeBar.fillAmount=time/timeLimit;
        if(time<=0)
        {
            Failed();
        }
    }

    void  Failed()
    {
        Time.timeScale=0;
        timeText.text="0";
        failedPanel.SetActive(true);

    }

    void Success()
    {
        Time.timeScale=0;
        successPanel.SetActive(true);
        characterStats.barbellUnlockable[characterStats.selectedBarbellIndex+1]=true;
    }
}
