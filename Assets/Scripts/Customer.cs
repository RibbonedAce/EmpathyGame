using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    #region Variables
    private int request;    // How many tickets that are wanted
    private int moneyGiven; // The amount of money given to pay
    private int[] moneyAmounts = new int[] { 100, 500, 1000, 2000 };
    #endregion

    #region Properties

    // Whether what is being given is acceptable
    private bool PurchaseGood
    {
        get
        {
            return PickUpCollector.Instance.TotalTicketValue == request;
        }
    }

    // The difference in valid exchange
    private int PurchaseDiff
    {
        get
        {
            return PickUpCollector.Instance.TotalTicketMoneyValue + PickUpCollector.Instance.TotalMoneyValue - moneyGiven;
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
    // Round up for sending in a bill
    private int RoundOrder(int amount)
    {
        foreach (int i in moneyAmounts)
        {
            if (i >= amount * 50)
            {
                return i;
            }
        }
        return 4000;
    }

    // Ask for tickets
    public void AskForTickets()
    {
        request = Random.Range(2, 10) * 5;
        DialogueBox.Instance.GiveDialogue(string.Format("{0} tickets, please.", request));
        int money = RoundOrder(request);
        MoneyController.Instance.GiveMoney(money);
        moneyGiven = money;
    }

    // Be requested to give more money
    public void GiveMoreMoney()
    {
        if (moneyGiven < request * 50)
        {
            MoneyController.Instance.GiveMoney(RoundOrder(request * 50 - moneyGiven));
        }
        else
        {
            DialogueBox.Instance.GiveDialogue("I already gave you enough money.");
            GameController.Instance.AddScore(-25);
        }
    }

    // Be asked to verify the order
    public void VerifyOrder()
    {
        DialogueBox.Instance.GiveDialogue(string.Format("I asked for {0} tickets.", request));
    }

    // Evaulate the purchase
    public void EvaluatePurchase()
    {
        if (PurchaseGood)
        {
            DialogueBox.Instance.GiveDialogue("Thanks!");
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
    private void MoveOn()
    {
        StartCoroutine(Utils.MoveObjectBy(transform, 15f * Vector3.right, 2f));
        Destroy(gameObject, 2f);
    }
    #endregion

    #region Coroutines

    #endregion
}
