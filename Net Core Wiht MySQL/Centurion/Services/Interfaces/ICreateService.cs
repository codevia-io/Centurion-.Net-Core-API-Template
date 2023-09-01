using System;
namespace Services.Interfaces
{
	public interface ICreateService<TModel>
	{
		public void Created(TModel model);
	}
}

