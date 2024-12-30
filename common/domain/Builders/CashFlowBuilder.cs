using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.Interfaces.Builders;

namespace FluxoDeCaixa.Domain.Builders;

public class CashFlowBuilder : IBuilder<CashFlow>
{
    private readonly CashFlow _entity;

    public CashFlowBuilder()
    {
        _entity = new CashFlow();
    }

    public CashFlowBuilder SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new ArgumentNullException("cash flow description is null");

        _entity.Description = description;

        return this;
    }

    public CashFlowBuilder SetStartDate(DateTime startDate)
    {
        _entity.StartDate = startDate;

        return this;
    }

    public CashFlowBuilder SetEndDate(DateTime endDate)
    {
        _entity.EndDate = endDate;

        return this;
    }

    public CashFlowBuilder SetUser(string userId, User userEntity = null)
    {
        if (string.IsNullOrEmpty(userId)) 
            throw new ArgumentNullException("cash flow UserId is null");

        _entity.UserID = userId;

        if (userEntity != null)
            _entity.UserEntity = userEntity;

        return this;
    }

    public CashFlow Build()
    {
        return _entity;
    }
}
