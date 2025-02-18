using UnityEngine;

[CreateAssetMenu(fileName = "New Level Manager", menuName = "Level Manager")]
public class LevelManagerSAO : ScriptableObject
{
    [SerializeField]
    private Level[] _levels;

    public Level[] Levels => _levels;
}