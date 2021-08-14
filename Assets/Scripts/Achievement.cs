using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Achievement")]
public class Achievement : ScriptableObject
{
    public string achievementName;
    public string description;
    public State varState;

    public Sprite icon;

    public State GetVarState()
    {
        return varState;
    }

    public string GetAchievementName()
    {
        return achievementName;
    }

    public string GetAchievementDescription()
    {
        return description;
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}