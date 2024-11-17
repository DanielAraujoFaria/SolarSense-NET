
# Solar Sense - GLOBAL

O **Solar Sense** é um produto inovador que permite aos consumidores monitorar a eficiência e o desempenho de painéis solares em suas propriedades. Através de uma plataforma intuitiva, ele oferece informações em tempo real, permitindo ajustes para maximizar a produção de energia e garantir a manutenção preventiva dos sistemas solares.

## Índice

- [Proposta](#proposta)
- [Design Patterns](#design-patterns)
- [Instruções](#instruções)
- [Testes Implementados](#testes-implementados)
- [Clean Code](#clean-code)
- [IA Generativa](#ia-generativa)
- [Autores](#autores)

## Proposta

O **Solar Sense** é uma solução para monitorar o desempenho de painéis solares. O produto atende a diferentes públicos, oferecendo benefícios como otimização de energia, monitoramento remoto e insights em tempo real.

#### 1. **Proprietários de Residências**
- **Motivações**: Maximizar a economia, monitorar o desempenho dos painéis e melhorar a sustentabilidade.
  
#### 2. **Empresas de Energia Solar**
- **Motivações**: Diferenciar-se no mercado, oferecer manutenção preventiva e ajustar o design da instalação.

#### 3. **Agricultores e Pequenos Negócios Rurais**
- **Motivações**: Monitoramento remoto, garantir eficiência e prever custos de operação.

#### 4. **Empresas e Instituições Públicas**
- **Motivações**: Otimizar energia solar, melhorar a sustentabilidade e fornecer dados para stakeholders.

#### 5. **Entusiastas de Tecnologia Verde**
- **Motivações**: Testar novas tecnologias, personalizar o sistema e liderar a sustentabilidade.

#### Razões para Compra
- **Economizar Dinheiro**: Melhor desempenho dos painéis.
- **Autonomia Energética**: Monitoramento em tempo real.
- **Sustentabilidade**: Cumprir metas ambientais.
- **Facilidade e Conforto**: Acompanhamento remoto.
- **Segurança**: Manutenção preventiva e detecção de problemas.


## Design Patterns

#### **Singleton**
O padrão Singleton garante que uma classe tenha apenas uma única instância em todo o sistema e fornece um ponto de acesso global a essa instância. Optamos por utilizar esse padrão em nosso projeto para situações onde é essencial que exista apenas uma instância de um objeto, como o gerenciamento de conexões de banco de dados ou controle de configurações globais.

A principal vantagem do Singleton é que ele evita a criação de múltiplas instâncias desnecessárias, o que economiza recursos e simplifica o gerenciamento de estados compartilhados entre diferentes partes do sistema.

## Instruções
Para rodar o nosso projeto, basta clonar o repositório, abrir a pasta SolarSense-NET no Visual Studio e executar o projeto SolarSense.API. Quando o projeto compilar e carregar, o site da documentação Swagger será aberto, permitindo que você teste nossa API de Usuário, Painel e Produção Painel, os elementos mais importantes para o nosso produto.

Disponibilizamos os seguintes arquivos JSON para testar os endpoints. Sinta-se à vontade para modificar qualquer informação nos arquivos JSON, conforme desejar!
JSON exemplo para POST de Usuários:
CLIENTE
```json
{
    "id": 1,
    "nome": "Maria Oliveira",
    "email": "maria.oliveira@exemplo.com",
    "senha": "senhaSegura123",
    "tipo": "CLIENTE",
    "notificacoes": "SIM",
    "dataCadastro": "2024-11-15"
}
```
ADMIN
```json
{
    "id": 2,
    "nome": "Carlos Souza",
    "email": "carlos.souza@exemplo.com",
    "senha": "senha1234",
    "tipo": "ADMIN",
    "notificacoes": "SIM",
    "dataCadastro": "2024-11-15"
}
```


JSON exemplo para POST de Paineis:
É importante saber que para fazer o POST de Paineis é necessário cadastrar um usuário antes!
```json
{
    "id": 1,
    "idCliente": 1,
    "nome": "Painel Solar Modelo X",
    "potencia": 350,
    "localizacao": "Rooftop - Setor Norte",
    "tipoPainel": "Monocristalino",
    "dataInstalacao": "2024-01-15"
}
```

JSON exemplo para POST da Produção dos Paineis:
```json
{
    "id": 1,
    "idPainel": 1,
    "dataMedicao": "2024-11-15T10:00:00",
    "energia": 123.45,
    "eficiencia": 85,
    "alerta": "SIM"
}
```

## Testes Implementados

Implementamos testes unitários e de integração para garantir a confiabilidade e a consistência das principais funcionalidades da aplicação. Esses testes cobrem as classes de Usuario, Painel, ProducaoPainel e PainelPotencia (Nossa classe para o Machine Learning) validando todas as operações CRUD (Create, Read, Update e Delete) em cada uma dessas entidades. Os testes verificam o comportamento correto dos serviços e a comunicação apropriada com os endpoints, ajudando a identificar possíveis problemas e garantindo uma integração eficaz entre os componentes.

#### **Rodando testes**

Para rodar os testes é simples. ao abrir o projeto no Visual Studio basta procurar a opção **"Teste"** e selecionar **"Executar Todos os Testes"** e após alguns segundos de espera será possível ver o resultado no lado direito da janela abaixo da legenda **"Resultados"**


## Clean Code

O projeto segue os princípios de **Clean Code** para garantir que o código seja legível, fácil de manter e intuitivo para outros desenvolvedores. As principais práticas implementadas incluem:
As variáveis, métodos e classes possuem nomes descritivos e claros, o que facilita  o entendimento do propósito de cada componente sem necessidade de comentários extensos.

#### **Organização e Estrutura** 

O projeto é dividido em camadas diferentes, sendo elas:
 
- **API** (para a API)
- **Database** (para gerenciamento de dados)
- **ML** (para o machine learning) 
- **Repository** (para o repositório)
- **Services** (lógica de negócios)
- **Test** (para realizar os testes) 

Cada camada possui responsabilidade clara, facilitando a manutenção e testes.

## IA Generativa

Nosso projeto incorpora **IA generativa** utilizando **ML.NET** para criar recomendações personalizadas de painéis solares e produção de energia com base no histórico de uso. O modelo de machine learning analisa os dados e oferece sugestões precisas e úteis.

#### Estrutura e Funcionamento do Sistema de Recomendação

A classe **PainelPotenciaEngine** é responsável por treinar, prever e recomendar produtos (como painéis solares e ajustes de produção de energia). O sistema utiliza **Matrix Factorization** para mapear as interações entre o cliente e os produtos.

## Autores

- [Arthur Mitsuo Yamamoto - RM551283](https://github.com/ArthurMitsuoYamamoto)
- [Daniel dos Santos Araujo Faria - RM99067](https://github.com/DanielAraujoFaria)
- [Enzo Lafer Gallucci - RM551111](https://github.com/EnzoLafer)
- [Francineldo Luan Martins Alvelino - RM99558](https://github.com/FrancineldoLuan)
- [Ramon Cezarino Lopez - RM551279](https://github.com/RamonCezarinoLopez)
