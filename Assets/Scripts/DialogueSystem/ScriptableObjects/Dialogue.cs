using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue" , menuName = "Dialogue/Create new dilaogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private DialogueNode _entryPoint;

    public DialogueNode EntryPoint => _entryPoint;
}
