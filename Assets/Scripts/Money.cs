using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : PickUpObject
{
    

    #region Events
    // Awake is called before Start
    private void Awake()
    {

    }
    public override int GetMonetaryValue
    {
        get
        {
            return this.Value;
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

    #endregion

    #region Coroutines

    #endregion
}
