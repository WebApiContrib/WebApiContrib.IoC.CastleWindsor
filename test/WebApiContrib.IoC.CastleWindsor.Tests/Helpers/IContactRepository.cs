using System.Collections.Generic;

namespace WebApiContrib.IoC.CastleWindsor.Tests.Helpers
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
    }
}