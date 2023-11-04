using Task3.Validation;
namespace Task3.DTOS
{
    public class SigninDTO
    {
        [name(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [password(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}