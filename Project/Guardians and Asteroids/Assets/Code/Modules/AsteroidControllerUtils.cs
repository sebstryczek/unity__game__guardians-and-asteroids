using UnityEngine;

public enum SpawnEdge { TOP, BOTTOM, LEFT, RIGHT }

public static class AsteroidControllerUtils
{
    public static SpawnEdge GetRandomSpawnEdge()
    {
        return (SpawnEdge) Random.Range(0, 4);
    }

    public static Vector3 GetRandomPosition(SpawnEdge edge, Rect rect)
    {
        float x = 0;
        float y = 0;

        switch (edge)
        {
            case SpawnEdge.TOP:
                x = Random.Range(rect.xMin, rect.xMax);
                y = rect.yMax;
                break;
            case SpawnEdge.BOTTOM:
                x = Random.Range(rect.xMin, rect.xMax);
                y = rect.yMin;
                break;
            case SpawnEdge.LEFT:
                x = rect.xMin;
                y = Random.Range(rect.yMin, rect.yMax);
                break;
            case SpawnEdge.RIGHT:
                x = rect.xMax;
                y = Random.Range(rect.yMin, rect.yMax);
                break;
        }
        return new Vector3(x, y);
    }
    
    public static Vector2 GetRandomForceDirection(SpawnEdge edge, Rect rangeRect, Rect clampRect)
    {
        float forceDirectionPointX = 0;
        float forceDirectionPointY = 0;
        float rand = 0;

        switch (edge)
        {
            case SpawnEdge.TOP:
            case SpawnEdge.BOTTOM:
                rand = Random.Range(rangeRect.xMin, rangeRect.xMax);
                forceDirectionPointX = Mathf.Clamp(rand, clampRect.xMin, clampRect.xMax);
                forceDirectionPointY = edge == SpawnEdge.TOP ? clampRect.yMax : clampRect.yMin;
                break;
            case SpawnEdge.LEFT:
            case SpawnEdge.RIGHT:
                rand = Random.Range(rangeRect.yMin, rangeRect.yMax);
                forceDirectionPointX = edge == SpawnEdge.LEFT ? clampRect.xMin : clampRect.xMax;
                forceDirectionPointY = Mathf.Clamp(rand, clampRect.yMin, clampRect.yMax);
                break;
        }
        
        return new Vector2(forceDirectionPointX, forceDirectionPointY);
    }
}
