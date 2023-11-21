using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venta : EntityBase
    {
        private readonly IClienteService _clienteService;
        
        public Venta(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public DateTime fecha { get; set; }
        public List<LineaDeVenta> LineasDeVenta { get; set; }
        public double total { get; set; }
        public Cliente Cliente { get; set; }

        public void AsociarCliente(int idCliente)
        {
            Cliente clienteAsociado = _clienteService.GetClienteById(idCliente);
            this.Cliente = clienteAsociado;
        }
    }
}
