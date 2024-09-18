using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward);
    }
}
