using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectUtils
{
    public static Rect CreateSquare(Vector2 point, float a)
    {
        float x = point.x - a;
        float y = point.y - a;
        float width = a * 2;
        float height = a * 2;
        return new Rect(x, y, width, height);
    }
    
    public static Rect Resize(Rect rect, float value)
    {
        float x = rect.x - value;
        float y = rect.y - value;
        float width = rect.width + value * 2;
        float height = rect.height + value * 2;
        return new Rect(x, y, width, height);
    }
}
