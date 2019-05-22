using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] GameObject hintBubble;
    [SerializeField] float displayDuration = 3f;

    private void Start()
    {
        hintBubble.SetActive(false);
    }

    private IEnumerator DisplayHintBubble(float time)
    {
        hintBubble.SetActive(true);
        yield return new WaitForSeconds(time);
        hintBubble.SetActive(false);
    }


    public void DisplayHint()
    {
        StartCoroutine(DisplayHintBubble(displayDuration)); 

    }



}
