using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsAppWPF.Models
{
    public class GenericCoin<T>
    {
        public T Coin { get; set; }
    }
}
