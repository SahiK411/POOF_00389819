using System.Data;

namespace Examen.Classes
{
    public class User
    {
        public enum UserTypeEnum { Employee, Guard, Admin };

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public UserTypeEnum Type { get; set; }

        public User(DataTable dt)
        {
            var dr = dt.Rows[0];
            var userId = dr[0].ToString();
            var userFirstName = dr[1].ToString();
            var userLastName = dr[2].ToString();
            var userType = dr[3].ToString();

            Id = userId;
            FirstName = userFirstName;
            LastName = userLastName;

            switch (userType)
            {
                case "em":
                    Type = UserTypeEnum.Employee;
                    break;
                case "gu":
                    Type = UserTypeEnum.Guard;
                    break;
                case "ad":
                    Type = UserTypeEnum.Admin;
                    break;
                default:
                    Type = UserTypeEnum.Employee;
                    break;
            }
        }
    }
}
