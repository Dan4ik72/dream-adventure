using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public abstract class DialogueNode : ScriptableObject
{
    [SerializeField] private List<DialogueLine> _lines;

    public IReadOnlyList<DialogueLine> Lines => _lines;

    public abstract DialogueNodeType DialogueNodeType { get; }

    public abstract bool TryGetNextDialogueNode(out DialogueNode node);
}

public enum DialogueNodeType
{
    Normal, 
    Choice
}
