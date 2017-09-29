using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTip : MonoBehaviour
{
    
    private Text _contentText;

    public Text ContentText
    {
        get
        {
            if(_contentText==null)
            {
                _contentText = GetComponentInChildren<Text>();
            }
            return _contentText;
        }
    }

    private RectTransform panelRect;

    private void Awake()
    {
        panelRect = transform.FindChild("Panel").transform as RectTransform;
    }


    public void ShowText(string text)
    {
        ContentText.text = text;
        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector3 position)
    {
        Vector2 newPos = panelRect.anchoredPosition;
        newPos.y = -panelRect.sizeDelta.y/2 - 40;
        panelRect.anchoredPosition = newPos;
        transform.localPosition = position;
    }
}
