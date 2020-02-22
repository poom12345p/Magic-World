using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
   [SerializeField] List<Listener> allListener = new List<Listener>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SentWord(string word)
    {
        foreach (Listener listener in allListener)
        {
            listener.ListenWord(word);
        }
    }

    public void AddListener(Listener name)
    {
        if (!allListener.Contains(name))
        {
            allListener.Add(name);
            
        }
    }

    public void RemoveListener(Listener name)
    {
        if (allListener.Contains(name))
        {
            allListener.Remove(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
