using System;

namespace antecedens.Domain.Entities
{

    public class Chain
    {
        public string CodigoCertidaoAntecedente { get; set; }

        public string DecisaoJudicialCondenatoria { get; set; }

        public string Nome { get; set; }

        public string Nacionalidade { get; set; }

        public string Pai { get; set; }

        public string Mae { get; set; }

        public DateTime DataNascimento { get; set; }

        public string CidadeNatal { get; set; }

        public string Identidade { get; set; }

        public string CPF { get; set; }
    }
}
