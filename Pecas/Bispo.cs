namespace Xadrez
{
    class Bispo : Peca
    {
        public override bool Diagonal { get; set; } = true;

        public override bool Limite { get; set; } = false;

        public override string ToString()
        {
            return "B";
        }
    }
}