using System;
using UnityEngine;

[Serializable]
public class Level
{
    [SerializeField]
    private int _maxExp;

    public int MaxExp => _maxExp;
}
