using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpObject : MonoBehaviour {
    [SerializeField]
    protected int _value;
    protected bool IsSelected;
    protected bool isInitialized = false;
    public virtual int Value
    {
        get
        {
            return _value;
        }
        set
        {
            if(!isInitialized)
            {
                isInitialized = true;
                _value = value;
            }
        }
    }
    public abstract int GetMonetaryValue
    {
        get;
    }
    public bool GetSetSelected
    {
        get
        {
            return IsSelected;
        }
        set
        {
            IsSelected = value;
        }
    }
}
