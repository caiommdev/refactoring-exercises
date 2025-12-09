namespace Two;

public class TaxedInvoice : IInvoiceType
{
    public string GetTypeName() => "Com imposto";
    public string GetTypeDescription() => "Nota fiscal com imposto";
}
