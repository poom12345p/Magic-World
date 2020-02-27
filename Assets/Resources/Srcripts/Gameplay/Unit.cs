using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//interface AfterUnitAction
//{
//    void AfterReciveDamage(Damage damage);

//}
public class Unit : MonoBehaviour
{

    [SerializeField]
   private int maxHP, maxMP;
    
    public enum ElementProperty
    {
        WEAK,ABSORB,BLOCK,RESIST,NONE
    }

    [SerializeField]protected AIUnit AI;
    private int HP, MP;
    [SerializeField] private GameObject HPBarPerfab;
     private ProcessBar HPbar;
     private ProcessBar MPbar;
    [SerializeField]protected ElementProperty 
          NONE_pty=ElementProperty.NONE
        , HOLY_pty = ElementProperty.NONE
        , FIRE_pty = ElementProperty.NONE
        , WATER_pty = ElementProperty.NONE
        , EARTH_pty = ElementProperty.NONE
        , WIND_pty = ElementProperty.NONE;

 
    public UnityEvent afterReciveDamage;
    public UnityEvent afterReciveDeath;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.right * Time.deltaTime*20, Space.World);
    }

    protected void SetUp()
    {
        HP = maxHP;
        GameObject canvas = GameObject.Find("Canvas");
        if (HPBarPerfab != null)
        {
            HPbar = CreateProcessBar(HPBarPerfab, canvas.transform);
            UpdateHPBar();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Damage>() != null)
        {
            Damage damage = other.GetComponent<Damage>();

           if(damage.canDoDamage(this))
            {
                Debug.Log(other.GetComponent<Damage>());
                damage.regisUnit(this);
                ReceiveDamage(damage.GetDamageData());
            }
         
        }      

    }

    public virtual void ReceiveDamage(DamageData damage)
    {
        int trueDamage= damage.damage;
        ElementProperty pty = GetProperty(damage.element);
        if (pty == ElementProperty.WEAK)
        {
            trueDamage = (int)((float)trueDamage * 2f);
        }
        else if (pty == ElementProperty.ABSORB)
        {
            //Heal();
            trueDamage = -1;
        }
        else if (pty == ElementProperty.BLOCK)
        {
            ReceiveHeal(trueDamage);
            trueDamage = 0;
        }
        else if (pty == ElementProperty.RESIST)
        {
            //Heal();
            trueDamage = (int)((float)trueDamage * 0.5f);
            if (trueDamage < 1) trueDamage = 1;
        }

        if (trueDamage >= 0)
        {
            HP -= damage.damage;
            afterReciveDamage.Invoke();
            if (HP <0)
            {
                HP = 0;
                afterReciveDeath.Invoke();
                //death;
            }
        }
        UpdateHPBar();
      //  Debug.Log(HP);
    }

    public void ReceiveHeal(int healAmount)
    {
        HP += healAmount;
        if(HP > maxHP)
        {
            HP = maxHP;
        }
        UpdateHPBar();
    }

    public ProcessBar CreateProcessBar(GameObject barPerfab,Transform canvas)
    {
        ProcessBar bar = Instantiate(barPerfab, canvas.transform).GetComponent<ProcessBar>();
        bar.gameObject.GetComponent<UIFollowObj>().SetTarget(this.transform);
        return bar;
    }

    void UpdateHPBar()
    {
        HPbar.updateGauge(maxHP, HP);
    }

    private ElementProperty GetProperty(Element element)
    {
        switch(element)
        {
            case Element.NONE:
                return NONE_pty;
            case Element.FIRE:
                return FIRE_pty;
            case Element.WATER:
                return WATER_pty;
            case Element.WIND:
                return WATER_pty;
            case Element.EARTH:
                return EARTH_pty;
            case Element.HOLY:
                return EARTH_pty;
            default:
                return ElementProperty.NONE;
        }
    }
}
