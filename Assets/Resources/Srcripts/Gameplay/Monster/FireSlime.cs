using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlime : Unit
{
    private bool isFire = true;
    [SerializeField]ContinueDamage FireArea;
    public float recoveryTime;
    // Start is called before the first frame update
    void Start()
    {
        base.SetUp();
        recoverFire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkDamage(DamageData damage)
    {
        if (damage.element == Element.WATER)
        {
            isFire = false;
            removeFire();
            NONE_pty = ElementProperty.WEAK;
            Invoke("recoverFire", recoveryTime);
            
        }
    }
    public override void ReceiveDamage(DamageData damage)
    {
        base.ReceiveDamage(damage);
        checkDamage(damage);
        if(AI.target == null)
        {
            AI.SetTarget(damage.ownerUnit);
        }
    }

    public void removeFire()
    {
        FireArea.EndDamaging();
    }

    public void recoverFire()
    {
        FireArea.StartDamaging();
        NONE_pty = ElementProperty.RESIST;
    }
}
