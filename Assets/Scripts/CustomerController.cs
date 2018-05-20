using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject customerPrefab;                              // The customer prefab to spawn
    #endregion

    #region Properties
    public static CustomerController Instance { get; private set; } // The instance to reference
    
    // Returns the current customer
    public Customer CurrentCustomer { get; private set; }           // The current customer
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
        CurrentCustomer = Instantiate(customerPrefab, 15 * Vector3.left, Quaternion.identity, transform).GetComponent<Customer>();
        yield return StartCoroutine(Utils.MoveObject(CurrentCustomer.transform, Vector3.zero, 2f));
        CurrentCustomer.AskForTickets();
    }
    #endregion
}
