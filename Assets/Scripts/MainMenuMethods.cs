using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuMethods : MonoBehaviour
{
    #region Variables

    #endregion

    #region Properties

    #endregion

    #region Events
    // Awake is called before Start
    private void Awake()
    {

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
    // Start the game
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        //("Assets/Scenes/UI_Pitch");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    #region Coroutines

    #endregion
}
