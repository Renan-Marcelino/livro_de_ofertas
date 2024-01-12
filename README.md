# livro_de_ofertas

Livro de ofertas
Parabéns!! você foi contratado por uma corretora para montar um sistema de livro de ofertas de vendas e compras.
Um livro de ofertas nada mais é que uma lista de um mesmo produto organizado pelo seu preço.

A cada negociação de compra ou venda de livros de ofertas são atualizadas, podendo inserir, remover ou modificar as ofertas presentes no livro. Cada operação no livro gera uma nova mensagem que é composta por 4 parâmetros, o primeiro valor é a posição da atualização, já segunda é o tipo de ação a ser tomada, em terceiro temos o valor e por última a quantidade. Cada propriedade está descrita na tabela abaixo:

PROPRIEDADE	TIPO	VALORES
POSIÇÃO	INTEIRO	valores positivos diferentes de 0
ACÃO	INTEIRO	0 = INSERIR, 1 = MODIFICAR, 2 = DELETAR**
VALORES	DOBRO	Qualquer valor positivo diferente de 0
QUANTIDADE	INTEIRO	Qualquer valor positivo diferente de 0
Exemplo:
LIVRO DE OFERTA

POSIÇÃO	VALENTIA	QUANTIDADE
1	15.4	50
2	15.4	10
3	15,9	20
4	16.1	100
5	16h20	20
6	16h43	30
7	17h20	70
8	17h35	80
9	17h50	200
Seu objetivo é fazer um programa que receba e processe todas as notificações de atualizações de um livro de ofertas e imprima seu resultado.

Entrada:
A primeira linha é composta por um inteiro informando o número de notificações e as linhas subsequências contêm as notificações no seguinte formato: posição,ação,valor,quantidade .

exemplo:
12
1,0,15,4,50
2,0,15,5,50
2,2,0,0
2,0,15,4,10
3,0,15,9,30
3,1,0,20
4,0,16,50,200
5,0,17,00,100
5,0,16,59,20
6,2,0,0
1,2,0,0
2,1,15,6,0

Saída:
A saída deve seguir o seguinte formato onde cada linha representa uma posição.

1,15,4,10
2,15,6,20
3,16,50,200
4,16,59,20\

representação do resultado

POSIÇÃO	VALENTIA	QUANTIDADE
1	15.4	10
2	15.6	20
3	16h50	200
4	16h59	20

LINK DO PROJETO:
https://dotnetfiddle.net/7lVfD5
