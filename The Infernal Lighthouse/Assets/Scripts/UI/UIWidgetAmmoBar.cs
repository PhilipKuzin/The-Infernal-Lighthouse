using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetAmmoBar : MonoBehaviour
{
    [SerializeField] private AmmoBar _ammoBar;

    public void StartReloadAnimation (float duration)
    {
        _ammoBar.StartReloadProcess(duration);
        Debug.Log("ÂÈÄÆÅÒ ÂÊËŞ×ÈË ÏÅĞÅÇÀĞßÄÊÓ");
    }

    public void ResetReloadAnimation ()
    {
        _ammoBar.ResetAmmoBar();
    }
}
