using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

    [SerializeField]
    GameObject ticketObject;
    // Use this for initialization
    void Start()
    {
        SpawnObject(10);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnObject(int value)
    {
        GameObject g = Instantiate(ticketObject);
        g.GetComponent<PickUpObject>().Value = value;
    }
}
