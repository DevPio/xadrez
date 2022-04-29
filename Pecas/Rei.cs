namespace Xadrez
{
    class Rei : Peca
    {
        public override bool Vertical { get; set; } = true;

        public override bool Horizontal { get; set; } = true;

        public override bool Diagonal { get; set; } = true;

        public override int Casas { get; set; } = 1;


        public override string ToString()
        {
            return "R";
        }
    }
}