using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animations
{
    Idle,
    Walk,
    WalkingDown,
    WalkingUp
}

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private float animationFPS;

    private readonly Dictionary<Animations, KeyLoop> _animationsData = new()
    {
        { Animations.Idle, new KeyLoop(0, 0) },
        { Animations.Walk, new KeyLoop(48, 53) },
        { Animations.WalkingDown, new KeyLoop(32, 37) },
        { Animations.WalkingUp, new KeyLoop(40, 45) },
    };

    private Dictionary<ItemCategory, AnimationLayer> _animationsCategory = new();
    private Animations _currentAnimation;
    private readonly KeyLoop _keyLoop = new();

    void Awake()
    {
        SetupSpriteRenderers();
    }

    private void SetupSpriteRenderers()
    {
        _animationsCategory.Add(ItemCategory.Base,
            AnimationLayer.CreateInstance(transform, GetComponent<PlayerInventory>().basic.spriteSheet, 0));
        _animationsCategory.Add(ItemCategory.Head,
            AnimationLayer.CreateInstance(transform, GetComponent<PlayerInventory>().empty.spriteSheet, 1));
        _animationsCategory.Add(ItemCategory.Body,
            AnimationLayer.CreateInstance(transform, GetComponent<PlayerInventory>().empty.spriteSheet, 1));
        SetAnimation(Animations.Idle);
        StartCoroutine(PlayAnimation());
    }

    private void SetSpriteSheet(ItemCategory category, GearSet gearSet)
    {
        _animationsCategory[category].UpdateSpriteSheet(gearSet.spriteSheet);
    }

    private void OnEnable()
    {
        PlayerMovement.OnIdle += SetIdle;
        PlayerMovement.OnWalkingHorizontal += SetWalkingHorizontal;
        PlayerMovement.OnWalkingVertical += SetWalkingVertical;
        PlayerInventory.OnGearSetChanged += SetSpriteSheet;
    }

    private void OnDestroy()
    {
        PlayerMovement.OnIdle -= SetIdle;
        PlayerMovement.OnWalkingHorizontal -= SetWalkingHorizontal;
        PlayerMovement.OnWalkingVertical -= SetWalkingVertical;
        PlayerInventory.OnGearSetChanged -= SetSpriteSheet;
    }

    private void SetWalkingHorizontal(bool left)
    {
        if (_currentAnimation == Animations.Walk) return;
        SetAnimation(Animations.Walk);

        foreach (KeyValuePair<ItemCategory, AnimationLayer> layer in _animationsCategory)
        {
            layer.Value.Flip(left);
        }
    }

    private void SetWalkingVertical(bool down)
    {
        switch (down)
        {
            case true when _currentAnimation == Animations.WalkingDown:
            case false when _currentAnimation == Animations.WalkingUp:
                return;
            case true:
                SetAnimation(Animations.WalkingDown);
                break;
            default:
                SetAnimation(Animations.WalkingUp);
                break;
        }
    }

    private void SetIdle()
    {
        if (_currentAnimation == Animations.Idle) return;
        SetAnimation(Animations.Idle);
    }

    private void SetAnimation(Animations newAnimation)
    {
        _currentAnimation = newAnimation;
        _keyLoop.SetKeyLoop(_animationsData[newAnimation]);
    }

    private IEnumerator PlayAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / animationFPS);
            SetSprites();
        }
    }

    private void SetSprites()
    {
        int frame = _keyLoop.GetNextKey();
        foreach (KeyValuePair<ItemCategory, AnimationLayer> layer in _animationsCategory)
        {
            layer.Value.SetSprite(frame);
        }
    }
}