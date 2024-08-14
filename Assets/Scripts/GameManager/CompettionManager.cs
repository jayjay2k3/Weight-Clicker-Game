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
    public float timeLimit = 5;
    float time;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Image timeBar;
    public bool isStart;

    public GameObject failedPanel;
    public GameObject successPanel;
    public GameObject startGamePanel;
    public GameObject successNoUnlockPanel;
    public TextMeshProUGUI counter;
    public Image newUnlockableBarbellImage;
    public GameManager gameManager;
    bool success=false;
    // Start is called before the first frame update
    void Awake()
    {
        isStart = false;
        pushCount = 0;
        time = timeLimit;
        startGamePanel.SetActive(true);
        UpdateCounter();
        gameManager.canClick = false;
    }
    public void StartGame()
    {
        isStart = true;
        startGamePanel.SetActive(false);
        gameManager.canClick = true;

    }

    public void UpdateCounter()
    {
        counter.text = pushCount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            StartCountDown();
            if (pushCount == 10 && !success)
            {
                Success();
            }
        }
    }

    void StartCountDown()
    {
        time -= Time.deltaTime * 1f;
        timeText.text = time.ToString("0.00");
        timeBar.fillAmount = time / timeLimit;
        if (time <= 0)
        {
            Failed();
        }
    }

    void Failed()
    {
        Time.timeScale = 0;
        timeText.text = "0";
        failedPanel.SetActive(true);

    }

    void Success()
    {
        Time.timeScale = 0;

        if (characterStats.barbellUnlockable[characterStats.selectedBarbellIndex + 1] == true)
        {
            successNoUnlockPanel.SetActive(true);
            
        }
        else
        {
            successPanel.SetActive(true);
            characterStats.barbellUnlockable[characterStats.selectedBarbellIndex + 1] = true;
            newUnlockableBarbellImage.sprite = gameManager.barbellImage[characterStats.selectedBarbellIndex + 1];

        }
        success=true;
    }
}
