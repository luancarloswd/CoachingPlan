using CoachingPlan.SharedKernel.Events;
using CoachingPlan.SharedKernel.Messages;
using System;

namespace CoachingPlan.SharedKernel.Validations
{
    public class CPFAssertionConcern
    {
        public static DomainNotification AssertIsValid(string vrCPF, string message)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            return (valor.Length != 11)?
                new DomainNotification("AssertArgumentLength", message) : null;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            return (igual || valor == "12345678909") ?
                 new DomainNotification("AssertArgumentLength", message) : null;

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                return (numeros[9] != 0) ?
                     new DomainNotification("AssertArgumentLength", message) : null;
            }
            else
                return (numeros[9] != 11 - resultado)?
                    new DomainNotification("AssertArgumentLength", message) : null;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                return (numeros[10] != 0)?
                    new DomainNotification("AssertArgumentLength", message) : null;
            }
            else
                return (numeros[10] != 11 - resultado)?
                    new DomainNotification("AssertArgumentLength", message) : null;

        }
    }
}
