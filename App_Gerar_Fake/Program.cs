using App_Gerar_Fake.Models;
using System.Text.Json;

PessoaFakeModel pessoaFake = new PessoaFakeModel();
var model = pessoaFake.JsonString;
PessoaFakeModel[] pessoa = JsonSerializer.Deserialize<PessoaFakeModel[]>(model);

var JsonIdent = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(pessoa, JsonIdent);

Console.WriteLine(json);

