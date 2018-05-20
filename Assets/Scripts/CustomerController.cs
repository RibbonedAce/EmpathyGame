using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Customer[] customers;                                   // All of the customers in line 
    private int customerIndex = -1;                                 // The customer currently being served
    #endregion

    #region Properties
    public static CustomerController Instance { get; private set; } // The instance to reference
    
    // Returns the current customer
    public Customer CurrentCustomer
    {
        get
        {
            return customerIndex < customers.Length ? customers[customerIndex] : null;
        }
    }
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
        SummonNextCustomer();
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
    // Summon the next customer over
    public void SummonNextCustomer()
    {
        StartCoroutine(SummonCustomer());
    }

    // Request the customer to give more money
    public void GiveMoreMoney()
    {
        CurrentCustomer.GiveMoreMoney();
    }

    // Ask the customer to verify the order
    public void VerifyOrder()
    {
        CurrentCustomer.VerifyOrder();
    }

    // Ask the customer if the purchase is fine
    public void EvaluatePurchase()
    {
        CurrentCustomer.EvaluatePurchase();
    }
    #endregion

    #region Coroutines
    // Go to the next customer
    private IEnumerator SummonCustomer()
    {
        if (++customerIndex < customers.Length)
        {
            yield return StartCoroutine(Utils.MoveObject(CurrentCustomer.transform, Vector3.zero, 2f));
            CurrentCustomer.AskForTickets();
        }
    }
    #endregion
}
