using static ZeroHunger.CustomValidation.assignDistributorValidation;

namespace ZeroHunger.DTOS
{
    public class DistributorDTO
    {
        public int id { get; set; }


        [nameValidation]
        public string name { get; set; }

        [contactNumberValidation]
        public string contactNumber { get; set; }


        [emailValidation]
        public string email { get; set; }


        [areaValidation]
        public string area { get; set; }


        [usernameValidation]
        public string username { get; set; }


        [passwordValidation]
        public string password { get; set; }


        public int userID { get; set; }
    }
}