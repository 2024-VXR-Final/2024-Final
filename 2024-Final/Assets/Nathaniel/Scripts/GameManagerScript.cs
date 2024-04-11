using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);    
    }

    public void DifficultySelect(string tag)
    {
        Debug.Log("Selected " + tag);
    }
}
