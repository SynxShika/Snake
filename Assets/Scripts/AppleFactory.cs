using UnityEngine;

public class AppleFactory : FruitFactory
{
    public override Food Create(Vector2 position)
        => Instantiate(prefab, position, Quaternion.identity);
}