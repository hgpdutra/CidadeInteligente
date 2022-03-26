namespace CidadeInteligente.Dominio
{
    public class EstacaoRecarga
    {
        public Guid Id { get; set; }
        public string  Nome { get; set; }
        public string Tipo { get; set; }
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
