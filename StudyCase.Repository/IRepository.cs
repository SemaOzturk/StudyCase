namespace StudyCase.Repository
{
    public interface IRepository<T>
    {
        public T Insert(T entity);
    }
}
