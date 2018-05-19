using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject[] screens;   // The different menu screens
    #endregion

    #region Properties

    #endregion

    #region Events
    // Awake is called before Start
    private void Awake()
    {
        ChangeScreen(0);
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
    // Change the menu screen
    public void ChangeScreen(int index)
    {
        for (int i = 0; i < screens.Length; ++i)
        {
            screens[i].SetActive(i == index);
        }
    }
    #endregion

    #region Coroutines

    #endregion
}
