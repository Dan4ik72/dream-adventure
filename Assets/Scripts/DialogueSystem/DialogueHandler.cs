using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler 
{
    [SerializeField] private Dialogue _dialogue;

    private DialogueNode _currentDialogueNode;

    private void OnDialogueStarted()
    {
        _currentDialogueNode = _dialogue.EntryPoint;
    } 

    private void OnDialogueNodeChange()
    {

    }
}
