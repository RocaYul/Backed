using Vehiculos.Common.Models;

namespace Vehiculos.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}
