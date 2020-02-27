using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageData 
{
    public int damage;
    public Unit ownerUnit;
    public Element element;
    public DamageData(Damage damage)
    {
        this.damage = damage.damage;
        ownerUnit = damage.ownerUnit;
        this.element = damage.element;
    }
}
