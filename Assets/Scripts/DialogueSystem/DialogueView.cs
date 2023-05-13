using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private TMP_Text _speakerName;
    [SerializeField] private TMP_Text _line;
    [SerializeField] private Image _leftSideImage;
    [SerializeField] private Image _rightSideImage;
    [SerializeField] private Button _continueButton;

    [Header("Choice buttons")]
    [SerializeField] private Button _goodChoiceButton;
    [SerializeField] private Button _badChoiceButton;

    [Header("Lines render preferencies")]
    [SerializeField] private float _textSpeed;

    private DialogueNode _currentDialogueNode;

    private Coroutine _textRenderCoroutine;

    private int _lineIndex;

    public event UnityAction DialogueStarted;
    public event UnityAction DialogueEnded;

    public event UnityAction GoodChoice;
    public event UnityAction BadChoice;

    public void StartDialogue(DialogueNode entryDialogueNode)
    {
        _currentDialogueNode = entryDialogueNode;
        ResetDialogue();
    }

    private void SetChoiceButtons(bool isActive)
    {
        _goodChoiceButton.gameObject.SetActive(isActive);
        _badChoiceButton.gameObject.SetActive(isActive);
    }

    public void RenderNextLine()
    {
        if (_textRenderCoroutine != null)
        {
            StopCoroutine(_textRenderCoroutine);
            _textRenderCoroutine = null;

            _line.text = _currentDialogueNode.Lines[_lineIndex - 1].Text;

            return;
        }

        if (_lineIndex > _currentDialogueNode.Lines.Count - 1)
        {
            EndDialogue();

            return;
        }

        SetImages();

        _line.text = string.Empty;

        _speakerName.text = _currentDialogueNode.Lines[_lineIndex].SpeakerName;

        _textRenderCoroutine = StartCoroutine(RenderLine());

        _lineIndex++;
    }

    public void RenderNextLineChoice()
    {
        if (_textRenderCoroutine != null)
        {
            StopCoroutine(_textRenderCoroutine);
            _textRenderCoroutine = null;

            _line.text = _currentDialogueNode.Lines[_lineIndex - 1].Text;

            return;
        }

        if (_lineIndex > _currentDialogueNode.Lines.Count - 1)
        {
            _badChoiceButton.onClick.AddListener(OnBadChoiceButtonClicked);

            return;
        }

        SetImages();

        _line.text = string.Empty;

        _speakerName.text = _currentDialogueNode.Lines[_lineIndex].SpeakerName;

        _textRenderCoroutine = StartCoroutine(RenderLine());

        _lineIndex++;
    }

    private void OnBadChoiceButtonClicked()
    {
        BadChoice?.Invoke();
    }

    private void OnGoodChoiceButtonClick()
    {
        GoodChoice?.Invoke();
    }

    private IEnumerator RenderLine()
    {
        var waitForSecondsBetweenChars = new WaitForSecondsRealtime(_textSpeed);

        foreach (char c in _currentDialogueNode.Lines[_lineIndex].Text)
        {
            _line.text += c;

            yield return waitForSecondsBetweenChars;
        }

        _textRenderCoroutine = null;
    }

    private void EndDialogue()
    {
        _line.text = string.Empty;

        DialogueEnded?.Invoke();

        gameObject.SetActive(false);
    }

    private void SetImages()
    {
        Sprite leftSideIconSprite = _currentDialogueNode.Lines[_lineIndex].LeftSideIcon;
        Sprite rightSideIconSprite = _currentDialogueNode.Lines[_lineIndex].RightSideIcon;

        Color originalColor = new Color(255, 255, 255, 255);
        Color transperedColor = new Color(_leftSideImage.color.r, _leftSideImage.color.g, _leftSideImage.color.b, 0f);

        if (leftSideIconSprite == null)
        {
            _leftSideImage.color = transperedColor;
        }
        else
        {
            _leftSideImage.color = originalColor;
            _leftSideImage.sprite = leftSideIconSprite;
        }

        if (rightSideIconSprite == null)
        {
            _rightSideImage.color = transperedColor;
        }
        else
        {
            _rightSideImage.color = originalColor;
            _rightSideImage.sprite = rightSideIconSprite;
        }
    }

    private void ResetDialogue()
    {
        _lineIndex = 0;

        _textRenderCoroutine = null;
    }
}
