using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturaDouglas.Models;

namespace TestProject1
{
    public class ProductoTest
    {
        private IList<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }

        [Fact]
        public void Producto_Precio_Mayor0_Pasa_Prueba()
        {
            var producto = new Producto
            {
                descripcion = "Tornillo",
                precio_base = 200.0m,
                cantidad = 5
            };

            var errores = ValidarModelo(producto);

            Assert.Empty(errores);
        }

        [Fact]
        public void Producto_Precio0_Prueba_Falla() 
        {
            var producto = new Producto
            {
                descripcion = "Pegante",
                precio_base = 0,
                cantidad = 10
            };

            var errores = ValidarModelo(producto);

            Assert.NotEmpty(errores);
        }

        [Fact]
        public void Producto_PrecioNegativo_Prueba_Falla() 
        {
            var producto = new Producto
            {
                descripcion = "Tuercas",
                precio_base = -100,
                cantidad = 5
            };

            var errores = ValidarModelo(producto);

            Assert.Contains(errores, e => e.MemberNames.Contains("precio_base"));
        }

        [Fact]
        public void Producto_StockNegativo_Prueba_Falla() 
        {
            var producto = new Producto
            {
                descripcion = "Clavos",
                precio_base = 50,
                cantidad = -10
            };
            var errores = ValidarModelo(producto);
            Assert.Contains(errores, e => e.MemberNames.Contains("cantidad"));
        }
    }
}
