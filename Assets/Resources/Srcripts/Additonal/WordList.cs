using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "custom/WordList")]
public class WordList : ScriptableObject
{
    public string listName;
    public string[] wordslist;
}
