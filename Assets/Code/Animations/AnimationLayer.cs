using UnityEngine;

public class AnimationLayer
{
    private readonly SpriteRenderer _renderer;
    private Sprite[] _spriteSheet;

    private AnimationLayer(Transform source, Sprite[] spriteSheet, int layer)
    {
        GameObject spriteRendererChild = new();
        spriteRendererChild.name = "Animation Layer";
        spriteRendererChild.transform.SetParent(source);
        _renderer = spriteRendererChild.AddComponent<SpriteRenderer>();
        _renderer.sortingOrder = layer;
        _spriteSheet = spriteSheet;
    }

    public static AnimationLayer CreateInstance(Transform source, Sprite[] spriteSheet, int layer)
    {
        return new AnimationLayer(source, spriteSheet, layer);
    }

    public void Flip(bool flip)
    {
        _renderer.flipX = flip;
    }

    public void SetSprite(int spriteIndex)
    {
        _renderer.sprite = _spriteSheet[spriteIndex];
    }

    public void UpdateSpriteSheet(Sprite[] spriteSheet)
    {
        _spriteSheet = spriteSheet;
    }
}