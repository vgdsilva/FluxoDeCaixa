namespace Domain.Exceptions;
public class BusinessRuleExpection : Exception
{
    public ExpectionHandlerSeverity Severity { get; set; } = ExpectionHandlerSeverity.INFORMATION;

    public BusinessRuleExpection(string message, Exception inner) : base(message, inner) { }

    public BusinessRuleExpection(string message, ExpectionHandlerSeverity severity = ExpectionHandlerSeverity.INFORMATION) : base(message)
    {
        this.Severity = severity;
    }
}

public enum ExpectionHandlerSeverity
{
    ERROR = 0,
    WARNING = 1,
    INFORMATION = 2,
    SUCCESS = 3,
}
