using UnityEngine;

public abstract class BaseItemSAO : ScriptableObject
{
    [SerializeField]
    private string _id;
    [SerializeField]
    private string _name;
    [SerializeField]
    private string _description;
    [SerializeField]
    private Sprite _icon;

    public string ID => _id;
    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
}