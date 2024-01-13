using UnityEngine;
using Zenject;

public class Instancer : IInstancer
{
    private readonly DiContainer _container;

    public Instancer(DiContainer container)
    {
        _container = container;
    }

    public T Create<T>(GameObject prefab, Transform position)
    {
        return _container.InstantiatePrefab(prefab, position).GetComponent<T>();
    }
    
    public T Create<T>(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        return _container.InstantiatePrefab(prefab, position, rotation, parent).GetComponent<T>();
    }
}
