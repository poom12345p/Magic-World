using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObj : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Camera cam;
    private Canvas myCanvas;

    public Vector2 offset;
    void Start()
    {
        cam = Camera.main;
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame

    void LateUpdate()
    {
             RectTransform canvasRect = myCanvas.GetComponent<RectTransform>();
             Vector2 viewPos = cam.WorldToScreenPoint(target.position);
            Vector2 screenPos= new Vector2(viewPos.x + (offset.x * canvasRect.localScale.x), viewPos.y +( offset.y * canvasRect.localScale.x));
            transform.position = Vector2.Lerp(transform.position, screenPos, 1f);



        //Debug.Log()
    }

    //private Vector2 GetPositionFromWorldPosition(Vector3 _worldPostion, Camera _camera, Canvas _canvas)
    //{
    //    RectTransform canvasRect = _canvas.GetComponent<RectTransform>();
    //    Vector2 viewPos = _camera.WorldToScreenPoint(_worldPostion); //for RectTransform.AnchoredPosition?
    //    return new Vector2(viewPos.x+(offset.x* canvasRect.localScale.x),viewPos.y+offset.y * canvasRect.localScale.x));
    //}

    public void SetTarget(Transform t)
    {
        target = t;
    }
}
