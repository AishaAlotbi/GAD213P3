using System;
using UnityEngine;
using Systems.DateTime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CalendarPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public KeyDates KeyDate;
    public TextMeshProUGUI Date;
    public Image panelImage;
    public Image highlight;


    private void Awake()
    {
        HideHighlight();
    }

    public void HideHighlight()
    {
        highlight.gameObject.SetActive(false);
        highlight.color = Color.clear;
    }

    public void ShowHighlight()
    {
        highlight.color = Color.white; 
        highlight.gameObject.SetActive(true);
    }

    public void AssignKeyDate(KeyDates keyDate)
    {
        KeyDate = keyDate;
        panelImage.sprite = KeyDate.thumbnail;
        panelImage.color = Color.white;
    }

    internal void SetUpDate(string date)
    {
        Date.text = date;
        KeyDate = null;
        panelImage.sprite = null;
        panelImage.color = Color.clear;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CalendarController.DescriptionText.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(KeyDate != null)
        {
            CalendarController.DescriptionText.text = KeyDate.Description;
        }
        else
        {
            CalendarController.DescriptionText.text = "";
        }
    }

   
}
