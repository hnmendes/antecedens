using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using antecedens.Domain.Entities;
using Aspose.Pdf;

namespace antecedens.Infra.CrossCutting
{
    public class PdfGenerationHelper
    {
        public async static void GenerateToDirectory(Block data)
        {
            Document document = new Document();

            string directory = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\";

            Page page = document.Pages.Add();

            foreach (PropertyInfo prop in data.AssociatedChain.GetType().GetProperties())
            {
                string paragraph = prop.Name + ": " + prop.GetValue(data.AssociatedChain);
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(paragraph));
            }

            string docTitle = "Antecedentes_Criminais-" + data.TimeStamp;
            document.SetTitle(docTitle);

            var outputFileName = System.IO.Path.Combine(directory, docTitle + ".pdf");
            await (Task.Run(() => document.Save(outputFileName)));

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
