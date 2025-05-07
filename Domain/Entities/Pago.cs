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
            ValidarMetodoPago(monto, metodoPago);

            ClienteId = clienteId;
            Monto = monto;
            MetodoPago = metodoPago;
            FechaPago = DateTime.UtcNow;
            Estado = "Procesado";
        }

        private void ValidarMetodoPago(decimal monto, string metodoPago)
        {
            metodoPago = metodoPago.ToLower();

            if (monto > 100 && metodoPago != "tarjeta de crédito")
            {
                throw new InvalidOperationException("Pagos mayores a 100 solo pueden realizarse con tarjeta de crédito.");
            }

            if (monto <= 100 && metodoPago  != "efectivo" && metodoPago  != "transferencia")
            {
                throw new InvalidOperationException("Pagos menores o iguales a 100 solo pueden ser en efectivo o transferencia.");
            }
        }

        public void ReversarPago()
        {
            if (Estado == "Reversado")
                throw new InvalidOperationException("El pago ya está reversado.");

            Estado = "Reversado";
        }
    }
}