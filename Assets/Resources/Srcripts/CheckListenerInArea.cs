using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckListenerInArea : MonoBehaviour
{
    Speaker speaker;
    //List<string> NPC;
    //test
    // Start is called before the first frame update
    [SerializeField]private string[] listenerTags;
    void Start()
    {
        speaker = GetComponent<Speaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision + " is Enter");
            foreach(string i in listenerTags)
            {
                if(i == collision.gameObject.tag && collision.gameObject.GetComponent<Listener>() != null)
                {

                speaker.AddListener(collision.gameObject.GetComponent<Listener>());
                }

            }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.GetComponent<Listener>() != null)
        {
            speaker.RemoveListener(collision.gameObject.GetComponent<Listener>());
        }
    }

}
