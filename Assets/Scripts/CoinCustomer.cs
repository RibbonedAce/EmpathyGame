using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCustomer : Customer
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
    // Ask for tickets
    public override void AskForTickets()
    {
        request = Random.Range(2, 10) * 5;
        DialogueBox.Instance.GiveDialogue(string.Format("{0} tickets, please.", request));
        int money = request * 50;
        foreach (int i in Utils.SplitNumber(money, 3))
        {
            MoneyController.Instance.GiveMoney(i);
        }
        moneyGiven = money;
    }
    #endregion

    #region Coroutines

    #endregion
}
