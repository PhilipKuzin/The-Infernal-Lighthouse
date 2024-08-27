using UnityEngine;
using DG.Tweening;

public class PlayerRotation : MonoBehaviour
{
    private void Start()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.DORotate(new Vector3(0, 1, 0) * 360, 7, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(Rotate);
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }

}
