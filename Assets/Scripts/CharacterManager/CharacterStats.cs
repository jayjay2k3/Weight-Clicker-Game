using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStats : ScriptableObject
{
    [Header("Stat Value")]
    public int currentBarbellWeight;
    public int level;
    public int expPerClick;
    public int expProgress;
    public int expForNextLevel;
    public int power;
    public int stamina;
    public int staminaRegen;
    public float currentSweat;
    public float sweatGainRate;
    public float sweatGainPerClick;
    
    [Header("Stat Level")]
    public int powerLevel;
    public int staminaLevel;
    public int staminaRegenLevel;
    public int sweatGainLevel;

    [Header("Equipment Unlocked")]
    public bool[] barbellUnlocked;

    public int selectedBarbellIndex;
    
}
