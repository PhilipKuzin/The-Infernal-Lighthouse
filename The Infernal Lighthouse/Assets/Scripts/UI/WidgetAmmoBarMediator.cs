using System;

public class WidgetAmmoBarMediator : IDisposable
{
    private UIWidgetAmmoBar _uiWidgetAmmoBar;
    private RaycastAttak _raycastAttak;

    public WidgetAmmoBarMediator(UIWidgetAmmoBar uIWidgetAmmoBar, RaycastAttak raycastAttak)
    {
        _uiWidgetAmmoBar = uIWidgetAmmoBar;
        _raycastAttak = raycastAttak;

        _raycastAttak.OnReloadStarted += StartReload;
        _raycastAttak.OnReloadFinished += ResetReload;
        _raycastAttak.OnAmmoRecounted += RecountAmmoView;
    }

    public void Dispose()
    {
        _raycastAttak.OnReloadStarted -= StartReload;
        _raycastAttak.OnReloadFinished -= ResetReload;
        _raycastAttak.OnAmmoRecounted -= RecountAmmoView;
    }

    private void RecountAmmoView(int ammoAmount)
    {
        _uiWidgetAmmoBar.ChangeAmmoCount(ammoAmount);
    }

    private void ResetReload()
    {
        _uiWidgetAmmoBar.ResetReloadAnimation();
    }

    private void StartReload(float duration)
    {
        _uiWidgetAmmoBar.StartReloadAnimation(duration);
    }
}
