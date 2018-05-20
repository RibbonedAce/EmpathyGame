using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetaryStorage{
    Storage ValueList = null;
  
    class Storage
    {
        public Storage Next = null;
        int value = 0;
        public Storage(int v, Storage next)
        {
            value = v;
            Next = next;
        }
        public int Value
        {
            get
            {
                return value;
            }
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddValue(GameObject g)
    {
        PickUpObject m = g.GetComponent<PickUpObject>();
        if (m != null)
        {
            ValueList = new Storage(m.Value, ValueList);
        }
    }
    
    public int GetValue(int value)
    {
        Storage cur = ValueList;
        Storage prev = ValueList;
        while (cur != null)
        {
            if (cur.Value == value)
            {
                if(cur == prev)
                {
                    ValueList = ValueList.Next;
                }
                else
                {
                    prev.Next = cur.Next;
                }
                return value;
            }
            prev = cur;
            cur = cur.Next;
        }
        return 0;
    }
}

