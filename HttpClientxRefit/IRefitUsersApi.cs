using Refit;

namespace HttpClientxRefit;
internal interface IRefitUsersApi
{
    [Get("/users")]
    Task<IReadOnlyCollection<User>> GetUsers();
}