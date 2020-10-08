

##  API REST - Conta a pagar

	rota: api/v1/contas

	Incluir: POST
	Listar: GET

    Exemplo :
{
    "Nome" : "Conta de LUZ CEEE",
    "ValOrig" :  100,
    "DtVenc" : "2020-10-10",
    "DtPagto" : "2020-11-10"
}

    Retorno :
{
    "id": 2,
    "nome": "Conta de LUZ CEEE",
    "valOrig": 100,
    "dtVenc": "2020-10-10T00:00:00",
    "dtPagto": "2020-12-10T00:00:00",
    "diasAtraso": 31,
    "multa": 5,
    "juros": 0.3,
    "valorCorrigido": 105.98
}


