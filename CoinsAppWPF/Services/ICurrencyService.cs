using CoinsAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinsAppWPF.Services
{
    public interface ICurrencyService
    {
        Task<List<string>> GetSymbols(CancellationToken cancellationToken);
        Task<decimal> Convert(decimal amount, string to, string from, CancellationToken cancellationToken);  
    }
}
