using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class TextValueAnimatorBasic : MonoBehaviour
{
    [SerializeField] bool updateEveryFrame = true;
    [SerializeField] string prefix, suffix;
   [Range(0,100)]
    [SerializeField] int valueA = 0;
    [SerializeField] Text textToShow;
    [SerializeField] TextMesh textToShowTM;
    bool isTextMesh = false;
    string displayString;
    // Start is called before the first frame update
    void Start()
    {
        if (!textToShow)
            textToShow = GetComponent<Text>();
        if (textToShowTM)
            isTextMesh = true;
        else
            if (GetComponent<TextMesh>())
            textToShowTM = GetComponent<TextMesh>();
        else
            isTextMesh = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (updateEveryFrame) { 
        displayString = prefix + valueA + suffix;
        UpdateText();
        }
    }
    public void SetFloat(float f)
    {
        displayString = prefix + f.ToString("F2") + suffix;
        UpdateText();
        
    }
    void UpdateText()
    {
        if (isTextMesh)
            textToShowTM.text = displayString;
        if(textToShow)
        textToShow.text = displayString;
    }
}
