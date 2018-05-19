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
    public GameObject[] SpawnMoney(int amount)
    {
        List<GameObject> result = new List<GameObject>();
        for (int i = 0; i < 100 && amount > 0; ++i)
        {
            foreach (GameObject c in currency)
            {
                Money m = c.GetComponent<Money>();
                if (m.Value <= amount)
                {
                    Vector3 offset = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f));
                    GameObject g = Instantiate(c, offset, Quaternion.identity, transform);
                    result.Add(g);
                    Vector3[] positions = new Vector3[] { g.transform.position + 5f * Vector3.down };
                    float[] times = new float[] { 1f };
                    StartCoroutine(Utils.MoveObject(g.transform, positions, times));
                    g.GetComponent<SpriteRenderer>().sortingOrder = i;
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
