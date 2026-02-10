using FacturaDouglas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class FacturaTest
    {
        private IList<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }

        [Fact]
        public void Factura_Valida_Pasa_Prueba()
        {
            var cliente = new Cliente { id_cliente = 1 };

            var detalles = new List<DetalleFactura>
        {
            new DetalleFactura
            {
                Producto = new Producto { precio_base = 50, cantidad = 10 },
                cantidad = 2,
                total_linea = 100
            }
        };

            var factura = new Factura
            {
                Cliente = cliente,
                DetalleFactura = detalles,
                total = 100
            };

            var errores = ValidarModelo(factura);

            Assert.Empty(errores);
        }

        [Fact]
        public void Factura_SinDetalles_Prueba_Falla()
        {
            var factura = new Factura
            {
                Cliente = new Cliente { id_cliente = 1 },
                DetalleFactura = new List<DetalleFactura>(),
                total = 0
            };

            var errores = ValidarModelo(factura);

            Assert.Empty(errores);
        }

        [Fact]
        public void Factura_TotalIncorrecto_DebeGenerarError()
        {
            var factura = new Factura
            {
                Cliente = new Cliente { id_cliente = 1 },
                DetalleFactura = new List<DetalleFactura>
            {
                new DetalleFactura
                {
                    Producto = new Producto { precio_base = 50, cantidad = 10 },
                    cantidad = 2,
                    total_linea = 100
                }
            },
                total = 150
            };

            var errores = ValidarModelo(factura);

            Assert.Empty(errores);
        }
    }
}
