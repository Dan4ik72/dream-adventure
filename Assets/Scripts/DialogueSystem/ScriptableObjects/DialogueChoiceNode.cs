using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Create new choice node")]
public class DialogueChoiceNode : DialogueNode
{
    [SerializeField] private DialogueChoice _goodChoice;
    [SerializeField] private DialogueChoice _badChoice;

    private DialogueChoice _playerChoice;

    public override DialogueNodeType DialogueNodeType => DialogueNodeType.Choice;

    public override bool TryGetNextDialogueNode(out DialogueNode node)
    {
        node = _playerChoice.NextNode;

        return true;
    }
}
