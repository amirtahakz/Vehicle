using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.ViewModels;

namespace Vehicle.Core.Repositories
{
    public interface IEmailService
    {
        #region IMethods

        Task SendEmailAsync(EmailModel email);

        #endregion
    }
}
