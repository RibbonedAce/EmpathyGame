using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpObject : MonoBehaviour {
    [SerializeField]
    int _value;
    bool IsSelected;
    public int Value
    {
        get
        {
            return _value;
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
