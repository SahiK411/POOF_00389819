using System.Data;

namespace Examen_Parcial.Classes
{
    public class User
    {
        public enum UserTypeEnum { Employee, Guard, Admin };

        private string firstName { get; set; }
        private string lastName { get; set; }
        private string id { get; set; }
        private UserTypeEnum type { get; set; }

        public User(DataTable dt)
        {

        }
    }
}
