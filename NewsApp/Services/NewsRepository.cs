using NewsApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace NewsApp.Services
{
    public class NewsRepository
    {
        string _dbpath;
        private SQLiteAsyncConnection _connection;
        public const SQLite.SQLiteOpenFlags Flags =
           SQLiteOpenFlags.ReadWrite|
            SQLite.SQLiteOpenFlags.Create|
            SQLiteOpenFlags.SharedCache;

        public async Task init()
        {
            if (_connection!=null)
            {
                return;
            }
            _connection = new SQLiteAsyncConnection(_dbpath,Flags);
            await _connection.CreateTableAsync<Source>();
            await _connection.CreateTableAsync<Article>();


        }

        public NewsRepository( string dbpath)
        {
            _dbpath = dbpath;
        }

        public async Task AddNewArticle(Article article)
        {
            try
            {
                await init();
                if (article is null)
                    throw new Exception("required valid article");
                if (article.Id ==0)
                {
                    await _connection.InsertWithChildrenAsync(article);
                }

                else
                {
                    await _connection.UpdateWithChildrenAsync(article);
                }
            }
            catch (Exception)
            {

                await Shell.Current.DisplayAlert("Error", "Error", "OK");
            }
        }

        public async Task<List<Article>> GetAllArticles()
        {
            try
            {
                await init();
                return await _connection.GetAllWithChildrenAsync<Article>();    
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            return new List<Article>(); 
        }


    }
}
