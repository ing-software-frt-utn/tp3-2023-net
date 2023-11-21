using Domain.Entities;
using Domain.Interfaces;
using Moq;
using Services.Interfaces;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowasd.StepDefinitions
{
    [Binding]
    public class AsociarClienteStepDefinitions
    {
        private Venta venta = new Venta();
        private Mock<IGenericRepository<Cliente>> clienteRepositoryMock;
        private Mock<IClienteService> clienteServiceMock;

       
        [Given(@"una venta en curso con la siguiente informacion:")]
        public void GivenUnaVentaEnCursoConLaSiguienteInformacion(Table table)
        {
            venta.Cliente.Id = int.Parse(table.Rows[0]["cliente asociado"]);
        }

        [Given(@"los siguientes clientes registrados:")]
        public void GivenLosSiguientesClientesRegistrados(Table table)
        {   
            List<Cliente> clientes = new List<Cliente>();

            foreach (var row in table.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.Dni = int.Parse(row["dni"]);
                cliente.CondicionTributaria = (CondicionTributaria)Enum.Parse(typeof(CondicionTributaria), row["condicion tributaria"], true);
                cliente.Cuit = row["cuit"];
                clientes.Add(cliente);
            }
            clienteServiceMock.Setup(service => service.GetClientes()).Returns(clientes);
        }

        [When(@"ingreso el DNI del cliente (.*)")]
        public void WhenIngresoElDNIDelCliente(int dni)
        {
            venta.AsociarCliente(dni);
        }

        [Then(@"se asocia el cliente a la venta\.")]
        public void ThenSeAsociaElClienteALaVenta_(Table table)
        {
            var clienteEsperado = new Cliente
            {
                Dni = int.Parse(table.Rows[0]["dni"])
            };
            Assert.Equal(clienteEsperado, venta.Cliente);
        }

        [Then(@"se muestra el mensaje ""([^""]*)""")]
        public void ThenSeMuestraElMensaje(string mensaje)
        {
             throw new NotImplementedException();
        }

    }
}
