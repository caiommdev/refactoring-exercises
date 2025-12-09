namespace Two;

public class Invoice
{
    public string ClientName { get; private set; }
    public string ClientEmail { get; private set; }
    public decimal Amount { get; private set; }
    public IInvoiceType InvoiceType { get; private set; }  

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