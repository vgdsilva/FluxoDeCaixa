using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.Enums;
using FluxoDeCaixa.Domain.Interfaces.Builders;

namespace FluxoDeCaixa.Domain.Builders
{
    public class CashFlowTransactionBuilder : IBuilder<CashFlowTransaction>
    {
        private readonly CashFlowTransaction _entity;

        public CashFlowTransactionBuilder()
        {
            _entity = new CashFlowTransaction();
        }

        public CashFlowTransactionBuilder SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("description is required");

            _entity.Description = description;
            return this;
        }

        public CashFlowTransactionBuilder SetAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Amount must be bigger than 0");

            _entity.Amount = amount;
            return this;
        }

        public CashFlowTransactionBuilder SetDate(DateTime date)
        {
            _entity.TransactionDate = date;
            return this;
        }

        public CashFlowTransactionBuilder SetCashFlow(string cashFlowID, CashFlow cashFlow = null)
        {
            if (string.IsNullOrEmpty(_entity.CashFlowID))
                throw new ArgumentNullException("cashFlowID is required");

            _entity.CashFlowID = cashFlowID;

            if (cashFlow != null)
                _entity.CashFlowEntity = cashFlow;

            return this;
        }

        public CashFlowTransactionBuilder SetType(TransactionTypeEnum transactionType)
        {
            _entity.TransactionType = transactionType;
            return this;
        }

        public CashFlowTransaction Build()
        {
            if (string.IsNullOrEmpty(_entity.CashFlowID))
                throw new ArgumentNullException("cashFlowID is required");

            return _entity;
        }
    }
}
