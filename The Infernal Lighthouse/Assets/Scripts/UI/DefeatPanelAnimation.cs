using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DefeatPanelAnimation : MonoBehaviour
{
    public void DoAnimation ()
    {
       transform.DOPunchPosition(new Vector3(0, 0, 0), 1, 2);
    }
}
