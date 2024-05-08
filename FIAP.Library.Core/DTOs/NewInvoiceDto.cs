namespace FIAP.Library.Core.DTOs
{
    public class NewInvoiceDto
    {
        public int IdCliente { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
