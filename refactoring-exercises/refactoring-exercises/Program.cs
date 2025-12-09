﻿using One;
using Two;
using Three;
using Four;
using Five;
using Six;

Console.WriteLine("=============================================================================");
Console.WriteLine("                    DEMONSTRAÇÃO DE REFATORAÇÕES");
Console.WriteLine("=============================================================================\n");


Console.WriteLine("------------------------------QUESTION ONE------------------------------");
Console.WriteLine("Classificação de Valores\n");

ValueClassifier classifier = new ValueClassifier();
classifier.PrintClassification(15);
classifier.PrintClassification(10);
classifier.PrintClassification(5);
classifier.PrintClassification(-9999);


Console.WriteLine("\n------------------------------QUESTION TWO------------------------------");
Console.WriteLine("Sistema de Notas Fiscais\n");

var simpleInvoice = new Invoice("João Silva", "joao@email.com", 1000.00m, new SimpleInvoice());
var taxedInvoice = new Invoice("Maria Santos", "maria@email.com", 2500.00m, new TaxedInvoice());

Console.WriteLine("1. Processando nota fiscal simples:");
simpleInvoice.Process();

Console.WriteLine("\n2. Processando nota fiscal com imposto:");
taxedInvoice.Process();

Console.WriteLine("\n------------------------------QUESTION THREE------------------------------");
Console.WriteLine("Sistema de E-Commerce com Descontos\n");

ECommerce ecommerce = new ECommerce();
double basePrice = 100.0;

Console.WriteLine($"Preço base: R$ {basePrice:F2}");
Console.WriteLine($"Cliente Regular (sem feriado): R$ {ecommerce.CalculatePrice(basePrice, CustomerType.Regular, false):F2}");
Console.WriteLine($"Cliente Premium (sem feriado): R$ {ecommerce.CalculatePrice(basePrice, CustomerType.Premium, false):F2}");
Console.WriteLine($"Cliente Regular (feriado): R$ {ecommerce.CalculatePrice(basePrice, CustomerType.Regular, true):F2}");
Console.WriteLine($"Cliente Premium (feriado): R$ {ecommerce.CalculatePrice(basePrice, CustomerType.Premium, true):F2}");


Console.WriteLine("\n------------------------------QUESTION FOUR------------------------------");
Console.WriteLine("Sistema de Usuários e Endereços\n");

var user = new User("Carlos Oliveira", "carlos@email.com");
Console.WriteLine($"Usuário criado: {user.Name} ({user.Email})");

var address1 = new Address("Rua das Flores, 123", "São Paulo", "SP", "01234-567", "Brasil");
var address2 = new Address("Av. Paulista, 1000", "São Paulo", "SP", "01310-100", "Brasil");

user.AddAddress(address1);
user.AddAddress(address2);

Console.WriteLine($"\nEndereços cadastrados ({user.Addresses.Count}):");
foreach (var addr in user.Addresses)
{
    Console.WriteLine($"  - {addr}");
}


Console.WriteLine("\n------------------------------QUESTION FIVE------------------------------");
Console.WriteLine("Sistema de Notificações\n");

NotificationService notificationService = new NotificationService();

Console.WriteLine("1. Enviando notificação por Email:");
notificationService.NotifyUser(NotificationChannelType.Email, "Bem-vindo ao sistema!");

Console.WriteLine("\n2. Enviando notificação por SMS:");
notificationService.NotifyUser(NotificationChannelType.Sms, "Seu código de verificação é 123456");

Console.WriteLine("\n3. Enviando notificação Push:");
notificationService.NotifyUser(NotificationChannelType.Push, "Você tem uma nova mensagem!");


Console.WriteLine("\n------------------------------QUESTION SIX------------------------------");
Console.WriteLine("Sistema de Documentos com Polimorfismo\n");

Document pdfDoc = new PdfDocument();
Document htmlDoc = new HtmlDocument();
Document textDoc = new TextDocument();

Console.WriteLine("1. Imprimindo documento PDF:");
pdfDoc.Print();

Console.WriteLine("\n2. Imprimindo documento HTML:");
htmlDoc.Print();

Console.WriteLine("\n3. Imprimindo documento TEXT:");
textDoc.Print();

Console.WriteLine("\n--- Demonstração com lista polimórfica ---");
List<Document> documents = new List<Document>
{
    new PdfDocument(),
    new HtmlDocument(),
    new TextDocument()
};

foreach (var doc in documents)
{
    doc.Print();
}

Console.WriteLine("\n=============================================================================");
Console.WriteLine("                    TODAS AS IMPLEMENTAÇÕES FINALIZADAS");
Console.WriteLine("=============================================================================");
