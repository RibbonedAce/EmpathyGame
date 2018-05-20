using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpObject : MonoBehaviour {
    [SerializeField]
    int _value;
    bool IsSelected;
    bool isInitialized = false;
    public int Value
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
