namespace AccountSystem
{
    public class SecureData
    {
        public UserProperties[] Salt { get; private set; }
        public string encryptKey { get; private set; }
        public SecureData(params UserProperties[] userTypes)
        {
            Salt = userTypes;
        }
        public string GetSalt(User user)
        {
            string stringSalt = "";
            foreach (UserProperties property in Salt)
            {
                switch (property)
                {
                    case UserProperties.ID:
                        stringSalt += user.ID;
                        break;
                    case UserProperties.Name:
                        stringSalt += user.Name;
                        break;
                    case UserProperties.Age:
                        stringSalt += user.Age;
                        break;
                    case UserProperties.Nickname:
                        stringSalt += user.Nickname;
                        break;
                    case UserProperties.EMail:
                        stringSalt += user.EMail;
                        break;
                    default:
                        break;
                }
            }
            return stringSalt;
        }
    }
    public enum UserProperties
    {
        ID,
        Name,
        Age,
        Nickname,
        EMail
    }
}
