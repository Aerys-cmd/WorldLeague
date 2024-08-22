using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldLeague.Domain.Exceptions
{
    public class CantAddMoreThanOneTeamFromOneCountryException : BusinessException
    {
        public CantAddMoreThanOneTeamFromOneCountryException() : base("You can't add more than one team from one country")
        {

        }
    }
}
