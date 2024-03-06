using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draganddrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public Vector2 offset;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);

        // Set the pivot to the bottom-left to avoid the offset issue
        rectTransform.pivot = new Vector2(0, 0);

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPos = ClampToCanvas(eventData.position - offset);
        rectTransform.anchoredPosition = pointerPos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    private Vector2 ClampToCanvas(Vector2 position)
    {
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
        Vector2 halfSize = rectTransform.sizeDelta * 0.5f;

        float xClamped = Mathf.Clamp(position.x, 0, canvasSize.x - rectTransform.sizeDelta.x);
        float yClamped = Mathf.Clamp(position.y, 0, canvasSize.y - rectTransform.sizeDelta.y);

        return new Vector2(xClamped, yClamped);
    }
}


