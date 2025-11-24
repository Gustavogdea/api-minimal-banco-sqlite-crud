const botaoAdicionar = document.getElementById("btn_filme");
const botaoTestarEndpoint = document.getElementById("btn_teste_endpoint");

botaoAdicionar.addEventListener("click", (evento) => {
    const filmeIncluir = document.getElementById("txt_filme");
    console.log(filmeIncluir);
    adicionarFilme(filmeIncluir.value);
    evento.preventDefault();
});

botaoTestarEndpoint.addEventListener("click", (evento) => {
    buscarFilmes();
    evento.preventDefault();
});

//Funções de Consumo da API

//GET 
async function buscarFilmes() {
    try{
        const response = await fetch('http://localhost:5214/filmes');
        const data = await response.json();
        console.log(data);
    }catch (error) {
        console.log('Erro ao buscar dados: ', error);
    }
}

//POST
async function adicionarFilme(nomeFilme) {
    const criarFilme = {
        nome: nomeFilme
    };

    try{
        const response = await fetch('http://localhost:5214/filmes', {
            method: "POST",
            headers:{
                "Content-Type": "application/json"
            },
            body: JSON.stringify(criarFilme)
        });
        const retorno = await response.json()
        console.log('Criado novo filme no banco de dados: ', retorno);
    }catch(error){
        console.error("Erro ao criar filme: ", error);
    }
}