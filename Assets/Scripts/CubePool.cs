using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _spawnCount = 50;

    private Queue<Cube> _pooledObject = new Queue<Cube>();

    public bool CanReturnDequeueElememt => _pooledObject.Count > 0;

    private void Awake()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            var newPoolElement = Instantiate(_cubePrefab, transform);
            newPoolElement.gameObject.SetActive(false);

            _pooledObject.Enqueue(newPoolElement);    
        }
    }

    public Cube GiveElement()
    {
        var firstPoolElement = _pooledObject.Dequeue();

        firstPoolElement.gameObject.SetActive(true);

        return firstPoolElement;
    }

    public void ReturnToPool(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _pooledObject.Enqueue(cube);
    }
}
