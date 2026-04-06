using EAS.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace EAS.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(UsuarioLogin usuarioLogin);
        Task<string> Registro(UsuarioRegistro usuarioRegistro);
    }
}
