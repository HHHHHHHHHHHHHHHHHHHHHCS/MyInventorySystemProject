using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTip : MonoBehaviour
{
    
    private Text contentText;

    private void Awake()
    {
        contentText = GetComponentInChildren<Text>();

    }

    public void ShowText(string text)
    {
        contentText.text = text;
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
}
