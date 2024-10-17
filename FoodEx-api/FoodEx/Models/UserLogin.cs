namespace FoodEx.Models
{
    public class UserLogin
    {
        public string? Login { get; set; }
        public string? Password { get; set; }

        public UserLogin(string Login, string Password) 
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}
