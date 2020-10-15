namespace FitMe.Application.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int instructorId)
        {
            this.Token = token;
            this.InstructorId = instructorId;
        }

        public int InstructorId { get; }

        public string Token { get; }
    }
}
