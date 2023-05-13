using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueChoice
{
    [SerializeField] private string _text;
    [SerializeField] DialogueNode _nextNode;
}
