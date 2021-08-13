using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;
    [TextArea(3, 14)] [SerializeField] string optionOne;
    [TextArea(3, 14)] [SerializeField] string optionTwo;
    [TextArea(3, 14)] [SerializeField] string optionThree;
    [SerializeField] AudioClip voice;
    [SerializeField] State[] nextStates;
    [SerializeField] public int visited;
    [SerializeField] public int checkpoint;

    public string GetStateStory()
    {
        return storyText;
    }

    public string OptionOne()
    {
        return optionOne;
    }

    public string OptionTwo()
    {
        return optionTwo;
    }

    public string OptionThree()
    {
        return optionThree;
    }

    public void setTimesVisited(int v)
    {
        visited = v + 1;
    }

    public int TimesVisited()
    {
        return visited;
    }

    public int GetCheckpoint()
    {
        return checkpoint;
    }

    public void NotCheckpoint()
    {
        checkpoint = 0;
    }

    public void IsCheckpoint()
    {
        checkpoint = 1;
    }

    public AudioClip voiceOver()
    {
        return voice;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }
}