namespace Two;

public class SimpleInvoice : IInvoiceType
{
    public string GetTypeName() => "Simples";
    public string GetTypeDescription() => "Nota fiscal simples";
}
