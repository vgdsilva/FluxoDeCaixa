# FluxoDeCaixa
 
# Sobre o Projeto
Aplicativo para controle de finanças baseado em uma planilha de fluxo de caixa para visão de gastos do dia a dia e gastos futuros


# Funcionalidades
- Adicionar Categorias (Tipo Despesa OU Renda)
- Adicionar Rendas 
- Adicionar Despesas

- Relatorio de saldo mensal
- - Mostrar um relatorio do que foi gasto no mês e o quanto ira sobrar.



# Entidades
- Categoria
    - Descrição
    - Tipo de Categoria (Renda ou Despesa ou Poupança)
    - Icone
    - Cor

- Transação
    - Descrição
    - Data de Transação
    - Observação
    - Tipo de transação (Renda ou Despesa ou Poupança)
    - Valor da Transação


# Telas
- Splash
- Onboarding
- Tabs



``` text
Projeto principal
|— Resources/ -- Armazena arquivos estáticos como imagens, fontes e outros recursos usados em todo o aplicativo.
|— Components/ -- Contém componentes reutilizáveis que são partilhados entre diferentes partes da aplicação.
|— Context/ -- Utilizado para gerenciar o estado global com a API Context ou a lógica Redux.
|— Data/ -- Contém dados estáticos ou modelos de dados que a aplicação pode utilizar.
|— Features/ -- Organiza módulos específicos de caraterísticas, agrupando componentes, estilos e lógica relacionados.
|— Hooks/ -- Armazena Hooks personalizados para encapsular lógica reutilizável.
|— Layouts/ -- Contém componentes da estrutura do aplicativo, como cabeçalhos, rodapés e wrappers de layout.
|— Pages/ -- Inclui componentes ao nível da página como parte da estrutura de roteamento do React Router ou Next.js.
|— Services/ -- Gerencia chamadas de API, serviços externos ou integrações com bibliotecas de terceiros.
|— Utils/ -- Contém funções utilitárias e auxiliares para uso geral.

``` 
