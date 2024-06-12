using Harmoni.Core.Entities;
using Harmoni.Core.RepAbstracts;
using Harmoni.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Data.RepConcretes;

public class SettingRepository : GenericRepository<Setting>, ISettingRepository
{
    private readonly AppDbContext _appDbContext;

    public SettingRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public  Dictionary<string, string> GetSettingAsync(Func<Setting,bool>? func=null)
    {
        var setting =  _appDbContext.Settings.Where(func).ToDictionary(s => s.Key, s => s.Value);
        return setting;
    }

}