using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp
{
    public class ServiceApi
    {
        private readonly HttpClient client;

        public ServiceApi(HttpClient client)
        {
            this.client = client;
        }

        #region Clientes

        public async Task<IEnumerable<ClientesEntity>> ClientesGet()
        {
            var result = await client.ServicioGetAsync<IEnumerable<ClientesEntity>>("api/Clientes");
            return result;
        }
        public async Task<ClientesEntity> ClientesGetById(int id)
        {
            var result = await client.ServicioGetAsync<ClientesEntity>("api/Clientes/" + id);
            if (result.CodeError is not 0) throw new Exception(result.MsgError);
            return result;
        }
        public async Task<IEnumerable<AgenciaEntity>> AgenciaGetLista()
        {
            var result = await client.ServicioGetAsync<IEnumerable<AgenciaEntity>>("api/Agencia/Lista");
            return result;
        }
        #endregion
    }
}
