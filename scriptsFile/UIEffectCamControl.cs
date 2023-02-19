using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControlledCamera
{
public class UIEffectCamControl : MonoBehaviour
{
    public RectTransform canvas;

    // Start is called before the first frame update
    void Start()
    {
        // UpdatePosition();
    }

    void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        transform.position = new Vector3(
            canvas.position.x,
            canvas.position.y,
            transform.position.z
        );
        GetComponent<Camera>().orthographicSize = canvas.position.y;
    }
}
}
