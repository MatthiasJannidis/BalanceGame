using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static float GetBoundsHalfHeight(this Sprite sprite) 
    {
        return sprite.bounds.size.y;
    }
}
