using UnityEngine;

public interface IEnemyTarget 
{
    bool IsActive { get; }
    Vector3 Position { get; }
}
