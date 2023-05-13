using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Create new dalogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private List<DialoguePart> _dialogue;
}
