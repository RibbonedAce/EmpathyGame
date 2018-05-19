using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private int value;                          // How much the money's worth
    #endregion

    #region Properties
    public int Value { get { return value; } }  // Returns value
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
