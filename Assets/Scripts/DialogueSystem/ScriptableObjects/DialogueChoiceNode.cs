using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Create new choice node")]
public class DialogueChoiceNode : DialogueNode
{
    [SerializeField] private List<DialogueChoice> _choices = new List<DialogueChoice>(2);

    public override bool TryGetNextDialogueNode(out DialogueNode node)
    {
        throw new System.NotImplementedException();
    }
}
