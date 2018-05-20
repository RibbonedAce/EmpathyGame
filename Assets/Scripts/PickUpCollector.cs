using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollector : MonoBehaviour
{
    [SerializeField]
    Vector2 size;
    [SerializeField]
    Vector2 direction;
    [SerializeField]
    float angle;
    int totalTicketMonetaryValue;
    int totalMoneyMonetaryValue;
    int totalTicketValue;
    int totalMoneyValue;
    RaycastHit2D[] hitList;

    public static PickUpCollector Instance { get; private set; }

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitList = Physics2D.BoxCastAll(transform.position, size, angle, direction);
        int ticketsValue = 0;
        int moneyValue = 0;
        int ticketsMonetaryValue = 0;
        int moneyMonetaryValue = 0;
        if (hitList.Length > 0)
        {
            PickUpObject pickUp = null;
            foreach (RaycastHit2D hit in hitList)
            {
                pickUp = hit.transform.GetComponent<PickUpObject>();
                if (pickUp != null)
                {
                    if (pickUp.GetType() == typeof(Money))
                    {
                        moneyValue += pickUp.Value;
                        moneyMonetaryValue += pickUp.GetMonetaryValue;
                    }
                    else
                    {
                        ticketsValue += pickUp.Value;
                        ticketsMonetaryValue += pickUp.GetMonetaryValue;
                    }
                }
            }
        }
        totalMoneyValue = moneyValue;
        totalTicketValue = ticketsValue;
        totalMoneyMonetaryValue = moneyMonetaryValue;
        totalTicketMonetaryValue = ticketsMonetaryValue;
    }
    public int TotalMoneyMonetaryValue
    {
        get
        {
            return totalMoneyMonetaryValue;
        }
    }
    public int TotalTicketMoneyValue
    {
        get
        {
            return totalTicketMonetaryValue;
        }
    }
    public int TotalMoneyValue
    {
        get
        {
            return totalMoneyMonetaryValue;
        }
    }
    public int TotalTicketValue
    {
        get
        {
            return totalTicketMonetaryValue;
        }
    }
    public void DestroyCollection()
    {
        foreach (RaycastHit2D hit in hitList)
        {
            StartCoroutine(Utils.MoveObject(hit.transform, Vector3.zero, 0.5f));
            Destroy(hit.transform.gameObject, 0.5f);
        }
        hitList = null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(size.x, size.y, 0.0f)); // Bec
    }
}
