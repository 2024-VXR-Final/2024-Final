using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    //XR Rig so we can prevent it from being destroyed when we change scenes
    [SerializeField] GameObject XRRig;

    //HUD so we can display score. We can get required child components on start
    [SerializeField] GameObject userHUD;

    //Animation scripts or whatever
    //Add these in inspector in the order of easy, medium, hard
    [SerializeField] Animator[] diffAnimators;

    //Labels that will be changed during the game
    TMP_Text scoreLabel;
    TMP_Text timeLabel;

    //Static variables for difficulty and score
    public static int gameDifficulty;
    public static int userScore;

    private void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(XRRig);

        //Gets both labels and assigns them to their proper variables
        TMP_Text[] labels = userHUD.GetComponentsInChildren<TMP_Text>();

        foreach (TMP_Text label in labels)
        {
            if (label.gameObject.CompareTag("Score"))
            {
                scoreLabel = label;
            } else if (label.gameObject.CompareTag("Time"))
            {
                timeLabel = label;
            }
        }
    }

    private void FixedUpdate()
    {
        timeLabel.text = "Time: " + Time.realtimeSinceStartup;
    }

    private void OnEnable()
    {
        //Subscribe to score event here
    }

    private void OnDisable()
    {
        //Unsubscribe from score event here
    }

    /// <summary>
    /// Takes the tag and translates it into an int which is set to static so it can be accessed anywhere
    /// </summary>
    /// <param name="tag">The tag of the selected difficulty</param>
    public void DifficultySelect(string tag)
    {
        switch (tag)
        {
            case "Easy":
                gameDifficulty = 0;

                //Start easy animation
                diffAnimators[gameDifficulty].Play("AnimationLayer.AnimationName");
                break;

            case "Medium":
                gameDifficulty = 1;

                //Start Medium Animation
                diffAnimators[gameDifficulty].Play("AnimationLayer.AnimationName");
                break;

            case "Hard":
                gameDifficulty = 2;

                //Start Hard Animation
                diffAnimators[gameDifficulty].Play("AnimationLayer.AnimationName");
                break;
            
            //By default the difficulty is set to easy
            default: 
                gameDifficulty = 0; 
                break;
        }

        Debug.Log("Selected " + tag + "/Difficulty " + gameDifficulty);
    }

    /// <summary>
    /// Score is tracked based off time taken to process a number of cells
    /// Each difficulty will correspond to a numerical goal, and the time it takes to
    /// complete that goal is tracked as the user's score
    /// 
    /// This function will be fired whenever the users score changes, and will update the UI
    /// </summary>
    void UpdateScoreUI()
    {

    }
}
