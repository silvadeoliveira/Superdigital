using System;
using Superdigital.CoreShared.Enum;

namespace Superdigital.Application.Command.TransferenciaBancaria
{
    public class TrasferenciaContaCommand
    {
        public Guid NumeroContaDestino { get; private set; }
        public int StatusTrasferenciaId { get; private set; }
        public int TipoTrasferenciasId { get; private set; }
        public Guid NumeroContaOrigem { get; private set; }
        public decimal ValorTrasferencia { get; private set; }
        public DateTime DtHoraTrasferencia { get; private set; }

        public TrasferenciaContaCommand(Guid numeroContaDestino, int statusTrasferenciaId,  Guid numeroContaOrigem, decimal valorTrasferencia)
        {
            NumeroContaDestino = numeroContaDestino;
            NumeroContaOrigem = numeroContaOrigem;
            StatusTrasferenciaId = statusTrasferenciaId;
            TipoTrasferenciasId = (int)TipoTransacao.Transferencia;
            ValorTrasferencia = valorTrasferencia;
            DtHoraTrasferencia = DateTime.Now;
        }
        
    }
}