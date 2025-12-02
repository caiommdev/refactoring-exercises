namespace Two;

public interface IInvoiceType
{
    string GetTypeName();
    string GetTypeDescription();
}

public class SimpleInvoiceType : IInvoiceType
{
    public string GetTypeName() => "Simples";
    public string GetTypeDescription() => "Nota fiscal simples";
}

public class TaxedInvoiceType : IInvoiceType
{
    public string GetTypeName() => "Com imposto";
    public string GetTypeDescription() => "Nota fiscal com imposto";
}

public class UnknownInvoiceType : IInvoiceType
{
    public string GetTypeName() => "Desconhecido";
    public string GetTypeDescription() => "Tipo desconhecido";
}

public class Invoice
{
    public string ClientName { get; set; }
    public string ClientEmail { get; set; }
    public decimal Amount { get; set; }
    public IInvoiceType InvoiceType { get; set; }  

    public Invoice(string clientName, string clientEmail, decimal amount, IInvoiceType invoiceType)
    {
        ClientName = clientName;
        ClientEmail = clientEmail;
        Amount = amount;
        InvoiceType = invoiceType;
    }

    public void Process()
    {
        Console.WriteLine(InvoiceType.GetTypeDescription());
        
        Console.WriteLine("--- NOTA FISCAL ---");
        Console.WriteLine($"Cliente: {ClientName}");
        Console.WriteLine($"Valor: R$ {Amount:F2}");
        Console.WriteLine($"Tipo: {InvoiceType.GetTypeName()}");
        Console.WriteLine("---------------------");
    }
}