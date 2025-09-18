using UnityEngine;

public class UserUtility
{
    public Quaternion GetRandomRotation()
    {
        const int MaxRandomValue = 360;

        float x = GetRandomValue(0, MaxRandomValue);
        float y = GetRandomValue(0, MaxRandomValue);
        float z = GetRandomValue(0, MaxRandomValue);

        return Quaternion.Euler(x, y, z);
    }

    public Vector3 GetRandomDispersionByPosition(Vector3 startPosition, int power)
    {
        Vector3 position = startPosition;

        position.x = GetRandomValue(-power, power);
        position.z = GetRandomValue(-power, power);

        return position;
    }

    public Color GenerateRandomColor()
    {
        const int RGBMaxValue = 255;

        float r = (float)GetRandomValue(0, 255) / RGBMaxValue;
        float g = (float)GetRandomValue(0, 255) / RGBMaxValue;
        float b = (float)GetRandomValue(0, 255) / RGBMaxValue;

        return new Color(r, g, b);
    }

    public int GetRandomValue(int min, int max)
    {
        return Random.Range(min, max + 1);
    }
}
