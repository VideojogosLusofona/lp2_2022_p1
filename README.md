<!--
Projeto 1 de Linguagens de Programação II 2022/23 (c) by Nuno Fachada

Projeto 1 de Linguagens de Programação II 2022/23 is licensed under a
Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

You should have received a copy of the license along with this
work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.
-->

# Projeto 1 de Linguagens de Programação II 2022/23

## Introdução

Os grupos devem implementar, em Unity 2021.3 LTS, os estágios iniciais de um
[jogo 4X][4X], nomeadamente um mapa com diferentes tipos de terreno e recursos.

O projetos têm de ser desenvolvidos por **grupos de 2 a 3 alunos** (não são
permitidos grupos individuais). Até **31 de outubro** é necessários que:

* Indiquem a composição do grupo.
* Indiquem o URL do repositório **privado** do projeto no GitHub.
* Convidem o [docente][Nuno Fachada] para ter acesso a este mesmo repositório
  privado.

Os projetos serão automaticamente clonados às **23h00 de 4 de dezembro** sendo a
entrega feita desta forma, sem intervenção dos alunos. Repositórios e/ou
projetos não funcionais nesta data não serão avaliados.

## Funcionamento da aplicação

### Resumo

A aplicação deve (1) abrir um ficheiro descrevendo o mapa do jogo, (2) mostrar o
mapa no ecrã, e (3) permitir que o utilizador clique em cada _tile_ do mapa,
mostrando a informação sobre esse mesmo _tile_.

### Detalhes

#### Mapas

Os mapas são constituídos por _tiles_ 2D. Cada _tile_ é composto por **um
tipo de terreno base** e **zero ou mais recursos**, que definem a **riqueza
gerada pelo _tile_** em cada turno do hipotético jogo 4X.

Um _tile_ pode gerar dois tipos de riqueza, dependendo do seu tipo de terreno
base e recursos disponíveis:

* _Coin_: representa a riqueza monetária.
* _Food_: representa a produção alimentar.

Um _tile_ tem um e apenas um tipo de terreno base. A seguinte tabela indica os
diferentes tipos de terreno base e a riqueza que cada um gera:

| Terreno base | Código no ficheiro | _Coin_ | _Food_ |
|--------------|--------------------|-------:|-------:|
| Desert       | `desert`           | 0      | 0      |
| Plains       | `plains`           | 0      | 2      |
| Hills        | `hills`            | 1      | 1      |
| Mountain     | `mountain`         | 1      | 0      |
| Water        | `water`            | 0      | 1      |

Um _tile_ pode ainda ter zero ou mais recursos, que modificam a riqueza do tipo
de terreno base:

| Recurso      | Código no ficheiro | _Coin_ | _Food_ |
|--------------|--------------------|-------:|-------:|
| Plants       | `plants`           | +1     | +2     |
| Animals      | `animals`          | +1     | +3     |
| Metals       | `metals`           | +3     | -1     |
| Fossil Fuel  | `fossilfuel`       | +5     | -3     |
| Luxury       | `luxury`           | +4     | -1     |
| Pollution    | `pollution`        | -3     | -3     |

Dentro do possível, estas regras não devem estar demasiado enraizadas no código,
devendo ser fácil alterá-las durante o desenvolvimento do hipotético jogo.

#### Abrir ficheiro

A aplicação começa por pedir ao utilizador o ficheiro descrevendo o mapa. Estes
ficheiros devem ter a extensão `map4x`. Por exemplo, `mapa1.map4x`,
`mapa2.map4x` ou `world.map4x` são nomes válidos para ficheiros que descrevem
mapas. A secção [Formato dos ficheiros de mapa] contém mais detalhes
sobre o formato interno destes ficheiros.

Para simplificar, a aplicação procura apenas mapas na pasta `map4xfiles` (tudo
em minúsculas), localizada no _Desktop_/ambiente de trabalho do utilizador
atual. A aplicação apresenta ao utilizador uma lista ("_scrolável_") com os
ficheiros `map4x` existentes nessa pasta, e o utilizador seleciona um deles.
Quem quiser fazer uma aplicação mais avançada, com bonificação na nota, pode
tentar usar um _asset_ como o [UnitySimpleFileBrowser] que consiga abrir
ficheiros `map4x` em qualquer parte do disco.

#### Mostrar o mapa no ecrã

Após abrir um ficheiro válido, a aplicação mostra o mapa no ecrã. O mapa deve
caber no ecrã, seja qual for o seu tamanho real. Por outras palavras, o mapa
deve ser escalado de modo a ficar totalmente visível no ecrã, seja o seu tamanho
10x5 ou 200x400. Em alternativa, podem implementar um sistema de _scroll_ e/ou
_zoom_, mas esta é uma abordagem mais avançada e inteiramente opcional.

A renderização de cada _tile_ pode ser feita com as _sprites_ básicas fornecidas
pelo Unity. Cada tipo de terreno deve ser representado por uma _sprite_ quadrada
cuja cor deve ser apropriada ao terreno em questão. Por cima da _sprite_ do
terreno devem ser colocadas as _sprites_ dos recursos existentes nesse _tile_.
Sugiro que usem _sprites_ do tipo círculo ou triângulo, cada uma representando
um recurso diferente (usem cores/formas para diferenciar entre recursos). Mesmo
que o _tile_ tenha todos os recursos possíveis, deve ser sempre visível a
_sprite_ de fundo que representa o tipo de terreno base.

Se tiverem tempo podem melhorar a apresentação e usar _tilesets_ gráficos mais
apelativos, embora isso não seja muito valorizado na nota final, uma vez que a
principal componente aqui a ser avaliada é a programação. Em qualquer dos casos,
deve ser sempre possível distinguir o terreno base e eventuais recursos nele
existentes.

Se o utilizador clicar num _tile_, deve ser apresentada informação detalhada
sobre o mesmo, como descrito na próxima secção.

#### Ver informação detalhada sobre um _tile_

Ao clicar num _tile_ deve ser mostrado um painel de informação detalhado sobre
esse mesmo _tile_. Em particular, deve ser mostrado:

* A renderização do _tile_ em tamanho um pouco maior.
* Qual o terreno base.
* Quais os recursos.
* Qual o _coin_ produzido em cada turno tendo em conta o terreno base e os
  recursos existentes.
* Qual a _food_ produzida em cada turno tendo em conta o terreno base e os
  recursos existentes.

O painel pode ser fechado pelo utilizador, voltando a aplicação a mostrar o
mapa.

#### Funcionalidade futura

O UI da aplicação deve ter 5 botões, claramente marcados de 1 a 5. Ao clicar num
destes botões, deve aparecer um painel praticamente vazio, apenas com a mensagem
"For the future 1" para o botão 1, "For the future 2" para o botão 2, etc.

O painel pode ser fechado pelo utilizador, voltando a aplicação a mostrar o
mapa.

Esta funcionalidade será implementada individualmente para o Projeto 2, durante
a sessão de avaliação de _live coding_ agendada para dia 13 de dezembro. Por
esta razão será muito difícil fazerem o Projeto 2 (_live coding_) caso não
tenham completado com sucesso este projeto.

Exemplos do tipo de perguntas que poderão surgir no Projeto 2 está disponível
[aqui](livecoding.md).

#### Outros

* Poderá ser útil existir uma legenda relacionando as _sprites_ com os tipos
  de terreno e diferentes recursos que representam.
* A aplicação não deve _crashar_ com exceções, mas sim mostrar ao utilizador, de
  forma elegante, possíveis erros que possam ocorrer (por exemplo, na leitura do
  ficheiro caso este tenha um formato inválido).

### Formato dos ficheiros de mapa

O formato dos ficheiros é o seguinte (`<componente>` significa um componente
obrigatório e `[componente]` representa um componente opcional):

```text
<rows> <cols>
<base_terrain> [resource1] [resource2] [...]
<base_terrain> [resource1] [resource2] [...]
<base_terrain> [resource1] [resource2] [...]
<...>
```

A primeira linha indica o número de linhas e colunas do mapa. As linhas
seguintes representam _tiles_, começando pelo terreno base, seguindo-se os
respetivos recursos opcionais (zero ou mais). O número de _tiles_ deve ser igual
a `rows` _x_ `cols`. Cada nova linha (_tile_) no ficheiro avança uma coluna no
mapa, passando para a próxima linha no mapa quando atingir o número máximo de
colunas. O seguinte mapa é válido (notar que `#` significa o início de um
comentário, que deve ser ignorado):

```text
3 4               # Mapa com 3 linhas e 4 colunas
plains            # Linha 1, coluna 1
plains animals    # Linha 1, coluna 2
plains            # Linha 1, coluna 3
plains            # Linha 1, coluna 4
# Aqui começam os tiles da 2ª linha
plains plants     # Linha 2, coluna 1
hills metals luxury  # etc...
hills luxury
mountain
# De seguida os tiles na 3ª e última linha
plains plants animals
hills metals fossilfuel
mountain metals plants fossilfuel
mountain plants
# Tudo o que aparecer a seguir de # deve ser ignorado
```

Este enunciado inclui um gerador de mapas totalmente aleatórios para testarem o
vosso projeto. O gerador é executado da seguinte forma na pasta do enunciado
(não funciona se estiverem noutra pasta que não a do enunciado):

```text
$ dotnet run --project Generator -- 10 10 mymap.map4x
```

O comando anterior cria um mapa 10x10 e guarda-o no ficheiro `mymap.map4x`.

Atenção que é necessário terem instalado o [.NET SDK 6.0] para executar este
comando.

## Dicas e sugestões

### Organização do projeto e estrutura de classes

O projeto deve estar devidamente organizado, seguindo a fazendo uso de classes,
`struct`s e/ou enumerações, conforme seja mais apropriado. Cada tipo (i.e.,
classe, `struct` ou enumeração) deve ser colocado num ficheiro com o mesmo nome.
Por exemplo, uma classe chamada `Tile` deve ser colocada no ficheiro `Tile.cs`.
Por sua vez, a escolha da coleção ou coleções a usar também deve ser adequada
ao problema.

A estrutura de classes deve ser bem pensada e organizada de forma lógica,
fazendo uso de *design patterns* quando apropriado. Em particular, o projeto
deve seguir uma abordagem [MVC] (discutida em LP1, ver _slides_ do semestre
passado), e ser desenvolvido tendo em conta os princípios de programação
orientada a objetos, como é o caso, entre outros, dos princípios [SOLID].
Estes princípios devem ser balanceados com o princípio [KISS], crucial no
desenvolvimento de qualquer aplicação.

<!--
### Sugestão para arquitetura do projeto

Seja em consola ou Unity, um bom modelo para começar a organizar as classes
deste projeto é o seguinte:

* Uma classe controladora central que guia o programa. Tudo o que acontece
  no programa parte desta classe.
* Uma classe exclusivamente dedicada ao UI.
* Uma classe cuja responsabilidade é apenas abrir o ficheiro e produzir as
  coleções necessárias de...
* Uma classe cuja única responsabilidade é realizar _queries_ e devolver os
  resultados...

Esta sugestão é apenas um ponto de partida, pois poderão ser necessárias mais
classes/tipos para obter uma boa arquitetura. Dependendo da implementação,
também é possível obter bons designs com abordagens ligeiramente diferentes.
-->

## Objetivos e critério de avaliação

Este projeto tem os seguintes objetivos:

* **O1** - Programa deve funcionar como especificado.
* **O2** - Projeto e código bem organizados, nomeadamente:
  * Estrutura de classes bem pensada (ver secção
    [Organização do projeto e estrutura de classes][orgclasses]).
  * Inexistência de código "morto", que não faz nada, como por exemplo
    variáveis, propriedades ou métodos nunca usados.
  * Projeto compila e executa sem erros e/ou *warnings*.
* **O3** - Código devidamente indentado, comentado e documentado. Documentação
  deve ser feita com [comentários de documentação XML][XML].
* **O4** - Repositório Git deve refletir boa utilização do mesmo, com
  *commits* de todos os elementos do grupo e mensagens de *commit* que sigam
  as melhores práticas para o efeito (como indicado
  [aqui](https://chris.beams.io/posts/git-commit/),
  [aqui](https://gist.github.com/robertpainsi/b632364184e70900af4ab688decf6f53),
  [aqui](https://github.com/erlang/otp/wiki/writing-good-commit-messages) e
  [aqui](https://stackoverflow.com/questions/2290016/git-commit-messages-50-72-formatting)).
  Quaisquer *assets* binários, tais como imagens, devem ser integrados
  no repositório em modo Git LFS (atenção que este último ponto é **muito
  importante**).
* **O5** - Relatório em formato [Markdown] (ficheiro `README.md`),
  organizado da seguinte forma:
  * Título do projeto.
  * Autoria:
    * Nome dos autores (primeiro e último) e respetivos números de aluno.
    * Informação de quem fez o quê no projeto. Esta informação é
      **obrigatória** e deve refletir os *commits* feitos no Git.
  * Legenda dos _tiles_, ou seja, que tipo de terreno e recursos representa cada
    _sprite_.
  * Arquitetura da solução:
    * Descrição da solução, com breve explicação de como o programa foi
      organizado, indicação dos _design patterns_ utilizados e porquê, bem como
      dos cuidados tidos ao nível dos princípios [SOLID].
    * Um diagrama UML de classes simples (i.e., sem indicação dos
      membros da classe) descrevendo a estrutura de classes (**obrigatório**).
  * Referências, incluindo trocas de ideias com colegas, código aberto
    reutilizado (e.g., do StackOverflow) e bibliotecas de terceiros
    utilizadas. Devem ser o mais detalhados possível.
  * **Nota:** o relatório deve ser simples e breve, com informação mínima e
    suficiente para que seja possível ter uma boa ideia do que foi feito.
    Atenção aos erros ortográficos e à correta formatação [Markdown], pois
    ambos serão tidos em conta na nota final.

O projeto tem um peso de 3.5 valores na nota final da disciplina e será avaliado
de forma qualitativa. Isto significa que todos os objetivos têm de ser
parcialmente ou totalmente cumpridos. A cada objetivo, O1 a O5, será atribuída
uma nota entre 0 e 1. A nota do projeto será dada pela seguinte fórmula:

*N = 3.5 x O1 x O2 x O3 x O4 x O5 x D*

Em que *D* corresponde à nota da discussão e percentagem equitativa de
realização do projeto, também entre 0 e 1. Isto significa que se os alunos
ignorarem completamente um dos objetivos, não tenham feito nada no projeto ou
não comparecerem na discussão, a nota final será zero.

## Entrega

O projeto é entregue de forma automática através do GitHub. Mais concretamente,
o repositório do projeto será automaticamente clonado às **23h00 de de 4 de
dezembro de 2022**. Certifiquem-se de que a aplicação está funcional e que todos
os requisitos foram cumpridos, caso contrário o projeto não será avaliado.

O repositório deve ter:

* Projeto Unity 2021.3 LTS funcional.
* Ficheiros `.gitignore` e `.gitattributes` adequados para projetos Unity.
* Ficheiro `README.md` contendo o relatório do projeto em formato [Markdown].
* Ficheiros de imagens, contendo o diagrama UML de classes e outras figuras
  que considerem úteis. Estes ficheiros devem ser incluídos no repositório em
  modo Git LFS (assim como todos os _assets_ binários do Unity).

Em nenhuma circunstância o repositório pode ter _builds_ ou outros ficheiros
temporários do Unity (que são automaticamente ignorados se usarem um
`.gitignore` apropriado).

## Honestidade académica

Nesta disciplina, espera-se que cada aluno siga os mais altos padrões de
honestidade académica. Isto significa que cada ideia que não seja do
aluno deve ser claramente indicada, com devida referência ao respetivo
autor. O não cumprimento desta regra constitui plágio.

O plágio inclui a utilização de ideias, código ou conjuntos de soluções
de outros alunos ou indivíduos, ou quaisquer outras fontes para além
dos textos de apoio à disciplina, sem dar o respetivo crédito a essas
fontes. Os alunos são encorajados a discutir os problemas com outros
alunos e devem mencionar essa discussão quando submetem os projetos.
Essa menção **não** influenciará a nota. Os alunos não deverão, no
entanto, copiar códigos, documentação e relatórios de outros alunos, ou dar os
seus próprios códigos, documentação e relatórios a outros em qualquer
circunstância. De facto, não devem sequer deixar códigos, documentação e
relatórios em computadores de uso partilhado.

Nesta disciplina, a desonestidade académica é considerada fraude, com
todas as consequências legais que daí advêm. Qualquer fraude terá como
consequência imediata a anulação dos projetos de todos os alunos envolvidos
(incluindo os que possibilitaram a ocorrência). Qualquer suspeita de
desonestidade académica será relatada aos órgãos superiores da escola
para possível instauração de um processo disciplinar. Este poderá
resultar em reprovação à disciplina, reprovação de ano ou mesmo suspensão
temporária ou definitiva da ULHT.

*Texto adaptado da disciplina de [Algoritmos e
Estruturas de Dados][aed] do [Instituto Superior Técnico][ist]*

## Referências

* \[1\] Whitaker, R. B. (2021). **The C# Player's Guide** (4th Edition).
  Starbound Software.
* \[2\] Albahari, J., & Johannsen, E. (2020). **C# 8.0 in a Nutshell**. O’Reilly
  Media.
* \[3\] Freeman, E., Robson, E., Bates, B., & Sierra, K. (2020). **Head First
  Design Patterns** (2nd edition). O'Reilly Media.
* \[4\] Dorsey, T. (2017). **Doing Visual Studio and .NET Code Documentation
  Right**. Visual Studio Magazine. Retrieved from
  <https://visualstudiomagazine.com/articles/2017/02/21/vs-dotnet-code-documentation-tools-roundup.aspx>.

## Licenças

* Este enunciado é disponibilizado através da licença [CC BY-NC-SA 4.0].
* O código que acompanha este enunciado é disponibilizado através da licença
  [MIT].

## Metadados

* Autor: [Nuno Fachada]
* Curso:  [Licenciatura em Videojogos][lamv]
* Instituição: [Universidade Lusófona de Humanidades e Tecnologias][ULHT]

[CC BY-NC-SA 4.0]:https://creativecommons.org/licenses/by-nc-sa/4.0/
[MIT]:http://opensource.org/licenses/MIT
[lamv]:https://www.ulusofona.pt/licenciatura/videojogos
[Nuno Fachada]:https://github.com/fakenmc
[ULHT]:https://www.ulusofona.pt/
[aed]:https://fenix.tecnico.ulisboa.pt/disciplinas/AED-2/2009-2010/2-semestre/honestidade-academica
[ist]:https://tecnico.ulisboa.pt/pt/
[Markdown]:https://guides.github.com/features/mastering-markdown/
[SOLID]:https://en.wikipedia.org/wiki/SOLID
[KISS]:https://en.wikipedia.org/wiki/KISS_principle
[XML]:https://docs.microsoft.com/dotnet/csharp/codedoc
[2º projeto de LP1 2018/19]:https://github.com/VideojogosLusofona/lp1_2018_p2_solucao
[orgclasses]:#organização-do-projeto-e-estrutura-de-classes
[objetivos]:#objetivos-e-critério-de-avaliação
[4X]:https://en.wikipedia.org/wiki/4X
[UnitySimpleFileBrowser]:https://github.com/yasirkula/UnitySimpleFileBrowser
[Formato dos ficheiros de mapa]:#formato-dos-ficheiros-de-mapa
[MVC]:https://www.geeksforgeeks.org/mvc-design-pattern/
[.NET SDK 6.0]:https://dotnet.microsoft.com/download/dotnet/6.0