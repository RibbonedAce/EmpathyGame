using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumpyCustomer : Customer
{
    #region Variables
    private bool confronted = false;    // Whether you asked for more money
    #endregion

    #region Properties
    // Whether what is being given is acceptable
    protected override bool PurchaseGood
    {
        get
        {
            if (!confronted)
            {
                return PickUpCollector.Instance.TotalTicketValue >= request;
            }
            else
            {
                return PickUpCollector.Instance.TotalMoneyValue >= moneyGiven;
            }
        }
    }
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
        int money = RoundOrder(request / 2);
        MoneyController.Instance.GiveMoney(money);
        moneyGiven = money;
    }

    // Be requested to give more money
    public override void GiveMoreMoney()
    {
        if (moneyGiven < request * 50)
        {
            confronted = true;
            DialogueBox.Instance.GiveDialogue("No. I need those tickets and I won't pay any more for them.");
        }
        else
        {
            DialogueBox.Instance.GiveDialogue("I already gave you enough money.");
            GameController.Instance.AddScore(-25);
        }
    }

    // Be asked to verify the order
    public override void VerifyOrder()
    {
        DialogueBox.Instance.GiveDialogue(string.Format("I asked for {0} tickets.", request));
    }

    // Evaulate the purchase
    public override void EvaluatePurchase()
    {
        if (PurchaseGood)
        {
            DialogueBox.Instance.GiveDialogue("Fine. I didn't need to get in anyway.");
            GameController.Instance.AddScore(-2 * Mathf.Abs(PurchaseDiff));
            PickUpCollector.Instance.DestroyCollection();
            MoveOn();
            AudioController.Instance.PlayClip(3);
            CustomerController.Instance.SummonNextCustomer();
        }
        else
        {
            DialogueBox.Instance.GiveDialogue("That's not what I wanted.");
            GameController.Instance.AddScore(-50);
            AudioController.Instance.PlayClip(4);
        }
    }

    // Move on for the next customer
    protected override void MoveOn()
    {
        StartCoroutine(Utils.MoveObjectBy(transform, -15f * Vector3.right, 2f));
        Destroy(gameObject, 2f);
    }
    #endregion

    #region Coroutines

    #endregion
}
