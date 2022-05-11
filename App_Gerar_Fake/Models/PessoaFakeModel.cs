using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App_Gerar_Fake.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
    public class PessoaFakeModel
    {
        public PessoaFakeModel()
        {
            this.JsonString = GetFake();
        }

        [JsonIgnore]
        public string JsonString { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("idade")]
        public int Idade { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonPropertyName("rg")]
        public string Rg { get; set; }

        [JsonPropertyName("data_nasc")]
        public string DataNasc { get; set; }

        [JsonPropertyName("sexo")]
        public string Sexo { get; set; }

        [JsonPropertyName("signo")]
        public string Signo { get; set; }

        [JsonPropertyName("mae")]
        public string Mae { get; set; }

        [JsonPropertyName("pai")]
        public string Pai { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("senha")]
        public string Senha { get; set; }

        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("endereco")]
        public string Endereco { get; set; }

        [JsonPropertyName("numero")]
        public int Numero { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("telefone_fixo")]
        public string TelefoneFixo { get; set; }

        [JsonPropertyName("celular")]
        public string Celular { get; set; }

        [JsonPropertyName("altura")]
        public string Altura { get; set; }

        [JsonPropertyName("peso")]
        public int Peso { get; set; }

        [JsonPropertyName("tipo_sanguineo")]
        public string TipoSanguineo { get; set; }

        [JsonPropertyName("cor")]
        public string Cor { get; set; }

        static string GetFake()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://www.4devs.com.br/ferramentas_online.php");
            request.Method = HttpMethod.Post;

            //request.Headers.Add("Accept", "/");

            var content = new MultipartFormDataContent();
            content.Add(new StringContent("I"), "sexo");
            content.Add(new StringContent("N"), "pontuacao");
            content.Add(new StringContent("0"), "idade");
            content.Add(new StringContent("sp"), "cep_estado");
            content.Add(new StringContent("1"), "txt_qtde");
            content.Add(new StringContent("gerar_pessoa"), "acao");
            request.Content = content;

            var response = client.SendAsync(request);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            return result;
        }
    }


}
