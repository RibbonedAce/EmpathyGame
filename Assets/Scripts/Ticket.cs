using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : PickUpObject
{
    #region Variables

    #endregion

    #region Properties
    public override int GetMonetaryValue
    {
        get
        {
            return Value * 50;
        }
    }
    #endregion

    #region Events
    // Awake is called before Start
    private void Awake()
    {
        
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
