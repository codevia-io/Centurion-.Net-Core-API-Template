using System;
namespace Services.Interfaces
{
	public interface IReadServices<TModel>
	{
		public TModel? Find(int Id);
        public TModel? Find(string key, string value);
        public TModel? Find(Dictionary<string, string> pairs);
        public List<TModel> List(int page = 0, int count = 10);
    }
}

