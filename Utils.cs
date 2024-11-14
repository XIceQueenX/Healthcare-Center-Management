using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude
{
    internal class Utils
    {
        public string GetFormattedDate(long date)
        {
            DateTime formattedDate = DateTimeOffset.FromUnixTimeSeconds(date).DateTime;

            return formattedDate.ToString("F"); 
        }

    }
}
