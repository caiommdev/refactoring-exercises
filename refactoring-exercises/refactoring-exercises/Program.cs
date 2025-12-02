﻿using One;
using Six;

Console.WriteLine("------------------------------QUESTION ONE------------------------------");
ValueClassifier classifier = new ValueClassifier();
classifier.PrintClassification(15);
classifier.PrintClassification(10);
classifier.PrintClassification(5);
classifier.PrintClassification(-9999);

Console.WriteLine("\n------------------------------QUESTION SIX------------------------------");
Console.WriteLine("Demonstração de Polimorfismo com Documentos\n");

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
