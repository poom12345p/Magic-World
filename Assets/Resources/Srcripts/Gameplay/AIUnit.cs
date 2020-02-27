using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUnit : MonoBehaviour
{
    // Start is called before the first frame update
    public AIView view;
    public AIMove move;
    public Transform target;
    public enum ACTION
    {
        TRACKING,ATTACK,ROMMING,IDLE
    }

    [SerializeField] ACTION unitAction;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (unitAction == ACTION.TRACKING)
        {
            if (target == null)
            {
               target = FindNearestTarget();
            }
            else
                FollowTarget();
            Debug.Log(gameObject + " is Tracking" +target);
        }
    }
    public void FollowTarget()
    {
        move.SetDestination(target.position);

    }

    public Transform FindNearestTarget()
    {
        Transform t = null;
        if (view.targetLists.Count > 0)
        {
            t= view.targetLists[0];
            float dist = Vector3.Distance(t.position, transform.position);
            foreach (var i in view.targetLists)
            {
                if (Vector3.Distance(i.position, transform.position) < dist)
                {
                    t = i;
                }
            }

        }
        return t;
    }

    public void SetTarget(Unit t)
    {
        target = t.transform;
    }

    public virtual void AttackAction()
    {

    }

    public virtual void TrackingAction()
    {

    }
}
