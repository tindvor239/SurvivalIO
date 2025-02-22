using UnityEngine;

public class UIPopup : MonoBehaviour
{
    [SerializeField]
    private string _showAnimation = "ShowWindow";
    [SerializeField]
    private string _hideAnimation = "HideWindow";
    [SerializeField]
    protected Animator animator;

    public virtual void Show()
    {
        animator.Play(_showAnimation);
    }

    public virtual void Close()
    {
        animator.Play(_hideAnimation);
    }
}
