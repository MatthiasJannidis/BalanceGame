using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Slots")]
    public float slotSpeed = 1.0f;
    public float slotSpawnTimerSeconds = 1.0f;
    public float slotBoundaries = 2.0f;

    [Header("Game")]
    public float initialPlayTimer = 2.0f;

    [Header("Blocks")]
    public float initialBlockHeight = 5.0f;
    public float blockSpeed = 1.0f;
    public Sprite blockSprite = null;
}
