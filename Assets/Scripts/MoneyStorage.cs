﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStorage : MonoBehaviour {
    [SerializeField]
    Vector2 size;
    [SerializeField]
    Vector2 direction;
    [SerializeField]
    float angle;
    int value = 0;

    // Use this for initialization
    void Start()
    {
        size = new Vector2(transform.lossyScale.x, transform.lossyScale.y);
        size *= 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
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
                AddMoneyValue(hit.transform.gameObject.GetComponent<Money>());
            }
        }
    }
    public void AddMoneyValue(Money ticket)
    {
        if (ticket != null)
        {
            GameController.Instance.AddScore(ticket.Value);
            AudioController.Instance.PlayClip(0);
            Destroy(ticket.gameObject);
        }
    }
    public void GetTicket(int value)
    {
        // int val = storageList.GetValue(value);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(size.x, size.y, 0.0f)); // Bec
    }
}
