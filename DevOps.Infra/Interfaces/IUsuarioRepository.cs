using DevOps.Core.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Infra.Interfaces
{
    public interface IUsuarioRepository
    {
        bool AdicionarUsuario(Usuario usuario);
        bool RemoverUsuario(int id);
        bool AtualizarUsuario(Usuario usuario);
        Usuario SelecionarUsuarioPorId(int id);
        IEnumerable<Usuario> SelecionarUsuarios();
    }
}
