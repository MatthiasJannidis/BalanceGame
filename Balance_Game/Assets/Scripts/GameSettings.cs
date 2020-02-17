using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Slots")]
    public float slotSpeed = 1.0f;

    [Header("Game")]
    public float quickArrowPlaceTimer = 1.0f;
    public float strongArrowPlaceTimer = 1.0f;
    public float strongArrowGoalY = 2.0f;
    public int weakArrowPointGoal = 3;
    public float weakArrowFirstPointY = .4f;
    public float weakArrowSecondPointY = .6f;
    public float weakArrowThirdPointY = .8f;


    [Header("Blocks")]
    public float quickArrowWeight = 1.0f;
    public float strongArrowWeight = 1.0f;
}
