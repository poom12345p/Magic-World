using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Listener : MonoBehaviour
{
    [System.Serializable]
    struct WordInteract
    {
       public string word;
        public UnityEvent wordEvent;
    }
    public Speaker mySpeaker;
    public UnityEvent allWordEvent;
    [SerializeField]
    private List<WordInteract> interactiveWord;
    [SerializeField] protected bool isListenVoiceInput;
    // Start is called before the first frame update
    void Start()
    {
        if(isListenVoiceInput)
        {
            VoiceRegognite.VoiceRecigniteSpeaker.AddListener(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ListenWord(string w)
    {
        allWordEvent.Invoke();
        foreach (var interact in interactiveWord)
        {
            if(interact.word == w)
            {
                interact.wordEvent.Invoke();
                break;
            }
        }
    }
}
