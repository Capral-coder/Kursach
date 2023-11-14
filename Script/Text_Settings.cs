using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Text_Settings : MonoBehaviour
{
    public Image image;
    private TextMeshProUGUI textMeshPro;

    private RectTransform imageRectTransform;
    private Vector2 initialImageSize;
    private void Start()
    {
        imageRectTransform = image.GetComponent<RectTransform>();
        initialImageSize = imageRectTransform.sizeDelta;
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        float preferredWidth = textMeshPro.preferredWidth; 
        float preferredHeight = textMeshPro.preferredHeight;
        float FlexibleWidth = textMeshPro.flexibleWidth;
        FlexibleWidth = 700;



        if (preferredWidth >= 270)
        {
            imageRectTransform.sizeDelta = new Vector2(initialImageSize.x + 300, initialImageSize.y + preferredHeight);
        }
        else
        {
            imageRectTransform.sizeDelta = new Vector2(initialImageSize.x + (preferredWidth/2), initialImageSize.y + 0);
        }
      
    }
}
