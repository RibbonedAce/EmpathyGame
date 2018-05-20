using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Variables

    #endregion

    #region Properties
    public static GameController Instance { get; private set; } // The instance to reference
    public int Score { get; private set; }                      // The score of the game
    #endregion

    #region Events
    // Awake is called before Start
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        Score = 0;
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    #endregion

    #region Methods
    // Add score to the game
    public void AddScore(int value)
    {
        Score += value;
    }
    #endregion

    #region Coroutines
    
    #endregion
}
