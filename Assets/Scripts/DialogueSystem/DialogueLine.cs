using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [SerializeField] private Sprite _speakerName;
    [SerializeField] private Sprite _speakerIcon;
    [SerializeField, TextArea] private string _text;
}
