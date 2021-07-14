using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using antecedens.Domain.Entities;
using Aspose.Pdf;

namespace antecedens.Infra.CrossCutting
{
    public class PdfGenerationHelper
    {
        public static void GenerateToDirectory(string directory, Chain data)
        {
            Document document = new Document();

            Page page = document.Pages.Add();

            foreach (PropertyInfo prop in data.GetType().GetProperties())
            {
                string paragraph = prop.Name + ": " + prop.GetValue(data);
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(paragraph));
            }

            string docTitle = "Antecedentes Criminais - " + data.Nome;
            document.SetTitle(docTitle);

            var outputFileName = System.IO.Path.Combine(directory, docTitle + ".pdf");
            document.Save(outputFileName);

        }

        /*public static void TestGeneration()
        {
            Chain chain = new Chain();
            chain.Nome = "Paulo Henrique Nascimento Cavalcanti";
            chain.CPF = "080.655.704-45";
            chain.CidadeNatal = "Cabo de Santo Agostinho";
            chain.CodigoCertidaoAntecedente = "50770822021";
            chain.DataNascimento = DateTime.Parse("10/10/2000");
            chain.DecisaoJudicialCondenatoria = "Nada consta";
            chain.Identidade = "10.126.539";
            chain.Mae = "Gleize Maria do Nascimento Cavalcanti";
            chain.Nacionalidade = "Brasileiro";
            chain.Pai = "Ronaldo Tenorio Cavalcanti";

            string path = @"C:\Users\paulo.cavalcanti\Documents";
            GenerateToDirectory(path, chain);
        }*/
    }
}
