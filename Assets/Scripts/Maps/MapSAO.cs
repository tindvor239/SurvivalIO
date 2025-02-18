using UnityEngine;

[CreateAssetMenu(fileName = "New Map SAO", menuName = "Maps/MapSAO")]
public class MapSAO : ScriptableObject
{
    [SerializeField]
    private string id;
    [SerializeField]
    private WaveSAO[] waves = new WaveSAO[0];

    public string ID => id;
    public WaveSAO[] Waves => waves;
}