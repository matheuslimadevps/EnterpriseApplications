using EAS.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS.Core.Data
{
    //aqui estou utilizando uma boa pratica, que ao ver geral somente entidade poderiam ser persistidas/manipuladas através do repositório genérico.
    //mas como no DDD existe o conceito de agregate root, onde uma entidade pode ser filha de outra entidade e elas são persistidas juntas
    //(tratadas como uma só através do nosso repositorio). Para isso utilizamos o IAggregateRoot, como uma interface de marcação. Para dizer que a classe é
    //de determinado tipo mas que ela não é obrigada a implementar algo do contrato. 
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {

    }
}
