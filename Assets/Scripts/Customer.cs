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
            return true;
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
    public void AskForTickets()
    {
        DialogueBox.Instance.GiveDialogue("3 tickets, please.");
        GameObject[] money = MoneyController.Instance.SpawnMoney(999);
    }

    // Evaulate the purchase
    public void EvaluatePurchase()
    {
        if (PurchaseGood)
        {
            DialogueBox.Instance.GiveDialogue("Thanks!");
            MoveOn();
            CustomerController.Instance.SummonNextCustomer();
        }
        else
        {
            DialogueBox.Instance.GiveDialogue("That's not what I wanted.");
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
