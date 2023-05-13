using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public abstract class DialogueNode : ScriptableObject
{
    [SerializeField] private List<DialogueLine> _lines;
    
    public abstract bool TryGetNextDialogueNode(out DialogueNode node);
}
