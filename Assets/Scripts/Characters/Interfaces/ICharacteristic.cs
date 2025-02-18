namespace RPG.Character
{    
    public interface ICharacteristic
    {
        public Stats CurrentStats { get; }
        public CharacterStatSAO Data { get;  } 

        public void TakeDamage(float damage);
    }
}