using UnityEngine;

/// <summary>
/// Easy way to set up a Singleton. BUILT ON MONOBEHAVIOUR.
/// Use this.SetInstance to initialize. 
/// Access via instance.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour
{
    protected void SetInstance(T t)
    {
        if (instance == null)
            instance = t;
        else
        {
            Debug.LogError("There is a duplicate " + t.GetType().Name + " that must be destroyed");
            DestroyImmediate(this);
        }
    }

    protected static T instance;
    public static T Instance => instance;
}
