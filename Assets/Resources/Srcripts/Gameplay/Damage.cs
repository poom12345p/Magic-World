using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int _damage;
    public int damage  // property
    {
        get { return _damage; }   // get method
       
    }
    
    //public float speed,bulletDistance;
    //public bool isOneTarget,isBullet;
    //public ParticleSystem effect;
    protected Collider myCol;
    public Unit ownerUnit;
    public List<Unit> takenUnit = new List<Unit>();
    public Element damageElement;
    //public bool isDestroyafterDoneDamage = false;
    public float destoryDelay;
    public string[] receiverTag;
   // [Header("for spawning")]
    //public damageHitbox myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp()
    {
        myCol = gameObject.GetComponent<Collider>();
        if (myCol.enabled)
        {
            deActiveHitbox();
        }
    }

    public void regisUnit(Unit unit)
    {
        if (!takenUnit.Contains(unit))
        {
            takenUnit.Add(unit);
        }
        //foreach (afterDoneDamage atf in afterDoneDamagesList)
        //{
        //    atf.doActionADD(ownerUnit, unit, this);
        //}
        //if (isDestroyafterDoneDamage) Invoke("selfDestory", destoryDelay);
        /* if(isOneTarget && takenUnit.Count >=1)
         {
             deActiveHitbox();
         }*/
    }
    public void selfDestory()
    {
        //foreach (beforeDestory bd in beforeDestoryList)
        //{
        //    bd.doAction();
        //}
        Destroy(gameObject, destoryDelay);
    }
    public bool isDamaged(Unit unit)
    {
        return takenUnit.Contains(unit);
    }

    public void deActiveHitbox()
    {
        takenUnit.Clear();
        if (myCol != null) myCol.enabled = false;
        
    }


    public void activeHitbox()
    {
        takenUnit.Clear();

        myCol.enabled = true;
    }

    public void setDamage(int damage)
    {
        _damage = damage;
    }

    public bool canDoDamage(Unit target)
    {
        if (takenUnit.Contains(target))
        {
            return false;
        }
        foreach (var tag in receiverTag)
        {
            if(tag == target.tag )
            {
                return true;
            }
        }
        return false;
    }




    //public void addAfterDoneDamage(afterDoneDamage aft)
    //{
    //    if (!afterDoneDamagesList.Contains(aft))
    //    {
    //        afterDoneDamagesList.Add(aft);
    //    }
    //}

    //public void removeAfterDoneDamage(afterDoneDamage aft)
    //{
    //    if (afterDoneDamagesList.Contains(aft))
    //    {
    //        afterDoneDamagesList.Remove(aft);
    //    }
    //}

    public void setOwner(Unit owner)
    {
        this.ownerUnit = owner;
       
    }


    //public damageHitbox spawnDuplicate(Transform spot)
    //{

    //    damageHitbox dambox = Instantiate(myPrefab);
    //    Bullet myBulltet = dambox.GetComponent<Bullet>();
    //    Bullet modelBullet = gameObject.GetComponent<Bullet>();
    //    dambox.transform.position = spot.position;
    //    dambox.transform.eulerAngles = spot.transform.eulerAngles;
    //    dambox.transform.localScale = dambox.transform.localScale * (1 + sizeMultifier);
    //    // dambox.transform.eulerAngles += new Vector3(0, -(spreadAngle / 2) + (i * spreadAngle / 4), 0);
    //    dambox.setDamage(this.damage);
    //    dambox.duplicateAfterDoneDamage(this);
    //    dambox.isFriendly = this.isFriendly;
    //    dambox.isUnFriendly = this.isUnFriendly;
    //    if (myBulltet != null)
    //    {
    //        myBulltet.setSpeed(modelBullet.speed);
    //        myBulltet.setBulletDistance(modelBullet.bulletDistance);
    //    }
    //    dambox.setOwner(this.ownerUnit);
    //    dambox.ultiRegen = this.ultiRegen;
    //    return dambox;
    //}

    //public void spawnDuplicateN(Transform spot)
    //{

    //    spawnDuplicate(spot);
    //}
}
