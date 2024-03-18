using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Draganddrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{  private RectTransform rectTransform;
    private CanvasScaler canvasScaler;
    private CanvasGroup canvasGroup;
    public bool dragging;
    public Vector2 offset;
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rectTransform = GetComponent<RectTransform>();
        canvasScaler = GetComponentInParent<CanvasScaler>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
        canvasGroup.blocksRaycasts = false;
        dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pointerPos = new Vector3(eventData.position.x - offset.x/2, eventData.position.y - offset.y/2, 0f);
        rectTransform.position = pointerPos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        dragging = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (dragging == false && other.CompareTag("Playarea"))
        { 
            player.playcard(gameObject);
        }
    }
}
