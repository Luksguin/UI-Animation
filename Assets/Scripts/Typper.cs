using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class Typper : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public string phrase;
    public float timeBetweenLetters;

    private void Awake()
    {
        DeleteText();
    }

    [Button]
    public void StartText()
    {
        StartCoroutine(ShowText(phrase));
    }

    public void DeleteText()
    {
        textMesh.text = "";
    }

    IEnumerator ShowText(string s)
    {
        foreach(char l in phrase.ToCharArray())
        {
            textMesh.text += l;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}
