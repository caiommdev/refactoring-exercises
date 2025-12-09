namespace Two;

public class UnknownInvoice : IInvoiceType
{
    public string GetTypeName() => "Desconhecido";
    public string GetTypeDescription() => "Tipo desconhecido";
}
