using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private ILogger<NewsController> Logger { get; }
        private INewsDataAccess NewsDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public NewsController(ILogger<NewsController> logger, INewsDataAccess newsDataAccess, IMapper mapper)
        {
            Logger = logger;
            NewsDataAccess = newsDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NewsDto>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(NewsController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<NewsDto>>(await this.NewsDataAccess.GetAllAsync(ct));
        }
    }
}