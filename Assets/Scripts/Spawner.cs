using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Enemy _enemy;
    private WaitForSeconds _wait;
    private float _waitTime = 2f;
    private float _radius = 10f;
    private float _minAngle = 0f;
    private float _maxAngle = 360f;

    private void Start()
    {
        _wait = new WaitForSeconds(_waitTime);

        StartCoroutine(nameof(Spawn));
    }

    public void Init(Enemy enemy) => _enemy = enemy;

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            Instantiate(_enemy, GetSpawnPoint(), Quaternion.identity);

            yield return _wait;
        }
    }

    private Vector2 GetSpawnPoint()
    {
        var angle = Random.Range(_minAngle, _maxAngle);
        var spawnPointX = _radius * Mathf.Cos(angle);
        var spawnPointY = _radius * Mathf.Sin(angle);
        var spawnPoint = new Vector2(spawnPointX, spawnPointY);

        return spawnPoint;
    }
}
