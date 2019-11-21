using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float paddleWidthInUnits = 2f;
    [SerializeField] float screenWidthInUnits = 16f;

    void Update()
    {
        float mouseX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        transform.position = new Vector2(Mathf.Clamp(mouseX, paddleWidthInUnits / 2f, screenWidthInUnits - (paddleWidthInUnits / 2f)), transform.position.y);

    }
}
