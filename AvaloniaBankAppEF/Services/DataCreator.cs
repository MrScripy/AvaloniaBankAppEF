using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.Services
{
    internal class DataCreator : IDataCreator
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public DataCreator(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task FillDB()
        {
            
        }


    }
}
