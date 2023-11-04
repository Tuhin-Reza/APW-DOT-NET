using Task3.Validation;

namespace Task3.DTOS
{
    public class UserDTO
    {
        [Name]
        public string name { get; set; }

        [Password]
        public string password { get; set; }
    }
}