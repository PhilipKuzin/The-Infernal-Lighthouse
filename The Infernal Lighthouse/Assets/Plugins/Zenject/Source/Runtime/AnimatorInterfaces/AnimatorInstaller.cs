using UnityEngine;

namespace Zenject
{
    public class AnimatorInstaller : Installer<Animator, AnimatorInstaller>
    {
        readonly Animator _animator;

        public AnimatorInstaller(Animator animator)
        {
            _animator = animator;
        }

        public override void InstallBindings()
        {
            Container.BindIntefacesAndSelfTo<AnimatorIkHandlerManager>().FromNewComponentOn(_animator.gameObject);
            Container.BindIntefacesAndSelfTo<AnimatorIkHandlerManager>().FromNewComponentOn(_animator.gameObject);
        }
    }
}

