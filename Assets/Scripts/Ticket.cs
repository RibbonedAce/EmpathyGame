using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : PickUpObject
{
    #region Variables

    #endregion

    #region Properties

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

    public override int GetMonetaryValue
    {
        get
        {
            return this.Value / 2;
        }
    }

    #endregion

    #region Coroutines

    #endregion
}
