using UnityEngine;

public class GoldenAppleFactory : FruitFactory
{
    public override Food Create(Vector2 position)
    {
        Food f = Instantiate(prefab, position, Quaternion.identity);
        f.GetComponent<SpriteRenderer>().color = Color.yellow;
        return f;
    }
}