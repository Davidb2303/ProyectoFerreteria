using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FacturaDouglas.Models;

namespace TestProject1
{
    public class UserTest
    {
        private IList<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }
        
        [Fact]
        public void Usuario_Datos_Validos_Pasar_Prueba()
        {
            var user = new AspNetUsers
            {
                UserName = "JUAN",
                Email = "juan@email.com",
                PasswordHash = "simulacion_password"
            };

            var errores = ValidarModelo(user);

            Assert.Empty(errores);
        }

        [Fact]
        public void Usuario_Correo_Invalido_Falla_Prueba()
        {
            var user = new AspNetUsers
            {
                UserName = "JUAN",
                Email = "correo",
                PasswordHash = "simulacion_password"
            };

            var errores = ValidarModelo(user);

            Assert.NotEmpty(errores);
        }

        [Fact]
        public void Usuario_Campos_Obligatorios_Falla_Prueba()
        {
            var user = new AspNetUsers
            {
                UserName = "",
                Email = "",
                PasswordHash = ""
            };

            var errores = ValidarModelo(user);

            Assert.NotEmpty(errores);
        }

        [Fact]
        public void Usuario_Sin_Contrasena_Falla_Prueba()
        {
            var user = new AspNetUsers
            {
                UserName = "JUAN",
                Email = "juan@email.com",
                PasswordHash = ""
            };

            var errores = ValidarModelo(user);

            Assert.NotEmpty(errores);
        }
    }
}