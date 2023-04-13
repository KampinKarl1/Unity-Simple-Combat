using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeypressTrigger : MonoBehaviour
{
    [SerializeField] KeyCode activatingKey = KeyCode.B;
    [SerializeField] bool destroyOnPress = false;
    [SerializeField] UnityEvent onKeyPress = null;

    void Update()
    {
        if (Input.GetKeyDown(activatingKey))
        {
            onKeyPress?.Invoke();

            if (destroyOnPress)
                Destroy(gameObject);
        }
    }
}
