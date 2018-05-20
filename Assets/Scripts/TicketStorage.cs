using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketStorage : MonoBehaviour {
    [SerializeField]
    Vector2 size;
    [SerializeField]
    Vector2 direction;
    [SerializeField]
    float angle;
    MonetaryStorage storageList;
	// Use this for initialization
	void Start () {
        storageList = new MonetaryStorage();
    }
	
	// Update is called once per frame
	void Update () {
        CheckSpace();
    }
    void CheckSpace()
    {
        RaycastHit2D[] hitList;
        hitList = Physics2D.BoxCastAll(transform.position, size, angle, direction);

        if (hitList.Length > 0)
        {
            foreach (RaycastHit2D hit in hitList)
            {
                AddTicketValue(hit.transform.gameObject.GetComponent<Ticket>());
            }
        }
    }
    public void AddTicketValue(Ticket ticket)
    {
        if (ticket != null)
        {
            storageList.AddValue(ticket.gameObject);
            Destroy(ticket.gameObject);
        }
    }
    public void GetTicket(int value)
    {
        int val = storageList.GetValue(value);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(size.x, size.y, 0.0f)); // Bec
    }
}
