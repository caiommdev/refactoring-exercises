# Análise de Code Smells - Sistema Fiscal Legado

## Código Original (Java)
```java
public class Invoice {
    public String clientName;
    public String clientEmail;
    public double amount;
    public int type;

    public void enviarPorEmail(String email, String conteudo) {
        System.out.println("Enviando email para: " + email);
        System.out.println("Conteúdo:\n" + conteudo);
    }

    public void process() {
        if (clientEmail == null && !clientEmail.contains("@")) {
            System.out.println("Email inválido. Falha no envio.");
        }

        if (type == 1) {
            System.out.println("Nota fiscal simples");
        } else if (type == 2) {
            System.out.println("Nota fiscal com imposto");
        } else if (type == -1) {
            System.out.println("Nota fiscal fantasma");
        } else {
            System.out.println("Tipo desconhecido");
        }
        
        //imprimir nota
        System.out.println("--- NOTA FISCAL ---");
        System.out.println("Cliente: " + clientName);
        System.out.println("Valor: R$ " + amount);

        if (type == 1) {
            System.out.println("Tipo: Simples");
        } else if (type == 2) {
            System.out.println("Tipo: Com imposto");
        } else {
            System.out.println("Tipo: Desconhecido");
        }
        System.out.println("---------------------");
        
        // Enviar nota para email
        System.out.println("Enviando nota fiscal para: " + clientEmail);
        String nota = "--- NOTA FISCAL ---\n" +
              "Cliente: " + clientName + "\n" +
              "Valor: R$ " + amount + "\n" +
              "Tipo: " + (type == 1 ? "Simples" : type == 2 ? "Com imposto" : "Desconhecido") + "\n" +
              "---------------------";
        enviarPorEmail(clientEmail, nota);
    }
}
```

---

## Bad Smells Identificados

### 1. **Long Method** (Método Longo)
**Localização:** Método `process()`

**Descrição:** O método `process()` tem múltiplas responsabilidades: validação, classificação de tipo, impressão no console, formatação de nota fiscal e envio de email. Métodos longos são difíceis de entender, testar e manter.

**Impacto:** Dificulta a compreensão do código e aumenta a probabilidade de bugs ao fazer alterações.

---

### 2. **Magic Numbers** (Números Mágicos)
**Localização:** Valores `1`, `2`, `-1` para `type`

**Descrição:** O uso de números literais (`1`, `2`, `-1`) para representar tipos de nota fiscal torna o código difícil de entender. Não é óbvio o que cada número significa sem ler todo o contexto.

**Impacto:** Reduz a legibilidade e aumenta o risco de usar valores incorretos.

---

### 3. **Primitive Obsession** (Obsessão por Primitivos)
**Localização:** Campo `int type`

**Descrição:** O uso de `int` para representar o tipo de nota fiscal é uma forma de obsessão por primitivos. Seria melhor usar um enum ou uma hierarquia de classes para representar diferentes tipos.

**Impacto:** Não há validação de tipo em tempo de compilação, permitindo valores inválidos.

---

### 4. **Duplicated Code** (Código Duplicado)
**Localização:** Lógica de classificação de `type` repetida 3 vezes

**Descrição:** A mesma lógica condicional para verificar o tipo (`if type == 1... else if type == 2...`) aparece três vezes no método:
- Na primeira classificação (linhas 17-25)
- Na impressão da nota (linhas 32-38)
- Na formatação da string de email (linha 44)

**Impacto:** Mudanças no sistema de tipos requerem alterações em múltiplos lugares, aumentando o risco de inconsistências.

---

### 5. **Data Class** (Classe de Dados)
**Localização:** Campos públicos da classe `Invoice`

**Descrição:** Todos os campos (`clientName`, `clientEmail`, `amount`, `type`) são públicos, transformando a classe em um simples container de dados sem encapsulamento.

**Impacto:** Qualquer código externo pode modificar o estado interno da classe, quebrando invariantes e dificultando a manutenção.

---

### 6. **Feature Envy** (Inveja de Funcionalidade) - Sintoma de **Long Method**
**Localização:** Método `process()` manipula dados da própria classe

**Descrição:** Embora menos severo, o método `process()` poderia ser dividido em métodos menores que lidam com aspectos específicos (validação, impressão, envio).

**Impacto:** A classe está fazendo muitas coisas, violando o Princípio da Responsabilidade Única.

---

### 7. **Dead Code** (Código Morto)
**Localização:** Condição `type == -1` (linha 21)

**Descrição:** O comentário explicitamente afirma que este caso "nunca ocorre, mas está presente", indicando código morto ou não utilizado.

**Impacto:** Confunde desenvolvedores e adiciona complexidade desnecessária.

---

### 8. **Inappropriate Intimacy** (Intimidade Inapropriada)
**Localização:** Método `enviarPorEmail()` está na classe `Invoice`

**Descrição:** A responsabilidade de enviar email não pertence à classe `Invoice`. Isso viola o Princípio da Responsabilidade Única (SRP).

**Impacto:** Dificulta o teste unitário e a reutilização. Mudanças no sistema de email afetam a classe Invoice.

---

### 9. **Comments** (Comentários Desnecessários)
**Localização:** `//imprimir nota` e `// Enviar nota para email`

**Descrição:** Comentários que descrevem o que o código está fazendo indicam que o código não é auto-explicativo. Seria melhor extrair métodos com nomes descritivos.

**Impacto:** Comentários podem ficar desatualizados e enganosos.

---

### 10. **Refused Bequest** (Herança Recusada) - Potencial
**Localização:** Estrutura geral da classe

**Descrição:** Não há uso de herança no código atual, mas a lógica de diferentes tipos de nota fiscal sugere que uma hierarquia de classes seria mais apropriada.

**Impacto:** Código menos extensível e mais propenso a erros.

---

### 11. **Middle Man** (Intermediário) - Potencial
**Localização:** Método `enviarPorEmail()`

**Descrição:** O método apenas delega para `System.out.println`, não adicionando valor real.

**Impacto:** Camada de abstração desnecessária.

---

### 12. **Temporary Field** (Campo Temporário) - Potencial
**Localização:** Variável `nota` (linha 42)

**Descrição:** A string `nota` é construída e usada imediatamente, poderia ser simplificada.

**Impacto:** Menor, mas adiciona variável temporária desnecessária.

---

### 13. **Switch Statements** (Declarações Switch/If-Else Excessivas)
**Localização:** Múltiplas cadeias if-else-if para `type`

**Descrição:** Cadeias longas de if-else baseadas em códigos numéricos são candidatas a refatoração usando polimorfismo (padrão Strategy ou State).

**Impacto:** Dificulta extensão e manutenção.
