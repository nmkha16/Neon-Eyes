using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    public static CameraAction instance;
    public Transform player;
    [SerializeField] public float zoomSpeed;
    [SerializeField] public float zoomValue;
    private Camera cam;
    private float originalZoomValue;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        cam = GetComponent<Camera>();
        originalZoomValue = cam.orthographicSize;
    }

    public void doShake(float duration)
    {
        StartCoroutine(Shake(duration));
    }

    public IEnumerator Shake(float duration)
    {
        Vector3 originalPos;

        float eslapsedTime = 0f;

        while (eslapsedTime < duration)
        {
            originalPos = player.position;
            float xOffset = Random.Range(-0.1f+originalPos.x, 0.1f+originalPos.x);
            float yOffset = Random.Range(-0.1f + originalPos.y, 0.1f + originalPos.y);

            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z-1); // z = 0 will blacksccreen everything

            eslapsedTime += Time.deltaTime;

            yield return null;
        }
        //transform.localPosition = originalPos;
    }

    public void zoomIn()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomValue,Time.fixedDeltaTime * zoomSpeed);
        Invoke("zoomOut", 3);
    }
    public void zoomOut()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, originalZoomValue,zoomSpeed);

    }
}
