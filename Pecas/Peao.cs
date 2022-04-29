
namespace Xadrez
{
    class Peao : Peca
    {
        public override bool Vertical { get; set; } = true;

        public bool Baixo { get; set; }
        public override int Casas
        {
            get; set
        ;
        } = 2;

        public override string ToString()
        {
            return "P";
        }
    }
}