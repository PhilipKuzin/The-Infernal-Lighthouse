
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    
    private void Awake()
    {
        _spawner.StartWork();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
