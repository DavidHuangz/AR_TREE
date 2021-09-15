using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    Vector3 touchStart;

    public float zoomOutMin = 1;

    public float zoomOutMax = 8;

    public float

            minX,
            minY,
            maxX,
            maxY;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction =
                touchStart -
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            /*direction.x = Mathf.Clamp(0, -0.39f, 0.42f);
            direction.y = Mathf.Clamp(0, -0.51f, 0.41f);*/
            transform.position += direction;
            transform.position =
                new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                    Mathf.Clamp(transform.position.y, minY, maxY),
                    -10);
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize =
            Mathf
                .Clamp(Camera.main.orthographicSize - increment,
                zoomOutMin,
                zoomOutMax);
    }
}
