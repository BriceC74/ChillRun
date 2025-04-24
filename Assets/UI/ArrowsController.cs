using UnityEngine;
using UnityEngine.UIElements;

public class ArrowsController : MonoBehaviour
{
    public VisualElement ui;

    public VisualElement arrowLeft;
    public VisualElement arrowRight;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    void OnEnable()
    {
        arrowLeft = ui.Q("ArrowLeft");
        arrowRight = ui.Q("ArrowRight");
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            arrowLeft.AddToClassList("hide");
            arrowRight.RemoveFromClassList("hide");
        } 
        if (Input.GetKey(KeyCode.RightArrow)) {
            arrowRight.AddToClassList("hide");
            arrowLeft.RemoveFromClassList("hide");
        }
    }
}
