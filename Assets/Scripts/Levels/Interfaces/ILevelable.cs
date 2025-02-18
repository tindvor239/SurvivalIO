public interface ILevelable
{
    int Level { get; }
    LevelManagerSAO LevelManagerSAO { get; }

    public void LevelUp();
}