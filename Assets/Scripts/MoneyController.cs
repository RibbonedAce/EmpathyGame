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
    public void GiveMoney(int amount)
    {
        for (int i = 0; i < 100 && amount > 0; ++i)
        {
            foreach (GameObject c in currency)
            {
                Money m = c.GetComponent<Money>();
                if (m.Value <= amount)
                {
                    Vector3 offset = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 0.5f));
                    GameObject g = Instantiate(c, offset, Quaternion.identity, transform);
                    StartCoroutine(Utils.MoveObjectBy(g.transform, 3f * Vector3.down, 1f));
                    g.GetComponent<SpriteRenderer>().sortingOrder = i;
                    amount -= m.Value;
                    break;
                }
            }
        }
    }

    // Spawn money in the world
    public void SpawnMoney(int amount)
    {
        for (int i = 0; i < 100 && amount > 0; ++i)
        {
            foreach (GameObject c in currency)
            {
                Money m = c.GetComponent<Money>();
                if (m.Value <= amount)
                {
                    GameObject g = Instantiate(c, Vector3.down, Quaternion.identity, transform);
                    g.GetComponent<SpriteRenderer>().sortingOrder = i;
                    amount -= m.Value;
                    break;
                }
            }
        }
    }

    // Return the value of a collection of money
    public int TotalValue(Money[] money)
    {
        int result = 0;
        foreach (Money m in money)
        {
            result += m.Value;
        }
        return result;
    }
    #endregion

    #region Coroutines

    #endregion
}
