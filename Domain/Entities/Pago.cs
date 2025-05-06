namespace PagosCQRSDDD.Domain.Entities
{
    public class Pago
    {
        public int Id { get; private set; }
        public string ClienteId { get; private set; }
        public decimal Monto { get; private set; }
        public DateTime FechaPago { get; private set; }
        public string MetodoPago { get; private set; }
        public string Estado { get; private set; }

        private Pago() { } // EF Core

        public Pago(string clienteId, decimal monto, string metodoPago)
        {
            ClienteId = clienteId;
            Monto = monto;
            MetodoPago = metodoPago;
            FechaPago = DateTime.UtcNow;
            Estado = "Procesado";
        }

        public void Reversar()
        {
            Estado = "Reversado";
        }
    }
}