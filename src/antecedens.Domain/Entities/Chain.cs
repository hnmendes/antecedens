using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace antecedens.Domain.Entities
{

    public class Chain
    {
        [DisplayName("Código da Certidão de Antecedente")]
        public string CodigoCertidaoAntecedente { get; set; }

        [DisplayName("Status de Decisão Judicial Condenatória")]
        public string DecisaoJudicialCondenatoria { get; set; }

        public string Nome { get; set; }
        
        public string Nacionalidade { get; set; }

        [DisplayName("Nome do Pai")]
        public string Pai { get; set; }

        [DisplayName("Nome da Mãe")]
        public string Mae { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Cidade Natal")]
        public string CidadeNatal { get; set; }

        [DisplayName("Registro Nacional de Identidade")]
        public string Identidade { get; set; }

        [DisplayName("Comprovante de Pessoa Física")]
        public string CPF { get; set; }
    }
}
