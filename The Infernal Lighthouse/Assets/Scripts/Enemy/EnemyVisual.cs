using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StopAnimation()
    {
        _animator.SetTrigger("StopMove");
    }

    public void StopAnimationSpeed(bool isPaused)
    {
        if (isPaused == true) 
            _animator.speed = 0;
        else
            _animator.speed = 1;
    }
}
