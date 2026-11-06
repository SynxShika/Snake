using UnityEngine;

public abstract class FruitFactory : MonoBehaviour
{
    [SerializeField] protected Food prefab;
    public abstract Food Create(Vector2 position);
}