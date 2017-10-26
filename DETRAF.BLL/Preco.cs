using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DETRAF.BLL
{
    public abstract class Preco
    {
        public Preco(){}

        private int eot;
        private decimal valorHorarioNormal;
        private decimal valorHorarioReduzido;
        private decimal valorHorarioDiferenciado;
        private decimal valorHorarioSuperReduzido;

        public int Eot
        {
            get { return eot; }
            set { eot = value; }
        }
        public decimal ValorHorarioNormal
        {
            get { return valorHorarioNormal; }
            set { valorHorarioNormal = value; }
        }
        public decimal ValorHorarioReduzido
        {
            get { return valorHorarioReduzido; }
            set { valorHorarioReduzido = value; }
        }
        public decimal ValorHorarioDiferenciado
        {
            get { return valorHorarioDiferenciado; }
            set { valorHorarioDiferenciado = value; }
        }
        public decimal ValorHorarioSuperReduzido
        {
            get { return valorHorarioSuperReduzido; }
            set { valorHorarioSuperReduzido = value; }
        }            

        public abstract bool Validar(string caminho);

        public abstract bool Processar(string caminho);

    }

}