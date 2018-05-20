using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

    [SerializeField]
    GameObject ticketObject;
    public int value;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {
        GameObject g = Instantiate(ticketObject);
        g.GetComponent<PickUpObject>().Value = value;
        AudioController.Instance.PlayClip(2);
    }

    public void ChangeValue(string str)
    {
        value = int.Parse(str);
    }
}
