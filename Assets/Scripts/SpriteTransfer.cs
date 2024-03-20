using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteTransfer : MonoBehaviour
{
    public Image targetImage;
    public Text targetText;
    Button thisButton;
    public Image thisImage;
    public Text thisLabel;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        if(!thisImage)
        thisImage = GetComponent<Image>();
        thisButton.onClick.AddListener(TransferSprite);
    }
    public void TransferSprite()
    {
        Debug.Log("Called by "+transform.name);
        if (!targetImage || !targetText) return;

        targetImage.sprite = thisImage.sprite;
        if(!thisLabel)
            if(transform.GetChild(0))
            targetText.text = transform.GetChild(0).GetComponent<Text>().text;
        else
            targetText.text = thisLabel.text;
     
        
    }
}
