using UnityEngine;

public class UserUtility
{
    public static Quaternion GetRandomRotation()
    {
        const int MaxRandomValue = 360;

        float x = GetRandomValue(0, MaxRandomValue);
        float y = GetRandomValue(0, MaxRandomValue);
        float z = GetRandomValue(0, MaxRandomValue);

        return Quaternion.Euler(x, y, z);
    }

    public static Vector3 GetRandomDispersionByPosition(Vector3 startPosition, int power)
    {
        Vector3 position = startPosition;

        position.x = GetRandomValue(-power, power);
        position.z = GetRandomValue(-power, power);

        return position;
    }

    public static Color GenerateRandomColor()
    {
        return Random.ColorHSV();
    }

    public static Color ResetColor()
    {
        return Color.white;
    }

    public static int GetRandomValue(int min, int max)
    {
        return Random.Range(min, max + 1);
    }
}
