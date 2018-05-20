using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyCustomer : Customer
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
        DialogueBox.Instance.GiveDialogue(string.Format("{0} tickets.", request));
        int money = RoundOrder(request);
        MoneyController.Instance.GiveMoney(money);
        moneyGiven = money;
    }

    // Be requested to give more money
    public override void GiveMoreMoney()
    {
        if (moneyGiven < request * 50)
        {
            MoneyController.Instance.GiveMoney(RoundOrder(request * 50 - moneyGiven));
        }
        else
        {
            DialogueBox.Instance.GiveDialogue("...");
            GameController.Instance.AddScore(-25);
        }
    }

    // Be asked to verify the order
    public override void VerifyOrder()
    {
        DialogueBox.Instance.GiveDialogue(string.Format("...", request));
    }

    // Evaulate the purchase
    public override void EvaluatePurchase()
    {
        if (PurchaseGood)
        {
            DialogueBox.Instance.GiveDialogue("Thanks.");
            GameController.Instance.AddScore(-2 * Mathf.Abs(PurchaseDiff));
            PickUpCollector.Instance.DestroyCollection();
            MoveOn();
            AudioController.Instance.PlayClip(3);
            CustomerController.Instance.SummonNextCustomer();
        }
        else
        {
            DialogueBox.Instance.GiveDialogue("...");
            GameController.Instance.AddScore(-50);
            AudioController.Instance.PlayClip(4);
        }
    }
    #endregion

    #region Coroutines

    #endregion
}
