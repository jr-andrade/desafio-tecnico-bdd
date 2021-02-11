
## Aspectos técnicos e arquiteturais da solução

O projeto foi construído utilizando a arquitetura *Onion*, pois a mesma possibilita uma divisão em camadas que facilita a construção baseada em domínios ricos (*DDD*).
Para a identificação dos elementos do domínio, optei por utilizar o *BDD* com a biblioteca *SpecFlow*. Esta técnica permite que a descoberta dos elementos que compõem o domínio aconteça à medida que os testes para cada cenário vão sendo escritos.
  
À medida que os testes de comportamento clareiam a visão do domínio, vão surgindo as interfaces do sistema, seja com serviços (login, cálculo de preço) seja com repositórios de dados. Para a implementação das classes concretas correspondentes às interfaces, utilizei a técnica de *TDD*, fazendo uso das bibliotecas *XUnit* (construção dos testes), *Moq* (configurar comportamentos esperados) e *FluentAssertions* (linguagem fluida).

Além disso, criei também alguns testes de integração para validação da funcionalidade de Autenticação/Autorização. Com estes testes, consigo provar que os recursos protegidos só estão acessíveis mediante o envio de um token de autenticação. Para este desafio, implementei a *Bearer Authentication* (autenticação mediante token JWT).

Para fins de organização, cada tipo de testes (Comportamento, Unidade e Integração) estão uma camada separada.

## Próximos Passos

Minha ideia foi utilizar o conceito de arquitetura evolutiva, ou seja, começar com um sistema monolítico e evoluir para a arquitetura de microservices, separando cada um dos módulos da aplicação (cadastro de clientes, cadastro de veículos, autenticação, locação) em seu próprio microservice. Porém, infelizmente não houve tempo hábil para concluir essa estratégia, ficando como tarefa para um projeto pessoal.

## Disclaimer

Conforme falei inicialmente, prezei pelas técnicas de *BDD* e *TDD*, respectivamente, para guiar a construção do projeto. Entretanto, à medida que o prazo foi se esgotando, deixei intencionalmente de fazer alguns testes, priorizando uma construção bem estruturada das regras de negócio.
Também não foquei na implementação do acesso a banco de dados, embora isso tenha impossibilitado a utilização de algumas técnicas, como cache. Novamente, priorizei a implementação dos requisitos.

## Navegação e Testes 

### Navegação

Para navegar pelos recursos da aplicação, utilize o *swagger*;

### Testes automatizados:

Existem 3 projetos de testes na solution:

- *DesafioLocalizaBdd.Tests.Behavior:* (Testes de comportamento)

Utilize para simular os comportamentos de Login e Simulação de locação.

- *DesafioLocalizaBdd.Tests.Integration:* (Testes de integração);

Utilize para testar fluxos que possuem integração. Ex: Autenticar antes de agendar uma locação.

- *DesafioLocalizaBdd.Tests.Unit:* (Testes de unidade)

Utilize para executar os testes unitários de cada classe.
  
  
