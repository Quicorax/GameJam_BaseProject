using UnityEngine;

public interface IInstancer
{
    T Create<T>(GameObject prefab, Transform position);
    T Create<T>(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent);
}