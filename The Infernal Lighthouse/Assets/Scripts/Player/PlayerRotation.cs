using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Space.Self);
    }
}
