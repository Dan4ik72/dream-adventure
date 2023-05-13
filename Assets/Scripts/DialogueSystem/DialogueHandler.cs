using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;

    [SerializeField] private DialogueView _view;
    [SerializeField] private ChoiceDialogueView _choiceView;
    private DialogueNode _currentDialogueNode;

    private void Awake()
    {
        Debug.Log(_currentDialogueNode as DialogueChoiceNode);
    }

    public void StartDialogue()
    {
        _currentDialogueNode = _dialogue.EntryPoint;
        _view.gameObject.SetActive(true);
        _view.StartDialogue(_currentDialogueNode);
    }

    private void TryGetNextDialogueNode()
    {
        if (_currentDialogueNode.TryGetNextDialogueNode(out DialogueNode node))
        {
            if(node.DialogueNodeType == DialogueNodeType.Choice)

            _view.StartDialogue(node);
        }

        else
            EndDialogue();
    }

    private void EndDialogue()
    {
        _view.gameObject.SetActive(false);
    }
}
