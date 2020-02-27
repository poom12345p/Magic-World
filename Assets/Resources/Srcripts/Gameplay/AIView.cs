using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIView : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string[] targetTags;
    public List<Transform> targetLists = new List<Transform>();
    [HideInInspector]public  float range;
    void Start()
    {
        range= gameObject.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        foreach (string i in targetTags)
        {
            if (i == collision.gameObject.tag)
            {
                if (!targetLists.Contains(collision.transform))
                {
                    targetLists.Add(collision.transform);
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (targetLists.Count != 0)
        {
            if (targetLists.Contains(collision.transform))
            {
                targetLists.Remove(collision.transform);
            }
        }
    }

}
