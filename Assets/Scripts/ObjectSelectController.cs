using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectController : MonoBehaviour {
    Vector3 RayCastDir;
    Vector2 Offset;
    GameObject SelectedObject;
    float distanceFromCamera;
    
	// Use this for initialization
	void Start () {
        SelectedObject = null;

    }
	
	// Update is called once per frame
	void Update () {
		if(SelectedObject == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hitList = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), RayCastDir);
                if (hitList && hitList.transform.GetComponents<PickUpObject>().Length > 0)
                {
                    SelectedObject = hitList.transform.gameObject;
                    Offset = new Vector2(hitList.transform.position.x, hitList.transform.position.y)- hitList.point;
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                SelectedObject.transform.position = ray.GetPoint(distanceFromCamera) + new Vector3(Offset.x,Offset.y);
            }
            else
            {
                SelectedObject = null;
            }
        }
	}
}
