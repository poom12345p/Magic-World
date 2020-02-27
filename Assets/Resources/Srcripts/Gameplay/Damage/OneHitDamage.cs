using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitDamage : Damage
{
    public float disableDelay;
    private bool isActive=false;
        // Start is called before the first frame update
    void Start()
    {
        base.SetUp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (!isActive)
        {
            isActive = true;
            base.StartDamaging();
            Invoke("EndAttack", disableDelay);
        }
    }

    public void EndAttack()
    {
        base.EndDamaging();
        isActive = false;
    }

 
}
