using System.Collections.Generic;

namespace WebApiContrib.IoC.CastleWindsor.Tests.Helpers
{
    public class FileContactRepository : IContactRepository {
        public IEnumerable<Contact> GetAll() {
            throw new System.NotImplementedException();
        }
    }

    public class InMemoryContactRepository : IContactRepository
    {
        public IEnumerable<Contact> GetAll() {
            return new List<Contact>();
        }
    }
}