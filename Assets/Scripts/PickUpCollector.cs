using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollector : MonoBehaviour
{
    [SerializeField]
    Vector2 size;
    [SerializeField]
    Vector2 direction;
    [SerializeField]
    float angle;
    public int score;
    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hitList = Physics2D.BoxCastAll(transform.position, size, angle, direction);
        int s = 0;
        if (hitList.Length > 0)
        {
            PickUpObject pickUp = null;
            foreach (RaycastHit2D hit in hitList)
            {
                pickUp = hit.transform.GetComponent<PickUpObject>();
                s += pickUp.GetMonetaryValue;
            }
        }
        score = s;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(size.x, size.y, 0.0f)); // Bec
    }
}
