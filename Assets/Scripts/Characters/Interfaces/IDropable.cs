namespace RPG.Character
{
    public interface IDropable
    {
        public DropItemSAO DropItem { get; }

        public void Drop();
    }
}