using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _imageFiller; 

    public void SetValue (float valueNormalized)
    {
        _imageFiller.fillAmount = valueNormalized; 
    }
}
