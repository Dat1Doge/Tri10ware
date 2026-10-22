using System.Collections;
using TMPro;
using UnityEngine;

public class EndingCharacters : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private float timeBetweenCharacters;
    [SerializeField] private string endDialogue;
    [SerializeField] private float scrollSpeed;

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
    }
}
