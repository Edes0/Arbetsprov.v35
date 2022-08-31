using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = "select * from dbo.Users";

            return _db.LoadData<UserModel, dynamic>(sql, new { });
        }

        public Task InsertUser(UserModel user)
        {
            //Updatera för usermodel
            string sql = @"insert into dbo.Users (Name, UserName, Password, Email, IsEmailConfirmed, CreatedDate)
                            values (@Name, @UserName, @Password, @Email, @IsEmailConfirmed, @CreatedDate)";

            return _db.SaveData(sql, user);
        }
        public Task RemoveUser(UserModel user)
        {
            //Updatera för usermodel
            string sql = "";

            return _db.SaveData(sql, user);
        }
    }
}
