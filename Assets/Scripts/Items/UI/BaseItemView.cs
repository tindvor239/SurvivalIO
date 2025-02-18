using UnityEngine;
using UnityEngine.UI;

public class BaseItemView : MonoBehaviour
{
    [SerializeField]
    private Image _icon;

    protected BaseItemSAO baseItemSAO;

    public virtual void Setup(BaseItemSAO baseItemSAO)
    {
        this.baseItemSAO = baseItemSAO;
        _icon.sprite = baseItemSAO.Icon;
    }
}
