namespace Domain.Exceptions;

public class BusinessRuleExpection : Exception
{
    public ExceptionHandlerSeverity Severity { get; set; } = ExceptionHandlerSeverity.ALERTA;

    public BusinessRuleExpection(string message, Exception inner) : base(message, inner) { }

    public BusinessRuleExpection(string message, ExceptionHandlerSeverity severity) : base(message)
    {
        this.Severity = severity;
    }

}
