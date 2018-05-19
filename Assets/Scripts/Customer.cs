using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
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
        AskForTickets();
    }

    // Update is called once per frame
    private void Update()
    {

    }
    #endregion

    #region Methods
    // Ask for tickets
    public void AskForTickets()
    {
        DialogueBox.Instance.GiveDialogue("3 tickets, please.");
        GameObject[] money = MoneyController.Instance.SpawnMoney(999);
    }
    #endregion

    #region Coroutines

    #endregion
}
