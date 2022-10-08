# Enunciado exemplo do Projeto 2

_**Atenção**: Este enunciado não é para implementar no Projeto 1! É apenas um
exemplo do tipo de perguntas que poderão surgir no Projeto 2 (_live coding_)._

## Questões

1.  Cria um *fork* *privado* do projeto do teu grupo na tua conta
    pessoal de GitHub (botão no canto superior direito da página do
    projeto no GitHub). *Em alternativa* (especialmente caso o projeto
    original do teu grupo esteja na tua conta do GitHub), podes:

    1.  Criar um novo repositório *privado* vazio no GitHub, com um nome
        diferente do projeto original do grupo.
    2.  Tomar nota do URL deste novo repositório. *Não podes partilhar
        este URL com ninguém além do docente\!*
    3.  Fazer *clone* do projeto original para o teu computador (numa
        pasta diferente do projeto original\!).
    4.  Alterar localmente o URL do repositório *origin* neste *clone*
        para que aponte para o novo repositório vazio no GitHub.
    5.  Fazer *push* do estado atual do *clone* local para o novo
        repositório no GitHub.

2.  Adiciona no início (topo) do `README.md` a seguinte informação na
    forma de *lista Markdown*:

    1.  *Código* no topo deste enunciado (código só será fornecido no enunciado
        real).
    2.  O teu *nome* e *número de aluno*.

3.  Convidar o docente para colaborar no novo repositório.

4.  No Projeto 1 era pedido que criasses 5 botões, numerados de 1 a 5,
    que ao serem clicados apresentassem um painel com a mensagem “For
    the future 1”, etc. Deves substituir a mensagem em cada painel pela
    seguinte informação, **usando obrigatoriamente Linq**:

    1.  **Painel 1**: o *número de tiles* que não têm qualquer recurso.
    2.  **Painel 2**: qual o *valor médio* de *Coin* em tiles do tipo
        *mountain*.
    3.  **Painel 3**: uma *lista* dos diferentes tipos de *terreno*
        existentes no mapa, ordenada por ordem alfabética.
    4.  **Painel 4**: qual o tipo de *terreno*, *recursos* e
        *coordenadas* do *tile* com menor *Coin* no mapa atual.
    5.  **Painel 5**: o *número de tiles* completamente distintos que
        existem no mapa, ou seja, que sejam únicos relativamente ao seu
        tipo de terreno e recursos. Por exemplo:
          - Um *tile* com *mountain* e *fossilfuel* + *animals* é
            *diferente* de um *tile* com *mountain* e *animals*.
          - Um *tile* com *plains* + *metals* é *diferente* de um
            *tile* com *hills* + *metals*.
          - Um *tile* com *desert* + *plants* é *igual* a outro *tile*
            com *desert* + *plants*.
          - Um *tile* com *water* é *igual* a outro *tile* com *water*.

## Notas adicionais

- Este projeto é com consulta. Podes utilizar livros ou qualquer
  recurso na Internet. Não podes comunicar com ninguém, e a quebra
  desta regra equivale automaticamente a nota zero neste projeto.
- Este projeto tem um peso de 3 valores na nota final.
- A realização com sucesso das alíneas 1 a 3 deste enunciado vale 0.5
  valores.
- A alínea 4 vale 2.5 valores, e cada uma dos respetivas sub-alíneas
  vale por sua vez 0.5 valores.
