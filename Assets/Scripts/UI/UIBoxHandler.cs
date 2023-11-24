using UnityEngine;
using UnityEngine.UI;

public class UIBoxHandler : MonoBehaviour
{
    [Header("Display")]
    public bool UIDisplayed = false;
    [Header("Movement")]
    Vector2 OffscreenPosition;
    Vector2 OnscreenPosition;
    readonly private float speed = 1f;
    RectTransform MyTransform;
    float MoveProgress = 0;
    private enum Direction { Left, Right, Top, Bottom };
    [SerializeField] private Direction ZoomDirection = Direction.Top;
    [SerializeField] private bool OppositeExit = false; //Whether the UI sould exit the screen on the opposite side it entered
    private void Start()
    {
        MyTransform = GetComponent<RectTransform>(); // Unity doesnt realise that we're using a 2D transform if you just enter Transform, so we need to explicity tell it

        OnscreenPosition = MyTransform.localPosition;
        OffscreenPosition = MyTransform.localPosition;
        switch (ZoomDirection)
        {
            case Direction.Left:
                OffscreenPosition.x -= Screen.width;
                break;
            case Direction.Right:
                OffscreenPosition.x += Screen.width;
                break;
            case Direction.Top:
            default:
                OffscreenPosition.y += Screen.height;
                break;
            case Direction.Bottom:
                OffscreenPosition.y -= Screen.height;
                break;
        }

        if (!UIDisplayed)
        { // Things won't zoom offscreen when intitiated
            MyTransform.localPosition = OffscreenPosition;
            MoveProgress = 1;
        }

    }
    private void Update()
    {
        if (MoveProgress < 1)
        {
            MoveProgress += Time.deltaTime * speed;
        }
        if (MoveProgress < 0)
        {
            MoveProgress = -MoveProgress;
        }
        if (MoveProgress > 1)
        {
            MoveProgress = 1;
        }
        if (UIDisplayed)
        {
            MyTransform.localPosition = Vector2.Lerp(OffscreenPosition, OnscreenPosition, MoveProgress);
        }
        else
        {
            if (!OppositeExit)
            {
                MyTransform.localPosition = Vector2.Lerp(OnscreenPosition, OffscreenPosition, MoveProgress);
            }
            else
            {
                MyTransform.localPosition = Vector2.Lerp(OnscreenPosition, OffscreenPosition - (OnscreenPosition - OffscreenPosition), MoveProgress);
            }
        }
    }

    private void AffectUI(bool buttons)
    {
        // Turn off or on all buttons related to the UI, that way you cant select a button offscreen using a controller or the PageUp/PageDown keys
        Button[] childButtons = gameObject.GetComponentsInChildren<Button>();
        foreach (Button Catgirl in childButtons)
        { // I'm a professional, and using Catgirl as an iterator is proof
            Catgirl.interactable = buttons;
        }
    }

    public void DisableUI()
    {
        MoveProgress = 1 - MoveProgress;
        UIDisplayed = false;
        AffectUI(false);
    }
    public void EnableUI()
    {
        MoveProgress = 1 - MoveProgress;
        UIDisplayed = true;
        AffectUI(true);
    }
}
