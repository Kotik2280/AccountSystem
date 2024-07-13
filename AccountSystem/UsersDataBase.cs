using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem
{
    public class UsersDataBase
    {
        private Dictionary<User, DataBaseInfo> users;
        private SecureData secureData;
        public UsersDataBase(SecureData secureData)
        {
            this.secureData = secureData;
            users = new Dictionary<User, DataBaseInfo>();
        }

        public void AddUser(User user)
        {
            foreach (var item in users)
            {
                if (item.Key.ID == user.ID)
                    throw new Exception("This user is already in database!");
            }

            string databasePassoword = EncryptData.Hashing(EncryptData.EncryptPassword(user, secureData) + secureData.GetSalt(user), secureData);

            user.ChangePassword(databasePassoword);

            users[user] = new DataBaseInfo();
        }
        public DataBaseInfo? RemoveByUserID(int ID)
        {
            foreach (var item in users)
            {
                if (item.Key.ID == ID)
                {
                    users.Remove(item.Key);
                    return item.Value;
                }
            }
            return null;
        }
        public void UpdateUserByID(int ID, User newUser)
        {
            DataBaseInfo dataBaseInfo = new DataBaseInfo(this.RemoveByUserID(ID));

            users[newUser] = dataBaseInfo;
        }
    }
}
