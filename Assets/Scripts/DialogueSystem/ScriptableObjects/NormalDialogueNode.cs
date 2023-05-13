using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Create normal dialogue node")]
public class NormalDialogueNode : DialogueNode
{
    [SerializeField] private DialogueNode _nextDialogueNode;

    public override DialogueNodeType DialogueNodeType => DialogueNodeType.Normal;
    

    public override bool TryGetNextDialogueNode(out DialogueNode node)
    {
        node = _nextDialogueNode;

        return _nextDialogueNode != null;
    }
}
