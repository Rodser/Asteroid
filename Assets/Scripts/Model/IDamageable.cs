namespace Rodlix.Asteroid
{
    public interface IDamageable 
    {
        void TakeDamage(int damage);
    }
    
    public interface IDamaging
    {
        int MakeDamage();
    }
}