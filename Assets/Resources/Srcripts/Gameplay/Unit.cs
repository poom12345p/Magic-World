using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
   private int maxHP, maxMP;
 
    private int HP, MP;
    [SerializeField] private GameObject HPBarPerfab;
     private ProcessBar HPbar;
     private ProcessBar MPbar;
    public Element[] weakElement;
    public Element[] blockElement;
    public Element[] absorbElement;
    public Element[] resistElement;
    public float elementResist;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        GameObject canvas = GameObject.Find("Canvas");
        if (HPBarPerfab != null)
        {
            HPbar = CreateProcessBar(HPBarPerfab, canvas.transform);
            UpdateHPBar();
        }
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.right * Time.deltaTime*20, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Damage>() != null)
        {
            Damage damage = other.GetComponent<Damage>();

           if(damage.canDoDamage(this))
            {
                Debug.Log(other.GetComponent<Damage>());
                TakeDamage(damage);
            }
         
        }
       


    

    }

    public void TakeDamage(Damage damage)
    {
        damage.regisUnit(this);
        HP -= damage.damage;
        UpdateHPBar();
        Debug.Log(HP);
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
}
