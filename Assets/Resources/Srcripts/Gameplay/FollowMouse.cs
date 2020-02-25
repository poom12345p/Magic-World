using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(new Vector3(0, 0, 1), 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform.position);
        Vector3 cp=Vector3.one;
        //Vector3 p = Input.mousePosition;
        //p.z = transform.position.z;
        //Vector3 pos = Camera.main.ScreenToWorldPoint(p);
        //transform.position = pos;
        
        Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float disToPlane;
        if (plane.Raycast(ray,out disToPlane))
        {
            // Create a particle if hit
            cp = ray.GetPoint(disToPlane);

        }
      //  Debug.Log(cp);
        transform.position = cp;
       // transform.position = new Vector3(cp.x, cp.y, transform.position.z);
    }
}
