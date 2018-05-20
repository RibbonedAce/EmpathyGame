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
                RaycastHit2D[] hitList = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), RayCastDir);
                if (hitList.Length > 0)
                {
                    RaycastHit2D hit = hitList[0];
                    int maxLayer = int.MinValue;
                    foreach (RaycastHit2D r in hitList)
                    {
                        SpriteRenderer s = r.transform.GetComponent<SpriteRenderer>();
                        if (s.sortingOrder > maxLayer)
                        {
                            hit = r;
                            maxLayer = s.sortingOrder;
                        }
                    }
                    if (hit.transform.GetComponents<PickUpObject>().Length > 0)
                    {
                        SelectedObject = hit.transform.gameObject;
                        distanceFromCamera = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(hit.point.x, hit.point.y, hit.transform.position.z)).magnitude;


                        Offset = new Vector2(hit.transform.position.x, hit.transform.position.y) - hit.point;
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 v = ray.GetPoint(distanceFromCamera) + new Vector3(Offset.x, Offset.y, 0.0f);
                v.z = 0.0f;
                SelectedObject.transform.position = v;
            }
            else
            {
                SelectedObject = null;
            }
        }
	}
}
