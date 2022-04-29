
namespace Xadrez
{
    class Torre : Peca
    {
        public override bool Vertical { get; set; } = true;
        public override bool Horizontal { get; set; } = true;
        public bool Baixo { get; set; }
        public override bool Limite { get; set; } = false;

        public override string ToString()
        {
            return "T";
        }
    }
}