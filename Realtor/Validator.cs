using System.Text.RegularExpressions;

namespace Realtor
{
    public class Validator
    {
        public string EmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) return null;
            else return "Неверный формат почты. Пример: example@mail.com";
        }

        public string PhoneValid(string phone)
        {
            Regex regex = new Regex(@"^\+\d{11}$");
            Match match = regex.Match(phone);
            if (match.Success) return null;
            else return "Неверный формат номера телефона. Пример: +79326606137";
        }
    }
}