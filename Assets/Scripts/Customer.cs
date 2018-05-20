using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    #region Variables
    private int request;    // How many tickets that are wanted
    private int moneyGiven; // The amount of money given to pay
    #endregion

    #region Properties

    // Whether what is being given is acceptable
    private bool PurchaseGood
    {
        get
        {
            return PickUpCollector.Instance.TotalTicketValue == request && PickUpCollector.Instance.TotalTicketMoneyValue + PickUpCollector.Instance.TotalMoneyValue == moneyGiven;
        }
    }

    // The difference in valid exchange
    private int PurchaseDiff
    {
        get
        {
            return PickUpCollector.Instance.TotalTicketMoneyValue + PickUpCollector.Instance.TotalMoneyValue - (moneyGiven - request * 50);
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
    // Initialize customer


    // Ask for tickets
    public void AskForTickets()
    {
        request = Random.Range(2, 10);
        DialogueBox.Instance.GiveDialogue(string.Format("{0} tickets, please.", request));
        int money = request * 50 + Random.Range(-50, 50);
        MoneyController.Instance.GiveMoney(money);
        moneyGiven = money;
    }

    // Evaulate the purchase
    public void EvaluatePurchase()
    {
        Debug.Log(PurchaseDiff);
        if (PurchaseGood)
        {
            DialogueBox.Instance.GiveDialogue("Thanks!");
            GameController.Instance.AddScore(100 - Mathf.Abs(PurchaseDiff));
            PickUpCollector.Instance.DestroyCollection();
            MoveOn();
            CustomerController.Instance.SummonNextCustomer();
        }
        else
        {
            DialogueBox.Instance.GiveDialogue("That's not what I wanted.");
            GameController.Instance.AddScore(-50);
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
