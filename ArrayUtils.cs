using System;
public static class ArrayUtils
{
    public static T GetRandomElement<T>(ref T[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Array cannot be null or empty");
        }

        return array[UnityEngine.Random.Range(0, array.Length)];
    }
}
