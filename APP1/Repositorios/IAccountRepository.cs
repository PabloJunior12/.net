using APP1.models;

namespace APP1.Repositorios
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts(int page, int size);
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> GetAccountByAccountNumber(string accountNumber);
        Task InsertAccount(Account account);
        Task UpdateAccount(Account account);
        Task DeleteAccount(int id);



    }
}
