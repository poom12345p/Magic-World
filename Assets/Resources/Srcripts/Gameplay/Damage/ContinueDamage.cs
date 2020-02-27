using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueDamage : Damage
{

    public float repeatTime;
    public float TotaltimeTime;
    private bool isActive;
    // Start is called before the first frame update
    void Awake()
    {
       base.SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Damaging()
    {
        float timmer = 0;
        while (timmer < TotaltimeTime || TotaltimeTime==0)
        {
          //  Debug.Log(gameObject + "   |" + " Do damage");
            base.activeHitbox();
            yield return new WaitForFixedUpdate();
            base.deActiveHitbox();
            yield return new WaitForSeconds(repeatTime);
            timmer += repeatTime;
          
        }
        isActive = false;
    }

    public override void StartDamaging()
    {
        if (!isActive)
        {
            isActive = true;
            
            StartCoroutine("Damaging");
        }
    }

    public override void EndDamaging()
    {
        if (isActive)
        {
            StopCoroutine("Damaging");
            isActive = false;
        }

    }
}
