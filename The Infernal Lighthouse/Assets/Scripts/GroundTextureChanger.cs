using UnityEngine;

public class GroundTextureChanger : MonoBehaviour
{
    [SerializeField] private Material [] _groundMaterials;  

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (_groundMaterials.Length > 0)
        {
            int randomMaterial = Random.Range(0, _groundMaterials.Length);
            renderer.material = _groundMaterials[randomMaterial];
        }
    }
}
