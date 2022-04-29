namespace Xadrez
{
    abstract class Peca
    {


        public virtual bool Vertical { get; set; }


        public virtual bool Horizontal { get; set; }

        public virtual bool Color { get; set; }

        public virtual bool Diagonal { get; set; }



        public virtual int Casas { get; set; }


        public virtual bool Limite { get; set; } = true;
    }
}