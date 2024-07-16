using UnityEngine;

public class Initializator : MonoBehaviour
{
    [SerializeField] private Cannon _cannon;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.Init(_enemy);
        _enemy.Init(_cannon);
    }
}
