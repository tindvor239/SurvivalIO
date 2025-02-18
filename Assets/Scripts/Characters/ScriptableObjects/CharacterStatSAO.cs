using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterSAO", menuName = "Character")]
public class CharacterStatSAO : ScriptableObject
{
    [SerializeField]
    private string _id;
    [SerializeField]
    private string _name;
    [SerializeField]
    private Stats _stats;

    public string ID
    {
        get => _id;
    }

    public string Name
    {
        get => _name;
    }

    public Stats Stats
    {
        get => _stats;
    }
}
