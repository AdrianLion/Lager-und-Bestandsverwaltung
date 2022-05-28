using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.Library.Models
{
    public interface ICurrentUserModel
    {
        string Token { get; set; }
        string Id { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime CreatedDate { get; set; }

        void Reset();
    }
}
