using ZeroHunger.CustomValidation;
using static ZeroHunger.CustomValidation.assignCollectorValidation;

namespace ZeroHunger.DTOS
{
    public class CollectorDTO
    {
        public int id { get; set; }

        [NameValidation]
        public string name { get; set; }

        [ContactNumberValidation]
        public string contactNumber { get; set; }

        [EmailValidation]
        public string email { get; set; }

        [VehicleTypeValidation]
        public string vehicleType { get; set; }

        [UsernameValidation]
        public string username { get; set; }

        [PasswordValidation]
        public string password { get; set; }
        public int userID { get; set; }
    }
}