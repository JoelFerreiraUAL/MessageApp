using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Contracts
{
    public interface ITenantService
    {
        int GetTenantId();
    }
}
