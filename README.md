# 📞 FaleMais - Simulador de Tarifas Skynetz

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![jQuery](https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)

Sistema web desenvolvido em C# ASP.NET WebForms que permite calcular e comparar o valor de ligações interurbanas com e sem o plano FaleMais da Skynetz Telecom.

---

## 📸 Screenshot

![Screenshot do sistema](Assets/Screenshot.png)

---

## 🛠️ Tecnologias Utilizadas

- **C#** com **ASP.NET WebForms**
- **Entity Framework 6** para mapeamento e acesso ao banco de dados
- **SQL Server LocalDB** como banco de dados
- **jQuery** para chamadas Ajax
- **Bootstrap 5** para interface responsiva

---

## ⚙️ Requisitos

- Visual Studio 2019 ou superior
- .NET Framework 4.7.2 ou superior
- SQL Server LocalDB (incluso no Visual Studio)

---

## 🚀 Como Configurar e Rodar

### 1. Clone o repositório
```bash
git clone https://github.com/luciano-andrde/Desafio_FAP_Online.git
```

### 2. Abra o projeto no Visual Studio

### 3. Restaure os pacotes NuGet
- Clique com o botão direito na **Solution**
- Selecione **Restore NuGet Packages**
- Aguarde a instalação, incluindo o **Entity Framework 6**

### 4. Configure a connection string
Verifique o arquivo `Web.config` na raiz do projeto:
```xml
<connectionStrings>
    <add name="SkynetzConnection"
         connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=SkynetzDB;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 5. Crie e popule o banco de dados
Abra o **Package Manager Console**:
> Tools → NuGet Package Manager → Package Manager Console

Execute o comando:
```powershell
Update-Database
```

### 6. Execute o projeto
Pressione **F5** ou clique em **Iniciar** no Visual Studio.

---

## 💻 Como Usar

1. Selecione o **DDD de origem** da ligação
2. Selecione o **DDD de destino** da ligação
3. Informe o **tempo** da ligação em minutos
4. Selecione o **plano FaleMais** desejado
5. Clique em **Simular Valores**
6. O sistema exibirá dois valores:
   - **Com FaleMais**: valor cobrado utilizando o plano
   - **Sem FaleMais**: valor cobrado pela tarifa normal

> Caso a rota entre origem e destino não esteja disponível, o sistema informará que a rota não está cadastrada.

---

## 📋 Planos Disponíveis

| Plano | Minutos Gratuitos |
|---|---|
| Fale Mais 30 | 30 minutos |
| Fale Mais 60 | 60 minutos |
| Fale Mais 120 | 120 minutos |

> Minutos excedentes são cobrados com acréscimo de **10%** sobre a tarifa normal.

---

## 🗺️ Rotas Disponíveis

| Origem | Destino | R$/min |
|---|---|---|
| 011 | 016 | R$ 1,90 |
| 016 | 011 | R$ 2,90 |
| 011 | 017 | R$ 1,70 |
| 017 | 011 | R$ 2,70 |
| 011 | 018 | R$ 0,90 |
| 018 | 011 | R$ 1,90 |
