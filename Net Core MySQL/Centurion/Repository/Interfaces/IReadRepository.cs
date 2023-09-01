namespace Repository.Interfaces
{
	public interface IReadRepository<TEntity>
	{
		public TEntity Find(int Id);
        public TEntity Find(string key, string value);
        public TEntity Find(Dictionary<string, string> pairs);
        public List<TEntity> List(int page = 0, int count = 10);
    }
}

