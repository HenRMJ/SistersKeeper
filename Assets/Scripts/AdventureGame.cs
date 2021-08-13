using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureGame : MonoBehaviour
{

    [SerializeField] Text textComponent;
    [SerializeField] State StartingState;
    [SerializeField] Text optionOne;
    [SerializeField] Text optionTwo;
    [SerializeField] Text optionThree;
    [SerializeField] State[] allStates;


    State state;

    AudioSource player;
    AudioClip voiceClips;

    // Start is called before the first frame update
    void Start()
    {
        foreach (State a in allStates)
        {
            if (a.GetStateStory() == PlayerPrefs.GetString("saved"))
            {
                StartingState = a;
            }
        }

    
        state = StartingState;
        textComponent.text = state.GetStateStory();
        optionOne.text = state.OptionOne();
        optionTwo.text = state.OptionTwo();
        optionThree.text = state.OptionThree();
        player = GetComponent<AudioSource>();
        PlayVoice();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();

        PlayerPrefs.SetString("saved", state.GetStateStory());
    }

    public void Hover()
    {
        FindObjectOfType<AudioManager>().Play("Hover");
    }

    public void OptionOne()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        var nextStates = state.GetNextStates();
        var visited = state.TimesVisited();
        state.setTimesVisited(visited);
        state.NotCheckpoint();

        state = nextStates[0];
        state.IsCheckpoint();
        PlayVoice();
    }

    public void OptionTwo()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        var nextStates = state.GetNextStates();
        var visited = state.TimesVisited();
        state.setTimesVisited(visited);
        state.NotCheckpoint();

        state = nextStates[1];
        state.IsCheckpoint();
        PlayVoice();

    }

    public void OptionThree()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        var nextStates = state.GetNextStates();
        var visited = state.TimesVisited();
        state.setTimesVisited(visited);
        state.NotCheckpoint();

        state = nextStates[2];
        state.IsCheckpoint();
        PlayVoice();

    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index) || Input.GetKeyDown(KeyCode.Keypad1 + index))
            {
                state.NotCheckpoint();
                state = nextStates[index];
                state.IsCheckpoint();
                PlayVoice();
                var visited = state.TimesVisited();
                state.setTimesVisited(visited);
                FindObjectOfType<AudioManager>().Play("Click");
            }
        }

        // This piece of code stops the game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(3);
        }

        // This updates all the text components after the loop has finished
        UpdateText();
    }

    private void UpdateText()
    {
        textComponent.text = state.GetStateStory();
        optionOne.text = state.OptionOne();
        optionTwo.text = state.OptionTwo();
        optionThree.text = state.OptionThree();
    }

    private void PlayVoice()
    {
        if (player.isPlaying)
        {
            player.Stop();
        }

        voiceClips = state.voiceOver();
        player.clip = voiceClips;
        player.Play();

    }

    public void ResetProgress()
    {
        foreach (State a in allStates)
                a.setTimesVisited(-1);

        PlayerPrefs.SetInt("Win1", 0);
        PlayerPrefs.SetInt("Win2", 0);
    }

    public void MuteVoice()
    {
        if (player.volume == 1)
        {
            player.volume = 0;
        } else
        {
            player.volume = 1;
        }
    }

    public void LoadCoreGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadAchievements()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPause()
    {
        SceneManager.LoadScene(3);
    }

    public void StopGame()
    {
        Application.Quit();
    }
}