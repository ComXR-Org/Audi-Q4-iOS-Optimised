using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightRenderers : MonoBehaviour
{
    public bool shouldHighlight = false, highlightAllMaterials = false;

    [ColorUsage(true, true)]
    public Color highlightColor;

    public Renderer[] highlightRenderers;
    public SpecialRenderer[] specialRenderers;

    public float highlightTime = 1f;

    Color ogColor, currentColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight()
    {
        if (shouldHighlight && highlightRenderers.Length > 0)
        {
            foreach (Renderer r in highlightRenderers)
            {
                int len = highlightAllMaterials ? r.materials.Length : 1;
                for (int i = 0; i < len; i++) { StartCoroutine(HighlightNow(r, i)); }
            }
        }
    }

    IEnumerator HighlightNow(Renderer r, int _index)
    {
        shouldHighlight = false;
        ogColor = r.materials[_index].GetColor("_EmissionColor");
        float _startTime = Time.time;
        r.materials[_index].EnableKeyword("_EMISSION");

        while (Time.time < _startTime + highlightTime)
        {
            currentColor = Color.Lerp(ogColor, highlightColor, (Time.time - _startTime) / highlightTime);
            r.materials[_index].SetColor("_EmissionColor", currentColor);

            yield return null;
        }
        r.materials[_index].SetColor("_EmissionColor", highlightColor);

        yield return new WaitForSeconds(highlightTime / 2);

        _startTime = Time.time;
        while (Time.time < _startTime + highlightTime)
        {
            currentColor = Color.Lerp(highlightColor, ogColor, (Time.time - _startTime) / highlightTime);
            r.materials[_index].SetColor("_EmissionColor", currentColor);

            yield return null;
        }
        r.materials[_index].SetColor("_EmissionColor", ogColor);
        r.materials[_index].DisableKeyword("_EMISSION");
        shouldHighlight = true;
    }
}
