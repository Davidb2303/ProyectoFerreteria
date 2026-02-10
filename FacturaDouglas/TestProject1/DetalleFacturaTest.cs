using FacturaDouglas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class DetalleFacturaTest
    {
        private IList<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }

        [Fact]
        public void DetalleFactura_Valido_Prueba_Pasa()
        {
            var detalle = new DetalleFactura
            {
                Producto = new Producto { precio_base = 100, cantidad = 10 },
                cantidad = 2,
                total_linea = 200
            };

            var errores = ValidarModelo(detalle);

            Assert.Empty(errores);
        }

        [Fact]
        public void DetalleFactura_CantidadCero_Prueba_Falla()
        {
            var detalle = new DetalleFactura
            {
                Producto = new Producto { precio_base = 100, cantidad = 10 },
                cantidad = 0,
                total_linea = 100
            };

            var errores = ValidarModelo(detalle);

            Assert.Contains(errores, e => e.MemberNames.Contains("cantidad"));
        }
    }
}
