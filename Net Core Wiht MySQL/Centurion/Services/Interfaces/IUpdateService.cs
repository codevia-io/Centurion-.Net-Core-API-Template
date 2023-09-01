using System;
namespace Services.Interfaces
{
	public interface IUpdateService<TModel>
	{
		public void Update(TModel model);
	}
}

