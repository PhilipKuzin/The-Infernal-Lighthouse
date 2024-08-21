using System;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void StopAnimation()
    {
        _animator.SetTrigger("StopMove");
    }
}
