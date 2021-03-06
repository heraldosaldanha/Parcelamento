# Parcelamento
Biblioteca para gerar parcelas

<a name="parcelar"></a>
## Parcelar
Classe com todos os métodos disponibilizados, onde todos os métodos irão receber o valor total e a quantidade de parcelas e retornará um SortedDictionary<int, decimal> no qual é o idParcela e o valor da mesma.

<a name="parcelar.restoprimeiraparcela"></a>
### RestoPrimeiraParcela
Este método irá retornar a primeira parcela com o valor restante caso o parcelamento sobre centavos.

Ex:

Execução:

```
Parcelar.RestoPrimeiraParcela(10.0M, 6)
```

Reultado:

```
[
  (1 , 1.70M),
  (2 , 1.66M),
  (3 , 1.66M),
  (4 , 1.66M),
  (5 , 1.66M),
  (6 , 1.66M)
]
```

<a name="parcelar.restoultimaparcela"></a>
### RestoUltimaParcela
Este método irá retornar a ultima parcela com o valor restante caso o parcelamento sobre centavos.

Ex:

Execução:

```
Parcelar.RestoUltimaParcela(10.0M, 6)
```

Reultado:

```
[
  (1 , 1.66M),
  (2 , 1.66M),
  (3 , 1.66M),
  (4 , 1.66M),
  (5 , 1.66M),
  (6 , 1.70M)
]
```

<a name="parcelar.restorateadoentreparcelascrescente"></a>
### RestoRateadoEntreParcelasCrescente
Este método irá ratear o valor restante de forma igual e crescente partindo da primeira parcela caso o parcelamento sobre centavos.

Ex:

Execução:

```
Parcelar.RestoRateadoEntreParcelasCrescente(10.0M, 6)
```

Reultado:

```
[
  (1 , 1.67M),
  (2 , 1.67M),
  (3 , 1.67M),
  (4 , 1.67M),
  (5 , 1.66M),
  (6 , 1.66M)
]
```

<a name="parcelar.restorateadoentreparcelasdecrescente"></a>
### RestoRateadoEntreParcelasDecrescente
Este método irá ratear o valor restante de forma igual e decrescente partindo da ultima parcela caso o parcelamento sobre centavos.

Ex:

Execução:

```
Parcelar.RestoRateadoEntreParcelasDecrescente(10.0M, 6)
```

Reultado:

```
[
  (1 , 1.66M),
  (2 , 1.66M),
  (3 , 1.67M),
  (4 , 1.67M),
  (5 , 1.67M),
  (6 , 1.67M)
]
```

<a name="tiporateio"></a>
### TipoRateio
Enum no qual define qual o tipo de rateio

<a name="tiporateio.restoprimeiraparcela"></a>
* RestoPrimeiraParcela

<a name="tiporateio.restoultimaparcela"></a>
* RestoUltimaParcela

<a name="tiporateio.restorateadoentreparcelascrescente"></a>
* RestoRateadoEntreParcelasCrescente

<a name="tiporateio.restorateadoentreparcelasdecrescente"></a>
* RestoRateadoEntreParcelasDecrescente

## Rateio
Classe onde existe o metodo unico para realizar as mesmas funções da classe [Parcelar](#parcelar), porém de maneira unificada

### Ratear
Metodo no qual recebe  o valor total, a quantidade de parcelas e [TipoRateio](#tiporateio) no qual é um Enum que irá definir qual a forma de rateio será aplicada e retornará um SortedDictionary<int, decimal> no qual é o idParcela e o valor da mesma.
as opções do [TipoRateio](#tiporateio) equivalem aos metdos da classe [Parcelar](#parcelar).

* [TipoRateio.RestoPrimeiraParcela](#tiporateio.restoprimeiraparcela)  => [Parcelar.RestoPrimeiraParcela](#parcelar.restoprimeiraparcela)

* [TipoRateio.RestoUltimaParcela](#tiporateio.restoultimaparcela) => [Parcelar.RestoUltimaParcela](#parcelar.restoultimaparcela)

* [TipoRateio.RestoRateadoEntreParcelasCrescente](#tiporateio.restorateadoentreparcelascrescente) => [Parcelar.RestoRateadoEntreParcelasCrescente](#parcelar.restorateadoentreparcelascrescente)

* [TipoRateio.RestoRateadoEntreParcelasDecrescente](#tiporateio.restorateadoentreparcelasdecrescente) => [Parcelar.RestoRateadoEntreParcelasDecrescente](#parcelar.restorateadoentreparcelasdecrescente)

