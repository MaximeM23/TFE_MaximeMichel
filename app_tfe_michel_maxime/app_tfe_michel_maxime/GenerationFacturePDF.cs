using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Properties;
using iText.IO.Image;
using System.Drawing;


namespace app_tfe_michel_maxime
{
    class GenerationFacturePDF
    {

        private string CheminBureau = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();

        public bool GenerationFactureVente(FactureVente FactureVente, bool Recreation = true)
        {
            int FileCompteur = 0;
            string Path = "";

            //Création du répertoire
            if (!Directory.Exists(string.Format("{0}\\FactureVente", CheminBureau)))
            {
                Directory.CreateDirectory(string.Format("{0}\\FactureVente", CheminBureau));
            }

            // Vérification de l'existance du fichier.
            if (File.Exists(string.Format("{0}\\FactureVente\\{1}-{2}.pdf", CheminBureau,DateTime.Now.Year, FactureVente.Id.ToString())))
            {
                // On incrémente une fois comme il existe pour que ce soit égal à 1.
                FileCompteur++;
                while (File.Exists(string.Format("{0}\\{1}-{2}({3}).pdf", CheminBureau,DateTime.Now.Year, FactureVente.Id.ToString(), FileCompteur)))
                {
                    // On incrémente le nombre de fois que ce fichier existe avec les numéros entre parenthèse.
                    FileCompteur++;
                }
            }


            if ((FileCompteur >= 1) && (Recreation == true))
            {
                Path = string.Format("{0}\\FactureVente\\{1}-{2}({3}).pdf", CheminBureau,DateTime.Now.Year, FactureVente.Id.ToString(), FileCompteur);
                #region Generation du bon de commande s'il n'est pas disponible sur l'ordinateur
                using (FileStream fs = File.Create(Path))
                {

                    fs.Close();
                    PdfWriter writer = new PdfWriter(Path);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document doc = new Document(pdf);

                    // Logo BMW 
                    Bitmap Logo = global::app_tfe_michel_maxime.Properties.Resources.LogoFacture;
                    System.Drawing.Image Image = Logo;
                    ImageConverter imageConverter = new ImageConverter();
                    byte[] ImageEnByte = (byte[])imageConverter.ConvertTo(Image, typeof(byte[]));
                    ImageData data = ImageDataFactory.Create(ImageEnByte);
                    iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
                    doc.Add(image);

                    doc.Add(new Paragraph($"Contrat de vente").SetTextAlignment(TextAlignment.CENTER).SetFontSize(25).SetPaddingTop(-60).SetPaddingLeft(40));
                    doc.Add(new Paragraph($"Facture n°{FactureVente.NumeroFacture}\n\n").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16).SetPaddingLeft(40));
                    Table table1 = new Table(new float[] { 275, 275 });
                    table1.SetWidth(550);
                    table1.SetFontSize(10);
                    table1.SetMarginLeft(60);

                    //Cell

                    Cell Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetMarginLeft(60);

                    Cell.Add(new Paragraph($"- Vendeur \n {FactureVente.Employe.Nom.ToUpper()} \n {FactureVente.Employe.Prenom} \n Rue Ernest Martel, 6 \n 7190 Ecaussinnes \n Tel : {FactureVente.Employe.NumeroTelephone} \n Email : {FactureVente.Employe.Email}"));
                    table1.AddCell(Cell);


                    //Cell 

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"- Client n°{FactureVente.Client.Id} \n {FactureVente.Client.Nom.ToUpper()} \n {FactureVente.Client.Prenom}\n {FactureVente.Client.Rue}, {FactureVente.Client.NumeroHabitation} \n {FactureVente.Client.Adresse.Localite}, {FactureVente.Client.Adresse.CodePostal} \n Tel :{FactureVente.Client.NumeroTelephone} \n Email : {FactureVente.Client.Email}"));
                    table1.AddCell(Cell);

                    doc.Add(table1);



                    doc.Add(new Paragraph("\nIdentification du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                    // Table 2
                    Table table2 = new Table(3);
                    table2.SetWidth(525);
                    table2.SetFontSize(10);
                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Marque / Modèle : \n BMW {FactureVente.VehiculeVente.Vehicule.Modele}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Numéro de châssis : \n {FactureVente.VehiculeVente.NumeroChassis}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Prix initial du véhicule :\n{FactureVente.VehiculeVente.Vehicule.PrixVehicule}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Kilométrage : \n{FactureVente.VehiculeVente.Kilometrage}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Année de construction : \n{FactureVente.VehiculeVente.AnneeConstruction}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    foreach (VehiculeCaracteristique C in FactureVente.VehiculeVente.Vehicule.EnumVehiculeCaracteristique)
                    {
                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"{C.Caracteristique.NomCaracteristique} \n {C.Valeur}")).SetTextAlignment(TextAlignment.CENTER);
                        table2.AddCell(Cell);
                    }

                    doc.Add(table2);

                    doc.Add(new Paragraph("\nDescription des options du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));


                    // Table 3
                    Table table3 = new Table(new float[] { 425, 100 });
                    table3.SetWidth(525);
                    table3.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    doc.Add(table3);

                    // Table 4
                    Table table4 = new Table(new float[] { 425, 100 });
                    table4.SetWidth(525);
                    table4.SetFontSize(10);

                    foreach (ChoixOptionVehicule COV in FactureVente.VehiculeVente.EnumChoixOptionVehicule)
                    {
                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.NomOption}"));
                        table4.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.Prix} €"));
                        table4.AddCell(Cell);
                    }

                    doc.Add(table4);



                    doc.Add(new Paragraph("\nDescription des différents packs du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                    // Table 5
                    Table table5 = new Table(new float[] { 425, 100 });
                    table5.SetWidth(525);
                    table5.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom du pack d'options")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix du pack")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    doc.Add(table5);

                    // Table 6
                    Table table6 = new Table(new float[] { 425, 100 });
                    table6.SetWidth(525);
                    table6.SetFontSize(10);

                    foreach (ChoixPackVehicule CPV in FactureVente.VehiculeVente.EnumChoixPackVehicule)
                    {
                        StringBuilder Pack = new StringBuilder();

                        Pack.Append($"{CPV.PackOptionPackVehicule.NomPack}\n");
                        Cell = new Cell();

                        foreach (PackOption PO in CPV.PackOptionPackVehicule.EnumPackOption)
                        {
                            Pack.Append($"-  {PO.OptionVehicule.NomOption} - {PO.OptionVehicule.TypeOption.NomType} \n");
                        }
                        Cell.Add(new Paragraph(Pack.ToString()));
                        table6.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{CPV.PackOptionPackVehicule.PrixPack} €"));
                        table6.AddCell(Cell);
                    }

                    doc.Add(table6);



                    // Table 7
                    Table table7 = new Table(2);
                    table7.SetWidth(525);
                    table7.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"Remise \nPrix HTVA\n Prix avec TVA de {FactureVente.PourcentageTva}%")).SetTextAlignment(TextAlignment.LEFT);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingLeft(300);
                    table7.AddCell(Cell);


                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    double PrixAvecTva = ((FactureVente.VehiculeVente.PrixTotal * double.Parse(FactureVente.PourcentageTva.ToString())) / 100) - FactureVente.RemiseSurReprise + FactureVente.VehiculeVente.PrixTotal;
                    Cell.Add(new Paragraph($"-{FactureVente.RemiseSurReprise} €\n {FactureVente.VehiculeVente.PrixTotal - FactureVente.RemiseSurReprise} €\n {PrixAvecTva.ToString("F")} € ")).SetTextAlignment(TextAlignment.LEFT);
                    table7.AddCell(Cell);

                    doc.Add(table7);



                    doc.Add(new Paragraph($"\n\nFait à Ecaussinnes le {DateTime.Now.Date.ToString("dd - MM - yyyy")} \n").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(12);

                    // Table 8
                    Table table8 = new Table(2);
                    table8.SetWidth(550);
                    table8.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"\nSignature du vendeur \n{FactureVente.Employe.Prenom + " " + FactureVente.Employe.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    table8.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"\nSignature du client \n{FactureVente.Client.Prenom + " " + FactureVente.Client.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingRight(25);
                    table8.AddCell(Cell);

                    doc.Add(table8);

                    doc.Close();
                    System.Diagnostics.Process.Start(Path);

                }
                #endregion
            }
            else if((FileCompteur >=1)&&(Recreation == false))
            {
                Path = string.Format("{0}\\FactureVente\\{1}-{2}.pdf", CheminBureau,DateTime.Now.Year, FactureVente.Id.ToString());
                if (File.Exists(Path))
                {
                    System.Diagnostics.Process.Start(Path);
                }
            }
            else
            {
                Path = string.Format("{0}\\FactureVente\\{1}-{2}.pdf", CheminBureau,DateTime.Now.Year, FactureVente.Id.ToString());
                #region Generation du bon de commande s'il n'est pas disponible sur l'ordinateur
                using (FileStream fs = File.Create(Path))
                {

                    fs.Close();
                    PdfWriter writer = new PdfWriter(Path);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document doc = new Document(pdf);

                    // Logo BMW 
                    Bitmap Logo = global::app_tfe_michel_maxime.Properties.Resources.LogoFacture;
                    System.Drawing.Image Image = Logo;
                    ImageConverter imageConverter = new ImageConverter();
                    byte[] ImageEnByte = (byte[])imageConverter.ConvertTo(Image, typeof(byte[]));
                    ImageData data = ImageDataFactory.Create(ImageEnByte);
                    iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
                    doc.Add(image);

                    doc.Add(new Paragraph($"Contrat de vente").SetTextAlignment(TextAlignment.CENTER).SetFontSize(25).SetPaddingTop(-60).SetPaddingLeft(40));
                    doc.Add(new Paragraph($"Facture n°{FactureVente.NumeroFacture}\n\n").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16).SetPaddingLeft(40));

                    Table table1 = new Table(new float[] { 275, 275 });
                    table1.SetWidth(550);
                    table1.SetFontSize(10);
                    table1.SetMarginLeft(60);

                    //Cell

                    Cell Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetMarginLeft(60);

                    Cell.Add(new Paragraph($"- Vendeur \n {FactureVente.Employe.Nom.ToUpper()} \n {FactureVente.Employe.Prenom} \n Rue Ernest Martel, 6 \n 7190 Ecaussinnes \n Tel : {FactureVente.Employe.NumeroTelephone} \n Email : {FactureVente.Employe.Email}"));
                    table1.AddCell(Cell);


                    //Cell 

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"- Client n°{FactureVente.Client.Id} \n {FactureVente.Client.Nom.ToUpper()} \n {FactureVente.Client.Prenom} \n {FactureVente.Client.Rue}, {FactureVente.Client.NumeroHabitation} \n {FactureVente.Client.Adresse.Localite}, {FactureVente.Client.Adresse.CodePostal} \n Tel :{FactureVente.Client.NumeroTelephone} \n Email : {FactureVente.Client.Email}"));
                    table1.AddCell(Cell);

                    doc.Add(table1);



                    doc.Add(new Paragraph("\nIdentification du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));
                    // Table 2
                    Table table2 = new Table(3);
                    table2.SetWidth(525);
                    table2.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Marque / Modèle : \n BMW {FactureVente.VehiculeVente.Vehicule.Modele}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    //Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Numéro de châssis :\n{FactureVente.VehiculeVente.NumeroChassis}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    //Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Prix initial du véhicule :\n{FactureVente.VehiculeVente.Vehicule.PrixVehicule}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Kilométrage : \n{FactureVente.VehiculeVente.Kilometrage}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Année de construction : \n{FactureVente.VehiculeVente.AnneeConstruction}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    foreach (VehiculeCaracteristique C in FactureVente.VehiculeVente.Vehicule.EnumVehiculeCaracteristique)
                    {
                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"{C.Caracteristique.NomCaracteristique} \n {C.Valeur}")).SetTextAlignment(TextAlignment.CENTER);
                        table2.AddCell(Cell);
                    }

                    doc.Add(table2);                                       

                    doc.Add(new Paragraph("\nDescription des options du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));


                    // Table 3
                    Table table3 = new Table(new float[] { 425, 100 });
                    table3.SetWidth(525);
                    table3.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    doc.Add(table3);

                    // Table 4
                    Table table4 = new Table(new float[] { 425, 100 });
                    table4.SetWidth(525);
                    table4.SetFontSize(10);

                    foreach (ChoixOptionVehicule COV in FactureVente.VehiculeVente.EnumChoixOptionVehicule)
                    {
                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.NomOption}"));
                        table4.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.Prix} €"));
                        table4.AddCell(Cell);
                    }

                    doc.Add(table4);



                    doc.Add(new Paragraph("\nDescription des différents packs du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                    // Table 5
                    Table table5 = new Table(new float[] { 425, 100 });
                    table5.SetWidth(525);
                    table5.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom du pack d'options")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix du pack")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    doc.Add(table5);

                    // Table 6
                    Table table6 = new Table(new float[] { 425, 100 });
                    table6.SetWidth(525);
                    table6.SetFontSize(10);

                    foreach (ChoixPackVehicule CPV in FactureVente.VehiculeVente.EnumChoixPackVehicule)
                    {
                        StringBuilder Pack = new StringBuilder();

                        Pack.Append($"{CPV.PackOptionPackVehicule.NomPack}\n");
                        Cell = new Cell();

                        foreach (PackOption PO in CPV.PackOptionPackVehicule.EnumPackOption)
                        {
                            Pack.Append($"-  {PO.OptionVehicule.NomOption} - {PO.OptionVehicule.TypeOption.NomType} \n");
                        }
                        Cell.Add(new Paragraph(Pack.ToString()));
                        table6.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{CPV.PackOptionPackVehicule.PrixPack} €"));
                        table6.AddCell(Cell);
                    }

                    doc.Add(table6);



                    // Table 7
                    Table table7 = new Table(2);
                    table7.SetWidth(525);
                    table7.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"Remise \nPrix HTVA\n Prix avec TVA de {FactureVente.PourcentageTva}%")).SetTextAlignment(TextAlignment.LEFT);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingLeft(300);
                    table7.AddCell(Cell);


                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    double PrixAvecTva = ((FactureVente.VehiculeVente.PrixTotal * double.Parse(FactureVente.PourcentageTva.ToString())) / 100) - FactureVente.RemiseSurReprise + FactureVente.VehiculeVente.PrixTotal;
                    Cell.Add(new Paragraph($"-{FactureVente.RemiseSurReprise} €\n {FactureVente.VehiculeVente.PrixTotal - FactureVente.RemiseSurReprise} €\n {PrixAvecTva.ToString("F")} € ")).SetTextAlignment(TextAlignment.LEFT);
                    table7.AddCell(Cell);

                    doc.Add(table7);



                    doc.Add(new Paragraph($"\n\nFait à Ecaussinnes le {DateTime.Now.Date.ToString("dd - MM - yyyy")} \n").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(12);

                    // Table 8
                    Table table8 = new Table(2);
                    table8.SetWidth(550);
                    table8.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"\nSignature du vendeur \n{FactureVente.Employe.Prenom + " " + FactureVente.Employe.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    table8.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"\nSignature du client \n{FactureVente.Client.Prenom + " " + FactureVente.Client.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingRight(25);
                    table8.AddCell(Cell);

                    doc.Add(table8);

                    doc.Close();
                    System.Diagnostics.Process.Start(Path);

                }
                #endregion
            }

            return true;
        }

        public bool GenerationFactureEntretienReparation(Facture FactureEntretienReparation, bool Recreation = false)
        {
            if (FactureEntretienReparation != null)
            {
                int FileCompteur = 0;
                string Path = "";

                //Création du répertoire
                if (!Directory.Exists(string.Format("{0}\\EntretiensEtReparation", CheminBureau)))
                {
                    Directory.CreateDirectory(string.Format("{0}\\EntretiensEtReparation", CheminBureau));
                }

                // Vérification de l'existance du fichier.
                if (File.Exists(string.Format("{0}\\EntretiensEtReparation\\{1}.pdf", CheminBureau, FactureEntretienReparation.NumeroFacture.ToString())))
                {
                    // On incrémente une fois comme il existe pour que ce soit égal à 1.
                    FileCompteur++;
                    while (File.Exists(string.Format("{0}\\{1}({2}).pdf", CheminBureau, FactureEntretienReparation.NumeroFacture.ToString(), FileCompteur)))
                    {
                        // On incrémente le nombre de fois que ce fichier existe avec les numéros entre parenthèse.
                        FileCompteur++;
                    }
                }


                if ((FileCompteur >= 1) && (Recreation == true))
                {
                    Path = string.Format("{0}\\EntretiensEtReparation\\{1}({2}).pdf", CheminBureau, FactureEntretienReparation.NumeroFacture.ToString(), FileCompteur);
                    #region Generation de la facture s'il n'est pas disponible sur l'ordinateur
                    using (FileStream fs = File.Create(Path))
                    {

                        fs.Close();
                        PdfWriter writer = new PdfWriter(Path);
                        PdfDocument pdf = new PdfDocument(writer);
                        Document doc = new Document(pdf);

                        // Logo BMW 
                        Bitmap Logo = global::app_tfe_michel_maxime.Properties.Resources.LogoFacture;
                        System.Drawing.Image Image = Logo;
                        ImageConverter imageConverter = new ImageConverter();
                        byte[] ImageEnByte = (byte[])imageConverter.ConvertTo(Image, typeof(byte[]));
                        ImageData data = ImageDataFactory.Create(ImageEnByte);
                        iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
                        doc.Add(image);

                        doc.Add(new Paragraph($"Facture n°{FactureEntretienReparation.NumeroFacture}\n\n").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16).SetMarginTop(-75));

                        Table table1 = new Table(new float[] { 550 });
                        table1.SetFontSize(10);
                        table1.SetMarginLeft(375);

                        //Cell

                        Cell Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"- Client n°{FactureEntretienReparation.RendezVous.ClientVehicule.Client.Id}\n {FactureEntretienReparation.RendezVous.ClientVehicule.Client.Nom.ToUpper()} \n {FactureEntretienReparation.RendezVous.ClientVehicule.Client.Prenom} \n Tel :{FactureEntretienReparation.RendezVous.ClientVehicule.Client.NumeroTelephone} \n Email : {FactureEntretienReparation.RendezVous.ClientVehicule.Client.Email}"));
                        table1.AddCell(Cell);

                        doc.Add(table1);

                        doc.Add(new Paragraph("\nIdentification du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                        // Table 2
                        Table table2 = new Table(3);
                        table2.SetWidth(525);
                        table2.SetFontSize(10);

                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"Marque / Modèle : \n BMW {FactureEntretienReparation.RendezVous.ClientVehicule.Vehicule.Modele}").SetTextAlignment(TextAlignment.CENTER));
                        table2.AddCell(Cell);

                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"Immatriculation :\n{FactureEntretienReparation.RendezVous.ClientVehicule.Immatriculation}").SetTextAlignment(TextAlignment.CENTER));
                        table2.AddCell(Cell);

                        // Cell

                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"Kilométrage : \n{FactureEntretienReparation.RendezVous.ClientVehicule.NumeroChassis}").SetTextAlignment(TextAlignment.CENTER));
                        table2.AddCell(Cell);

                        doc.Add(table2);


                        doc.Add(new Paragraph("\nDescription des produits utilisés").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));


                        // Table 3
                        Table table3 = new Table(new float[] { 425, 100 });
                        table3.SetWidth(525);
                        table3.SetFontSize(10);

                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph("Quantité")).SetTextAlignment(TextAlignment.CENTER);
                        Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                        table3.AddCell(Cell);

                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph("Nom de l'article")).SetTextAlignment(TextAlignment.CENTER);
                        Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                        table3.AddCell(Cell);

                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph("Prix de l'article")).SetTextAlignment(TextAlignment.CENTER);
                        Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                        table3.AddCell(Cell);

                        doc.Add(table3);

                        // Table 4
                        Table table4 = new Table(new float[] { 425, 100 });
                        table4.SetWidth(525);
                        table4.SetFontSize(10);

                        Reparation AncienneReparation = null;
                        double PrixTotal = 0;
                        double PrixTotArticle = 0;

                        foreach (Reparation R in FactureEntretienReparation.EnumReparation)
                        {
                            if (AncienneReparation == null)
                            {
                                AncienneReparation = R;
                            }
                            if (R.Article.NomArticle != AncienneReparation.Article.NomArticle)
                            {
                                Cell = new Cell();
                                Cell.Add(new Paragraph($"{AncienneReparation.Article.NomArticle}"));
                                table4.AddCell(Cell);

                                Cell = new Cell();
                                Cell.Add(new Paragraph($"{AncienneReparation.QuantiteArticle}"));
                                table4.AddCell(Cell);

                                Cell = new Cell();
                                Cell.Add(new Paragraph($"{AncienneReparation.Article.PrixUnite} €"));
                                table4.AddCell(Cell);

                                AncienneReparation = R;
                            }
                            else
                            {
                                PrixTotArticle = R.Article.PrixUnite;
                            }
                            PrixTotal += R.Article.PrixUnite;
                        }

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{AncienneReparation.Article.NomArticle}"));
                        table4.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{AncienneReparation.QuantiteArticle}"));
                        table4.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{AncienneReparation.Article.PrixUnite} €"));
                        table4.AddCell(Cell);

                        foreach (FactureEntretien FE in FactureEntretienReparation.EnumFactureEntretien)
                        {
                            Cell = new Cell();
                            Cell.Add(new Paragraph($"1"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{FE.Entretien.TypeEntretien}"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{FE.Entretien.Prix} €"));
                            table4.AddCell(Cell);
                            PrixTotal += FE.Entretien.Prix;
                        }

                        doc.Add(table4);


                        foreach (FactureEntretien FE in FactureEntretienReparation.EnumFactureEntretien)
                        {
                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{FE.Entretien.TypeEntretien}"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"1"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{FE.Entretien.Prix} €"));
                            table4.AddCell(Cell);
                            PrixTotal += FE.Entretien.Prix;
                        }

                        doc.Add(table4);


                        // Table 5
                        Table table5 = new Table(2);
                        table5.SetWidth(525);
                        table5.SetFontSize(10);

                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph($"Heures prestées : " + FactureEntretienReparation.HeurePrestation + "h\n Prix HTVA\n Prix avec TVA de 21%")).SetTextAlignment(TextAlignment.LEFT);
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.SetPaddingLeft(300);
                        table5.AddCell(Cell);


                        // Cell
                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        double PrixHeurePrestation = FactureEntretienReparation.HeurePrestation * 12.5;
                        double PrixAvecTva = (((PrixTotal + PrixHeurePrestation) * 21) / 100) + PrixTotal + PrixHeurePrestation;
                        Cell.Add(new Paragraph($"{PrixHeurePrestation} € \n{PrixTotal + PrixHeurePrestation} €\n{PrixAvecTva.ToString("F")} € ")).SetTextAlignment(TextAlignment.LEFT);
                        table5.AddCell(Cell);

                        doc.Add(table5);




                        doc.Add(new Paragraph($"\n\nFait à Ecaussinnes le {DateTime.Now.Date.ToString("dd - MM - yyyy")} \n").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(12);

                        doc.Close();

                        System.Diagnostics.Process.Start(Path);
                    }
                    #endregion
                }
                else if ((FileCompteur >= 1) && (Recreation == false))
                {
                    Path = string.Format("{0}\\EntretiensEtReparation\\{1}.pdf", CheminBureau, FactureEntretienReparation.NumeroFacture.ToString());
                    if (File.Exists(Path))
                    {
                        System.Diagnostics.Process.Start(Path);
                    }
                }
                else
                {
                    Path = string.Format("{0}\\EntretiensEtReparation\\{1}.pdf", CheminBureau, FactureEntretienReparation.NumeroFacture.ToString());

                    #region Generation du bon sans existance du PDF sur l'ordinateur
                    using (FileStream fs = File.Create(Path))
                    {

                        fs.Close();
                        PdfWriter writer = new PdfWriter(Path);
                        PdfDocument pdf = new PdfDocument(writer);
                        Document doc = new Document(pdf);
                        // Logo BMW 
                        Bitmap Logo = global::app_tfe_michel_maxime.Properties.Resources.LogoFacture;
                        System.Drawing.Image Image = Logo;
                        ImageConverter imageConverter = new ImageConverter();
                        byte[] ImageEnByte = (byte[])imageConverter.ConvertTo(Image, typeof(byte[]));
                        ImageData data = ImageDataFactory.Create(ImageEnByte);
                        iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
                        doc.Add(image);


                        doc.Add(new Paragraph($"Facture n°{FactureEntretienReparation.NumeroFacture}\n\n").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16).SetMarginTop(-75));

                        Table table1 = new Table(new float[] { 550 });
                        table1.SetFontSize(10);
                        table1.SetMarginLeft(375);

                        //Cell

                        Cell Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"- Client n°{FactureEntretienReparation.RendezVous.ClientVehicule.Client.Id} \n {FactureEntretienReparation.RendezVous.ClientVehicule.Client.Nom.ToUpper()} \n {FactureEntretienReparation.RendezVous.ClientVehicule.Client.Prenom} \n Tel :{FactureEntretienReparation.RendezVous.ClientVehicule.Client.NumeroTelephone} \n Email : {FactureEntretienReparation.RendezVous.ClientVehicule.Client.Email}"));
                        table1.AddCell(Cell);

                        doc.Add(table1);



                        doc.Add(new Paragraph("\nIdentification du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                        // Table 2
                        Table table2 = new Table(2);
                        table2.SetWidth(525);
                        table2.SetFontSize(10);

                        // Cell

                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"Marque / Modèle : \n BMW {FactureEntretienReparation.RendezVous.ClientVehicule.Vehicule.Modele}").SetTextAlignment(TextAlignment.CENTER));
                        Cell.Add(new Paragraph($"Immatriculation :\n{FactureEntretienReparation.RendezVous.ClientVehicule.Immatriculation}").SetTextAlignment(TextAlignment.CENTER));

                        table2.AddCell(Cell);

                        doc.Add(table2);


                        doc.Add(new Paragraph("\nDescription des produits utilisés").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));


                        // Table 3
                        Table table3 = new Table(new float[] { 325, 100, 125 });
                        table3.SetWidth(525);
                        table3.SetFontSize(10);

                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph("Nom de l'article")).SetTextAlignment(TextAlignment.CENTER);
                        Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                        table3.AddCell(Cell);

                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph("Quantité")).SetTextAlignment(TextAlignment.CENTER);
                        Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                        table3.AddCell(Cell);

                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph("Prix de l'article")).SetTextAlignment(TextAlignment.CENTER);
                        Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                        table3.AddCell(Cell);

                        doc.Add(table3);

                        // Table 4
                        Table table4 = new Table(new float[] { 325, 100, 125 });
                        table4.SetWidth(525);
                        table4.SetFontSize(10);


                        double PrixTotal = 0;

                        foreach (Reparation R in FactureEntretienReparation.EnumReparation)
                        {
                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{R.Article.NomArticle}"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{R.QuantiteArticle}"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{R.Article.PrixUnite} €"));
                            table4.AddCell(Cell);

                            PrixTotal += R.Article.PrixUnite * R.QuantiteArticle;
                        }

                        foreach (FactureEntretien FE in FactureEntretienReparation.EnumFactureEntretien)
                        {
                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{FE.Entretien.TypeEntretien}"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"1"));
                            table4.AddCell(Cell);

                            Cell = new Cell();
                            Cell.Add(new Paragraph($"{FE.Entretien.Prix} €"));
                            table4.AddCell(Cell);
                            PrixTotal += FE.Entretien.Prix;
                        }

                        doc.Add(table4);


                        // Table 5
                        Table table5 = new Table(2);
                        table5.SetWidth(525);
                        table5.SetFontSize(10);


                        // Cell
                        Cell = new Cell();
                        Cell.Add(new Paragraph($"Heures prestées : " + FactureEntretienReparation.HeurePrestation + "h\n Prix HTVA\n Prix avec TVA de 21%")).SetTextAlignment(TextAlignment.LEFT);
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.SetPaddingLeft(300);
                        table5.AddCell(Cell);


                        // Cell
                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        double PrixHeurePrestation = FactureEntretienReparation.HeurePrestation * 12.5;
                        double PrixAvecTva = (((PrixTotal + PrixHeurePrestation) * 21) / 100) + PrixTotal + PrixHeurePrestation;
                        Cell.Add(new Paragraph($"{PrixHeurePrestation} € \n{PrixTotal + PrixHeurePrestation} €\n{PrixAvecTva.ToString("F")} € ")).SetTextAlignment(TextAlignment.LEFT);
                        table5.AddCell(Cell);

                        doc.Add(table5);

                        doc.Add(new Paragraph($"\n\nFait à Ecaussinnes le {DateTime.Now.Date.ToString("dd - MM - yyyy")} \n").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(12);

                        doc.Close();

                        System.Diagnostics.Process.Start(Path);
                    }
                    #endregion
                }
            }
            return true;
        }

        public bool GenerationBonDeCommande(FactureVente VehiculeCommande, bool Recreation = true)
        {

            int FileCompteur = 0;
            string Path = "";

            //Création du répertoire
            if (!Directory.Exists(string.Format("{0}\\BonDeCommande", CheminBureau)))
            {
                Directory.CreateDirectory(string.Format("{0}\\BonDeCommande", CheminBureau));
            }

            // Vérification de l'existance du fichier.
            if (File.Exists(string.Format("{0}\\BonDeCommande\\{1}.pdf", CheminBureau, VehiculeCommande.NumeroFacture.ToString())))
            {
                // On incrémente une fois comme il existe pour que ce soit égal à 1.
                FileCompteur++;
                while (File.Exists(string.Format("{0}\\{1}({2}).pdf", CheminBureau, VehiculeCommande.NumeroFacture.ToString(), FileCompteur)))
                {
                    // On incrémente le nombre de fois que ce fichier existe avec les numéros entre parenthèse.
                    FileCompteur++;
                }
            }


            if ((FileCompteur >= 1) && (Recreation == true))
            {
                Path = string.Format("{0}\\BonDeCommande\\{1}({2}).pdf", CheminBureau, VehiculeCommande.NumeroFacture.ToString(), FileCompteur);
                #region Generation du bon de commande s'il n'est pas disponible sur l'ordinateur
                using (FileStream fs = File.Create(Path))
                {

                    fs.Close();
                    PdfWriter writer = new PdfWriter(Path);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document doc = new Document(pdf);

                    // Logo BMW 
                    Bitmap Logo = global::app_tfe_michel_maxime.Properties.Resources.LogoFacture;
                    System.Drawing.Image Image = Logo;
                    ImageConverter imageConverter = new ImageConverter();
                    byte[] ImageEnByte = (byte[])imageConverter.ConvertTo(Image, typeof(byte[]));
                    ImageData data = ImageDataFactory.Create(ImageEnByte);
                    iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
                    doc.Add(image);

                    doc.Add(new Paragraph($"Bon de commande").SetTextAlignment(TextAlignment.CENTER).SetFontSize(25).SetPaddingTop(-60).SetPaddingLeft(40));
                    doc.Add(new Paragraph($"Facture n°{VehiculeCommande.NumeroFacture}\n\n").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16).SetPaddingLeft(40));

                    Table table1 = new Table(new float[] { 275, 275 });
                    table1.SetWidth(550);
                    table1.SetFontSize(10);
                    table1.SetMarginLeft(60);

                    //Cell

                    Cell Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);


                    Cell.Add(new Paragraph($"- Vendeur \n {VehiculeCommande.Employe.Nom.ToUpper()} \n {VehiculeCommande.Employe.Prenom} \n Rue Ernest Martel, 6 \n 7190 Ecaussinnes \n Tel : {VehiculeCommande.Employe.NumeroTelephone} \n Email : {VehiculeCommande.Employe.Email}"));
                    table1.AddCell(Cell);


                    //Cell 

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetMarginLeft(75);
                    Cell.Add(new Paragraph($"- Client n°{VehiculeCommande.Client.Id}\n {VehiculeCommande.Client.Nom.ToUpper()} \n {VehiculeCommande.Client.Prenom} \n {VehiculeCommande.Client.Rue}, {VehiculeCommande.Client.NumeroHabitation} \n {VehiculeCommande.Client.Adresse.Localite}, {VehiculeCommande.Client.Adresse.CodePostal} Tel :{VehiculeCommande.Client.NumeroTelephone} \n Email : {VehiculeCommande.Client.Email}"));
                    table1.AddCell(Cell);

                    doc.Add(table1);



                    doc.Add(new Paragraph("\nIdentification du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                    // Table 2
                    Table table2 = new Table(3);
                    table2.SetWidth(525);
                    table2.SetFontSize(10);
                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Marque / Modèle : \n BMW {VehiculeCommande.VehiculeVente.Vehicule.Modele}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Prix initial du véhicule :\n{VehiculeCommande.VehiculeVente.Vehicule.PrixVehicule}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    foreach (VehiculeCaracteristique C in VehiculeCommande.VehiculeVente.Vehicule.EnumVehiculeCaracteristique)
                    {
                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"{C.Caracteristique.NomCaracteristique} \n {C.Valeur}")).SetTextAlignment(TextAlignment.CENTER);
                        table2.AddCell(Cell);
                    }

                    doc.Add(table2);

                    doc.Add(new Paragraph("\nDescription des options du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));


                    // Table 3
                    Table table3 = new Table(new float[] { 425, 100 });
                    table3.SetWidth(525);
                    table3.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    doc.Add(table3);

                    // Table 4
                    Table table4 = new Table(new float[] { 425, 100 });
                    table4.SetWidth(525);
                    table4.SetFontSize(10);

                    foreach (ChoixOptionVehicule COV in VehiculeCommande.VehiculeVente.EnumChoixOptionVehicule)
                    {
                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.NomOption}"));
                        table4.AddCell(Cell);

                        int TailleNomOption = COV.OptionVehicule.NomOption.Length;

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.Prix} €"));
                        table4.AddCell(Cell);
                    }

                    doc.Add(table4);



                    doc.Add(new Paragraph("\nDescription des différents packs du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                    // Table 5
                    Table table5 = new Table(new float[] { 425, 100 });
                    table5.SetWidth(525);
                    table5.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom du pack d'options")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix du pack")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    doc.Add(table5);

                    // Table 6
                    Table table6 = new Table(new float[] { 425, 100 });
                    table6.SetWidth(525);
                    table6.SetFontSize(10);

                    foreach (ChoixPackVehicule CPV in VehiculeCommande.VehiculeVente.EnumChoixPackVehicule)
                    {
                        StringBuilder Pack = new StringBuilder();

                        Pack.Append($"{CPV.PackOptionPackVehicule.NomPack}\n");
                        Cell = new Cell();

                        foreach (PackOption PO in CPV.PackOptionPackVehicule.EnumPackOption)
                        {
                            Pack.Append($"-  {PO.OptionVehicule.NomOption} - {PO.OptionVehicule.TypeOption.NomType} \n");
                        }
                        Cell.Add(new Paragraph(Pack.ToString()));
                        table6.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{CPV.PackOptionPackVehicule.PrixPack} €"));
                        table6.AddCell(Cell);
                    }

                    doc.Add(table6);


                    // Table 7
                    Table table7 = new Table(2);
                    table7.SetWidth(525);
                    table7.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"Prix HTVA")).SetTextAlignment(TextAlignment.LEFT);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingLeft(300);
                    table7.AddCell(Cell);


                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"{VehiculeCommande.VehiculeVente.PrixTotal} € ")).SetTextAlignment(TextAlignment.LEFT);
                    table7.AddCell(Cell);

                    doc.Add(table7);


                    doc.Add(new Paragraph($"\n\nFait à Ecaussinnes le {DateTime.Now.Date.ToString("dd - MM - yyyy")} \n").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(12);

                    // Table 8
                    Table table8 = new Table(2);
                    table8.SetWidth(550);
                    table8.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"\nSignature du vendeur \n{VehiculeCommande.Employe.Prenom + " " + VehiculeCommande.Employe.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    table8.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"\nSignature du client \n{VehiculeCommande.Client.Prenom + " " + VehiculeCommande.Client.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingRight(25);
                    table8.AddCell(Cell);

                    doc.Add(table8);

                    doc.Close();

                    System.Diagnostics.Process.Start(Path);
                }
                #endregion
            }
            else if ((FileCompteur >= 1) && (Recreation == false))
            {
                Path = string.Format("{0}\\BonDeCommande\\{1}.pdf", CheminBureau, VehiculeCommande.NumeroFacture.ToString());
                if (File.Exists(Path))
                {
                    System.Diagnostics.Process.Start(Path);
                }
            }
            else
            {
                Path = string.Format("{0}\\BonDeCommande\\{1}.pdf", CheminBureau, VehiculeCommande.NumeroFacture.ToString());

                #region Generation du bon sans existance du PDF sur l'ordinateur
                using (FileStream fs = File.Create(Path))
                {

                    fs.Close();
                    PdfWriter writer = new PdfWriter(Path);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document doc = new Document(pdf);

                    // Logo BMW 
                    Bitmap Logo = global::app_tfe_michel_maxime.Properties.Resources.LogoFacture;
                    System.Drawing.Image Image = Logo;
                    ImageConverter imageConverter = new ImageConverter();
                    byte[] ImageEnByte = (byte[])imageConverter.ConvertTo(Image, typeof(byte[]));
                    ImageData data = ImageDataFactory.Create(ImageEnByte);
                    iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
                    doc.Add(image);

                    doc.Add(new Paragraph($"Bon de commande").SetTextAlignment(TextAlignment.CENTER).SetFontSize(25).SetPaddingTop(-60).SetPaddingLeft(40));
                    doc.Add(new Paragraph($"Facture n°{VehiculeCommande.NumeroFacture}\n\n").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16).SetPaddingLeft(40));

                    Table table1 = new Table(new float[] { 275, 275 });
                    table1.SetWidth(550);
                    table1.SetFontSize(10);
                    table1.SetMarginLeft(60);

                    //Cell

                    Cell Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);


                    Cell.Add(new Paragraph($"- Vendeur \n {VehiculeCommande.Employe.Nom.ToUpper()} \n {VehiculeCommande.Employe.Prenom} \n Rue Ernest Martel, 6 \n 7190 Ecaussinnes  \n Tel : {VehiculeCommande.Employe.NumeroTelephone} \n Email : {VehiculeCommande.Employe.Email}"));
                    table1.AddCell(Cell);


                    //Cell 

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetMarginLeft(30);
                    Cell.Add(new Paragraph($"- Client n°{VehiculeCommande.Client.Id}\n {VehiculeCommande.Client.Nom.ToUpper()} \n {VehiculeCommande.Client.Prenom} \n {VehiculeCommande.Client.Rue}, {VehiculeCommande.Client.NumeroHabitation} \n {VehiculeCommande.Client.Adresse.Localite}, {VehiculeCommande.Client.Adresse.CodePostal} \n Tel :{VehiculeCommande.Client.NumeroTelephone} \n Email : {VehiculeCommande.Client.Email}"));
                    table1.AddCell(Cell);

                    doc.Add(table1);



                    doc.Add(new Paragraph("\nIdentification du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                    // Table 2
                    Table table2 = new Table(3);
                    table2.SetWidth(525);
                    table2.SetFontSize(10);
                    // Cell

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Marque / Modèle : \n BMW {VehiculeCommande.VehiculeVente.Vehicule.Modele}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"Prix initial du véhicule :\n{VehiculeCommande.VehiculeVente.Vehicule.PrixVehicule}").SetTextAlignment(TextAlignment.CENTER));
                    table2.AddCell(Cell);

                    foreach (VehiculeCaracteristique C in VehiculeCommande.VehiculeVente.Vehicule.EnumVehiculeCaracteristique)
                    {
                        Cell = new Cell();
                        Cell.SetBorderLeft(Border.NO_BORDER);
                        Cell.SetBorderTop(Border.NO_BORDER);
                        Cell.SetBorderRight(Border.NO_BORDER);
                        Cell.SetBorderBottom(Border.NO_BORDER);
                        Cell.Add(new Paragraph($"{C.Caracteristique.NomCaracteristique} \n {C.Valeur}")).SetTextAlignment(TextAlignment.CENTER);
                        table2.AddCell(Cell);
                    }

                    doc.Add(table2);


                    doc.Add(new Paragraph("\nDescription des options du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));


                    // Table 3
                    Table table3 = new Table(new float[] { 425, 100 });
                    table3.SetWidth(525);
                    table3.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix de l'option")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table3.AddCell(Cell);

                    doc.Add(table3);

                    // Table 4
                    Table table4 = new Table(new float[] { 425, 100 });
                    table4.SetWidth(525);
                    table4.SetFontSize(10);

                    foreach (ChoixOptionVehicule COV in VehiculeCommande.VehiculeVente.EnumChoixOptionVehicule)
                    {
                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.NomOption}"));
                        table4.AddCell(Cell);

                        int TailleNomOption = COV.OptionVehicule.NomOption.Length;

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{COV.OptionVehicule.Prix} €"));
                        table4.AddCell(Cell);
                    }

                    doc.Add(table4);



                    doc.Add(new Paragraph("\nDescription des différents packs du véhicule").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16));

                    // Table 5
                    Table table5 = new Table(new float[] { 425, 100 });
                    table5.SetWidth(525);
                    table5.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Nom du pack d'options")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph("Prix du pack")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY, 5);
                    table5.AddCell(Cell);

                    doc.Add(table5);

                    // Table 6
                    Table table6 = new Table(new float[] { 425, 100 });
                    table6.SetWidth(525);
                    table6.SetFontSize(10);

                    foreach (ChoixPackVehicule CPV in VehiculeCommande.VehiculeVente.EnumChoixPackVehicule)
                    {
                        StringBuilder Pack = new StringBuilder();

                        Pack.Append($"{CPV.PackOptionPackVehicule.NomPack}\n");
                        Cell = new Cell();

                        foreach (PackOption PO in CPV.PackOptionPackVehicule.EnumPackOption)
                        {
                            Pack.Append($"-  {PO.OptionVehicule.NomOption} - {PO.OptionVehicule.TypeOption.NomType} \n");
                        }
                        Cell.Add(new Paragraph(Pack.ToString()));
                        table6.AddCell(Cell);

                        Cell = new Cell();
                        Cell.Add(new Paragraph($"{CPV.PackOptionPackVehicule.PrixPack} €"));
                        table6.AddCell(Cell);
                    }

                    doc.Add(table6);
                    // Table 7
                    Table table7 = new Table(2);
                    table7.SetWidth(525);
                    table7.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"Prix HTVA")).SetTextAlignment(TextAlignment.LEFT);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingLeft(280);
                    table7.AddCell(Cell);


                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"{VehiculeCommande.VehiculeVente.PrixTotal} € ")).SetTextAlignment(TextAlignment.LEFT);
                    table7.AddCell(Cell);

                    doc.Add(table7);


                    doc.Add(new Paragraph($"\n\nFait à Ecaussinnes le {DateTime.Now.Date.ToString("dd - MM - yyyy")} \n").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(12);

                    // Table 8
                    Table table8 = new Table(2);
                    table8.SetWidth(550);
                    table8.SetFontSize(10);

                    // Cell
                    Cell = new Cell();
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.Add(new Paragraph($"\nSignature du vendeur \n{VehiculeCommande.Employe.Prenom + " " + VehiculeCommande.Employe.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    table8.AddCell(Cell);

                    // Cell
                    Cell = new Cell();
                    Cell.Add(new Paragraph($"\nSignature du client \n{VehiculeCommande.Client.Prenom + " " + VehiculeCommande.Client.Nom.ToUpper()}")).SetTextAlignment(TextAlignment.CENTER);
                    Cell.SetBorderLeft(Border.NO_BORDER);
                    Cell.SetBorderTop(Border.NO_BORDER);
                    Cell.SetBorderRight(Border.NO_BORDER);
                    Cell.SetBorderBottom(Border.NO_BORDER);
                    Cell.SetPaddingRight(25);
                    table8.AddCell(Cell);

                    doc.Add(table8);


                    doc.Close();

                    System.Diagnostics.Process.Start(Path);
                }
                #endregion
            }

            return true;
        }
    
    }            
}
