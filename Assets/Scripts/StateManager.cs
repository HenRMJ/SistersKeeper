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

    public State[] GetAllStates()
    {
        return allStates;
    }

    private void Start()
    {
        checkStates[0].visited = PlayerPrefs.GetInt("ach01");
        checkStates[1].visited = PlayerPrefs.GetInt("ach02");
    }

    private void CheckStates(int i)
    {
        if (checkStates[i].visited > 0)
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
        //bool finishedGame = true;

        PlayerPrefs.SetInt("ach01", checkStates[0].visited);
        PlayerPrefs.SetInt("ach02", checkStates[1].visited);
        

        for (int i = 0; i < allAchievements.Length; i++)
        {
            CheckStates(i);
        }
    

        foreach (State a in allStates)
        {
            if (a.TimesVisited() <= 0)
            {
                //finishedGame = false;
            }
        }

        /*if (finishedGame)
        {
           win.text = "You finished the whole game!";
        }
        */
    }
  
}