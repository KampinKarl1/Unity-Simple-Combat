using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAffector : MonoBehaviour
{
    [SerializeField] private RectTransform imgTransform = null;

    [SerializeField] private UnityEngine.UI.Image image = null;

    [SerializeField] private float retToScaleSpeed = 3.0f;
    [SerializeField] private float retToRotSpeed = 3.0f;
    [SerializeField] private float retToColorSpeed = 3.0f;

    Color trans = new Color(1, 1, 1, 0);
    private void Start()
    {
        image.color = trans;
    }

    private void Update()
    {
        imgTransform.localScale = Vector2.Lerp(imgTransform.localScale, Vector2.one, retToScaleSpeed * Time.deltaTime);
        
        imgTransform.rotation = Quaternion.Lerp(imgTransform.rotation, Quaternion.Euler(0, 0, -0),
               retToRotSpeed * Time.deltaTime);

        image.color = Color.Lerp(image.color, trans, retToColorSpeed * Time.deltaTime);
    }

    public void ScaleUp(float scaleChange, float time, in Color color) 
    {
        StartCoroutine(ScaleUpOverTime(imgTransform.localScale * scaleChange, time, color));
    }

    const float CLEARISH = .44f;
    bool left = false;
    IEnumerator ScaleUpOverTime(Vector2 targetScale, float time, Color colorTarget) 
    {
        float cd = time;

        float scaleSpeed = 1f / time;

        float z = Random.Range(10f, 25f) * ((left = !left) ? -1f : 1f);

        Color trgAlp = new Color(colorTarget.r, colorTarget.g, colorTarget.b, CLEARISH);
        image.color = trgAlp;

        while (cd > 0)
        {
            imgTransform.localScale = Vector2.Lerp(imgTransform.localScale, targetScale, scaleSpeed * Time.deltaTime);

            imgTransform.rotation = Quaternion.Lerp(imgTransform.rotation, Quaternion.Euler(0, 0, z),
                scaleSpeed * Time.deltaTime);

            image.color = Color.Lerp(image.color, colorTarget, scaleSpeed * Time.deltaTime);    

            yield return null;

            cd -= Time.deltaTime;
        }
    }
}
