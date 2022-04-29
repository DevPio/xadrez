
namespace Xadrez
{
    class Cavalo : Peca
    {
        public override bool Vertical { get; set; } = true;
        public override bool Horizontal { get; set; } = true;

        public override int Casas { get; set; } = 3;


        public override string ToString()
        {
            return "C";
        }
    }
}