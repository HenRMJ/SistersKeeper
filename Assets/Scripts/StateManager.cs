using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    [SerializeField] State[] allStates;
    [SerializeField] State[] checkStates;
    [SerializeField] Text[] achTitle;
    [SerializeField] Text[] achDescrip;
    [SerializeField] Image[] achLogo;
    [SerializeField] Achievement[] allAchievements;
    [SerializeField] Text[] SKtit;
    [SerializeField] Text[] SKdesc;
    [SerializeField] Image[] SKimg;
    [SerializeField] Achievement[] specialAchs;



    public State[] GetAllStates()
    {
        return allStates;
    }

    private void Start()
    {
        allAchievements[0].GetVarState().visited = PlayerPrefs.GetInt("ach01");
        allAchievements[1].GetVarState().visited = PlayerPrefs.GetInt("ach02");
    }

    private void CheckStates(int i)
    {
        if (allAchievements[0].GetVarState().visited > 0)
        {
            achTitle[i].text = allAchievements[i].GetAchievementName();
            achDescrip[i].text = allAchievements[i].GetAchievementDescription();
            achLogo[i].sprite = allAchievements[i].GetIcon();
        } else
        {
            achTitle[i].text = "Locked";
            achDescrip[i].text = "Continue playing game to unlock";
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool finishedGame = true;
        bool finishedGametwice = true;

        PlayerPrefs.SetInt("ach01", allAchievements[0].GetVarState().visited);
        PlayerPrefs.SetInt("ach02", allAchievements[1].GetVarState().visited);
        

        for (int i = 0; i < allAchievements.Length; i++)
        {
            CheckStates(i);
        }
    

        foreach (State a in checkStates)
        {
            if (a.TimesVisited() <= 0)
            {
                finishedGame = false;
            }
        }

        foreach (State a in checkStates)
        {
            if (a.TimesVisited() <= 1)
            {
                finishedGametwice = false;
            }
        }

        if (finishedGame)
        {
            PlayerPrefs.SetInt("Win1", 1);
        }

        if (finishedGametwice)
        {
            PlayerPrefs.SetInt("Win2", 1);
        }

        if (PlayerPrefs.GetInt("Win1") == 1)
        {
            SKtit[0].text = specialAchs[0].GetAchievementName();
            SKdesc[0].text = specialAchs[0].GetAchievementDescription();
            SKimg[0].sprite = specialAchs[0].GetIcon();
        } else
        {
            SKtit[0].text = "Locked";
            SKdesc[0].text = "Continue playing game to unlock";
        }

        if (PlayerPrefs.GetInt("Win2") == 1)
        {
            SKtit[1].text = specialAchs[1].GetAchievementName();
            SKdesc[1].text = specialAchs[1].GetAchievementDescription();
            SKimg[1].sprite = specialAchs[1].GetIcon();
        }
        else
        {
            SKtit[1].text = "Locked";
            SKdesc[1].text = "Continue playing game to unlock";
        }


    }

}