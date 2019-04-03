using System.Threading.Tasks;
using RPGHexplorer.Common.Encounters;

namespace RPGHexplorer.Lib.Encounters.Repositories
{
    public interface IMonsterRepository
    {
        Task<Monster> GetMonsterAsync(string monsterId);

        Task SaveMonsterAsync(Monster monster);
    }
}