using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;

    [Header("Settings")]
    [SerializeField] private int _powerDispersion;
    [SerializeField] private float _spawnDelay = 1;

    private UserUtility _userUtility = new UserUtility();

    private void Start()
    {
        StartCoroutine(Rain());
    }

    private IEnumerator Rain()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            CreateCube();

            yield return wait;
        }
    }

    private void CreateCube()
    {
        if(_cubePool.TryGetElement(out var gameObject))
        {
            gameObject.transform.rotation = _userUtility.GetRandomRotation();
            gameObject.transform.position = _userUtility.GetRandomDispersionByPosition(transform.position, _powerDispersion);
        }
    }
}
