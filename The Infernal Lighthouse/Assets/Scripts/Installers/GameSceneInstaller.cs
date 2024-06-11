using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{

    [SerializeField] private Transform _joystickSpawnPosition;
    [SerializeField] private FixedJoystick _fixedJoystickPrefab;
    // FixedJoystick fixedJoystick = Container.InstantiatePrefabForComponent<FixedJoystick>(_fixedJoystickPrefab, _joystickSpawnPosition.position, Quaternion.identity, null);

    public override void InstallBindings()
    {
        BindMovementHandler();
    }

    private void BindMovementHandler()
    {
        Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle();
    }
}
