using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDispllay : Listener
{
    [SerializeField]private Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
        if (isListenVoiceInput)
        {
            VoiceRegognite.VoiceRecigniteSpeaker.AddListener(this);
        }
    }

    // Update is called once per frame
    public override void ListenWord(string w)
    {
        displayText.text = w;
    }
}
