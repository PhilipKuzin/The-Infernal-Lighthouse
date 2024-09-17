using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform != null)
            transform.DOScale(1.2f, 0.2f);       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform != null)
            transform.DOScale(1f, 0.2f);
    }
}