using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class DuelService
    {
        private IUnitOfWork _uow;
        public DuelService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<uint> CreateDuelAsync()
        {
            return (uint)await Task.FromResult(0);
        }

    }
}
