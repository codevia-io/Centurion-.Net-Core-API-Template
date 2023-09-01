namespace Repository.Interfaces
{
	public interface ICreateRepository<TEntity>
	{
		public void Created(TEntity entity);
	}
}

