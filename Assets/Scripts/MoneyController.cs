using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    public GameObject[] currency;                                   // The different money objects
    #endregion

    #region Properties
    public static MoneyController Instance { get; private set; }    // The instance to reference
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
    // Give an amount of money
    public GameObject[] SpawnMoney(int amount, Transform parent)
    {
        List<GameObject> result = new List<GameObject>();
        while (amount > 0)
        {
            foreach (GameObject c in currency)
            {
                Money m = c.GetComponent<Money>();
                if (m.Value < amount)
                {
                    result.Add(Instantiate(c, parent));
                    amount -= m.Value;
                    break;
                }
            }
        }
        return result.ToArray();
    }
    #endregion

    #region Coroutines

    #endregion
}
