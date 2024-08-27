using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.2f, 0.2f);       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.2f); 
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}