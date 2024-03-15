using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltarProp : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> runes;
    [SerializeField] float lerpSpeed;

    private Color curColor;
    private Color targetColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 1);

        StartCoroutine(_waiter());
    }

    IEnumerator _waiter()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Boss");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

        foreach (var r in runes)
        {
            r.color = curColor;
        }
    }
}

