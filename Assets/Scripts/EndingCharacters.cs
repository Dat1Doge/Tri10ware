using System.Collections;
using TMPro;
using UnityEngine;

public class EndingCharacters : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private float timeBetweenCharacters;
    [SerializeField] private string endDialogue;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject endscreen;

    private void Start()
    {
        StartCoroutine(Typewriter());
    }
    private void Update()
    {
        gameObject.transform.position += Vector3.up *Time.deltaTime *scrollSpeed;
    }

    IEnumerator Typewriter()
    {
        string textBuffer = null;
        foreach (char c in textBox.text)
        {
            textBuffer += c;

            textBox.text = textBuffer;

            yield return new WaitForSeconds(1/timeBetweenCharacters);
        }
        yield return new WaitForSeconds(3);
        endscreen.SetActive(true);
        animator.SetTrigger("endscreen");
    }
}
