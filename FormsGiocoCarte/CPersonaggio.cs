using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FormsGiocoCarte
{

    public enum ClassDiscriminatorEnum 
    {
        CGuerriero,
        CMago,
        CArciere
    }


    public abstract class CPersonaggio
    {
        public string nome;
        public int punti_vita;
        public abstract ClassDiscriminatorEnum Type { get; }

        public CPersonaggio() 
        {

        }

        [JsonConstructor]
        public CPersonaggio(string nome, int punti_vita)
        {
            this.nome = nome;
            this.punti_vita = punti_vita;
        }

        public virtual int attacca()
        {
            return 5;
        }

        public void ricevi_danno(int danno)
        {
            punti_vita -= danno;
        }

        public int getVita() 
        {
            return punti_vita;
        }

        public bool e_vivo()
        {
            if (punti_vita > 0)
                return true;
            punti_vita = 0;
            return false;
        }

        public string Print()
        {
            return $"Personaggio: {nome}; Punti vita rimanenti: {punti_vita}.";
        }
    }

    public class CGuerriero : CPersonaggio
    {
        [JsonConstructor]
        public CGuerriero(string nome) : base(nome, 100) { }

        public override ClassDiscriminatorEnum Type => ClassDiscriminatorEnum.CGuerriero;
        public override int attacca()
        {
            return 20;
        }
    }

    public class CMago : CPersonaggio
    {
        [JsonConstructor]
        public CMago(string nome) : base(nome, 70) { }

        public override ClassDiscriminatorEnum Type => ClassDiscriminatorEnum.CMago;
        public override int attacca()
        {
            Random random = new Random();
            if (random.Next(100) == 0)
                return int.MaxValue;
            return 30;
        }
    }

    public class CArciere : CPersonaggio
    {
        [JsonConstructor]
        public CArciere(string nome) : base(nome, 80) { }

        public override ClassDiscriminatorEnum Type => ClassDiscriminatorEnum.CArciere;
        public override int attacca()
        {
            return 25;
        }
    }
}
