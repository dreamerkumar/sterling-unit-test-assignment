namespace Sterling.Hr.Logic
{
    public interface IUserDataAccess
    {
        User[] GetAllUsers();
        User[] GetAllActiveUsers();
    }
}
