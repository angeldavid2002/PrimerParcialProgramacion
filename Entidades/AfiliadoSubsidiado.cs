using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    public class AfiliadoSubsidiado : Afiliado
    {
        public AfiliadoSubsidiado()
        {
            this.diasAfiliacion = 0;
            this.liquidacionAfiliacion = 0;
            this.primaAdicional = 0;
            this.valorUPCDiaria = 2000;
            this.edad = 0;
            this.numeroLiquidacion = 0;
            this.identificacionAfiliado = string.Empty;
            this.nombre1Afiliado = string.Empty;
            this.nombre2Afiliado = string.Empty;
            this.apellido1Afiliado = string.Empty;
            this.apellido2Afiliado = string.Empty;
            this.tipoAfiliacion = 'S';
        }
        public override string ImprimirDatos()
        {
            return "Tipo afiliacion: "+tipoAfiliacion+"\n"+
                "dias de afiliacion: " + diasAfiliacion + "\n" +
                "liquidacion de afiliacion: " + liquidacionAfiliacion + "\n" +
                "prima adicional: " + primaAdicional + "\n" +
                "valor UPC diaria: " + valorUPCDiaria + "\n" +
                "edad: " + edad + "\n" +
                "numero de liquidacion: " + numeroLiquidacion + "\n" +
                "identificacion del afiliado: " + identificacionAfiliado + "\n" +
                "nombre: " + nombre1Afiliado + " " + nombre2Afiliado + " " +
                apellido1Afiliado + " " + apellido2Afiliado + "\n"+
                "sexo: " + sexo + "\n";
        }
        public override double CalcularLiquidacionAfiliacion()
        {
            primaAdicional = CalcularPrimaAdicional();
            liquidacionAfiliacion = diasAfiliacion * valorUPCDiaria * primaAdicional;
            return liquidacionAfiliacion;
        }
        public override double CalcularPrimaAdicional()
        {
            if (edad < 1)
            {
                return 2.0;
            }
            else if ((edad >= 1) && (edad <= 15))
            {
                return 0.8;
            }
            else if ((edad >= 16) && (edad <= 18))
            {
                if (sexo=='M')
                {
                    return 0.2;
                }
                else
                {
                    return 0.3;
                }
            }
            else if ((edad >= 19) && (edad <= 44))
            {
                return 1.0;
            }
            else if ((edad >= 45) && (edad <= 69))
            {
                return 2.5;
            }
            else
            {
                return 3.0;
            }
        }
    }
}
