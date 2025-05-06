namespace PagosCQRSDDD.Application.Commands
{
    public class PagarCommand
    {
        public string ClienteId { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}