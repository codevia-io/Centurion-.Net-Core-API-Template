namespace Repository.Interfaces
{
	public interface IUpdateRepository<TEntity>
	{
		public void Update(TEntity entity);
	}
}

