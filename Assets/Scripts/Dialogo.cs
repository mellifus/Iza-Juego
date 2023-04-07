using System.Collections;
using UnityEngine;
using TMPro;
public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(2,6)] private string[] dialoguelines;

    private float typingTime = 0.05f;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
            
            if (isPlayerInRange && Input.GetButtonDown("Fire2"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialoguelines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialoguelines[lineIndex];
            }
        }
    }
    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialoguelines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialoguelines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            _audio.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
