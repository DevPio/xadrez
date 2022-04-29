namespace Xadrez
{
    class Dama : Peca
    {

        public override bool Vertical { get; set; } = true;


        public override bool Horizontal { get; set; } = true;


        public override bool Diagonal { get; set; } = true;


        public override bool Limite { get; set; } = false;

        public override string ToString()
        {
            return "D";
        }
    }
}