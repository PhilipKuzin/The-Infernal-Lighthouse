using System;
using UnityEngine;

public class WidgetAmmoBarMediator : IDisposable
{
    private UIWidgetAmmoBar _uiWidgetAmmoBar;
    private RaycastAttak _raycastAttak;

    public WidgetAmmoBarMediator(UIWidgetAmmoBar uIWidgetAmmoBar, RaycastAttak raycastAttak)
    {

        Debug.Log("ÌÅÄÈÀÒÎĞ ÀÌÌÎ ÑÎÇÄÀÍ");
        _uiWidgetAmmoBar = uIWidgetAmmoBar;
        _raycastAttak = raycastAttak;

        _raycastAttak.OnReloadStarted += StartReload;
        _raycastAttak.OnReloadFinished += ResetReload;
    }

    public void Dispose()
    {
        _raycastAttak.OnReloadStarted -= StartReload;
        _raycastAttak.OnReloadFinished -= ResetReload;
    }

    private void ResetReload()
    {
        _uiWidgetAmmoBar.ResetReloadAnimation();

    }

    private void StartReload(float duration)
    {
        _uiWidgetAmmoBar.StartReloadAnimation(duration);
        Debug.Log("ÌÅÄÈÀÒÎĞ ÂÊËŞ×ÈË ÏÅĞÅÇÀĞßÄÊÓ");
    }
}
