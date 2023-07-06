namespace BigBangAssesmemtTwo.Interfaces
{
    public interface IDocRepo<K,T>
    {
        public Task<T?> Get(K id);
        public Task<ICollection<T>?> GetAll();
        public Task<T?> DeleteDoc(K id);

    }
}
