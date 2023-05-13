using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [SerializeField] private string _speakerName;
    [SerializeField] private Sprite _rightSideIcon;
    [SerializeField] private Sprite _leftSideIcon;
    [SerializeField, TextArea] private string _text;

    public string SpeakerName => _speakerName;
    public Sprite RightSideIcon => _rightSideIcon;
    public Sprite LeftSideIcon => _leftSideIcon;
    public string Text => _text;
}
