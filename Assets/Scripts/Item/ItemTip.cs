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
}
