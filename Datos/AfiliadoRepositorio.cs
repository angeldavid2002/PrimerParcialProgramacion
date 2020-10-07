using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.IO;
namespace Datos
{
    public class AfiliadoRepositorio
    {
        private readonly string FileName = "Afiliados.txt";
        public AfiliadoRepositorio()
        {
        }

        public void Guardar(Afiliado afiliado)
        {
            FileStream file = new FileStream(FileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(afiliado.tipoAfiliacion + ";" +
                afiliado.nombre1Afiliado + ";" +
                afiliado.nombre2Afiliado + ";" +
                afiliado.apellido1Afiliado + ";" +
                afiliado.apellido2Afiliado + ";" +
                afiliado.edad + ";" +
                afiliado.diasAfiliacion + ";" +
                afiliado.identificacionAfiliado + ";" +
                afiliado.liquidacionAfiliacion + ";" +
                afiliado.numeroLiquidacion + ";" +
                afiliado.sexo + ";" +
                afiliado.primaAdicional + ";" +
                afiliado.valorUPCDiaria + "" );
            writer.Close();
            file.Close();
        }
        public List<Afiliado> ConsultarTodos()
        {
            List<Afiliado> afiliados = new List<Afiliado>();
            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                Afiliado afiliado = Map(linea);
                afiliados.Add(afiliado);
            }
            reader.Close();
            file.Close();
            return afiliados;
        }
        private Afiliado Map(string linea)
        {
            Afiliado afiliado;
            char delimiter = ';';
            string[] matrizafiliado = linea.Split(delimiter);

            if (matrizafiliado[0] == "C")
            {
                afiliado = new AfiliadoContributivo();
            }
            else
            {
                afiliado = new AfiliadoSubsidiado();
            }
            AfiliacionMap(afiliado, matrizafiliado);
            return afiliado;

        }
        public Afiliado AfiliacionMap(Afiliado afiliado, string[] matrizLiquidacion)
        {
            afiliado.tipoAfiliacion = Convert.ToChar(matrizLiquidacion[0]);
            afiliado.nombre1Afiliado = matrizLiquidacion[1];
            afiliado.nombre2Afiliado = matrizLiquidacion[2];
            afiliado.apellido1Afiliado = matrizLiquidacion[3];
            afiliado.apellido2Afiliado = matrizLiquidacion[4];
            afiliado.edad = Convert.ToInt32( matrizLiquidacion[5]);
            afiliado.diasAfiliacion = Convert.ToInt32(matrizLiquidacion[6]);
            afiliado.identificacionAfiliado = matrizLiquidacion[7];
            afiliado.liquidacionAfiliacion = Convert.ToDouble(matrizLiquidacion[8]);
            afiliado.numeroLiquidacion = Convert.ToInt32(matrizLiquidacion[9]);
            afiliado.sexo = Convert.ToChar(matrizLiquidacion[10]);
            afiliado.primaAdicional = Convert.ToDouble(matrizLiquidacion[11]);
            afiliado.valorUPCDiaria = Convert.ToDouble( matrizLiquidacion[12]);

            return afiliado;
        }

    }
}
