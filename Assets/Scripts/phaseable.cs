using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class phaseable : MonoBehaviour
{
    private bool fadeOut, fadeIn;
    public float fadeSpeed;
    Renderer ren;

    void Start()
    {
        ren = GetComponent<Renderer>();
    }
    
    public void StartPhasing()
    {
        StartCoroutine(FadeOutObject());
    }

    public void StopPhasing()
    {
        StartCoroutine(FadeInObject());
    }
    public void OnPointerClick (PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right) {
            StopPhasing();
        }
    }

    public IEnumerator FadeOutObject()
    {
        while (ren.material.color.a > 0.1)
        {
            Color objectColor = ren.material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            ren.material.color = objectColor;
            yield return null;
        }
    }

    public IEnumerator FadeInObject()
    {
        while (this.GetComponent<Renderer>().material.color.a < 255)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
    }
}
