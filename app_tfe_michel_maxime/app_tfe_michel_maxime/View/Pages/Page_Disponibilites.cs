using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace app_tfe_michel_maxime
{
    public partial class Page_Disponibilites : UserControl
    {

        #region Event de déplacement de l'application
        Point DernierClic;
        bool dragging;
        private void Page_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            DernierClic = e.Location;
        }

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ParentForm.Left += e.X - DernierClic.X;
                    ParentForm.Top += e.Y - DernierClic.Y;
                }
            }
        }

        private void Page_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion


        private int m_IdDuVehiculeType;


        // Constante permettant la construction d'un filtre spécifique comprenant l'opérateur LIKE
        private const string c_FiltreAvecLike = "%{0}%";

        private int PointDeDepart;

        private int IndiceDeCreation;

        private int IdVehicule;

        private string m_Id;

        private List<VehiculeVente> m_ListeVehiculeDispo;



        public int IdVehiculeType
        {
            get
            {
                return m_IdDuVehiculeType;
            }
            set
            {
                if ((value.GetType() == typeof(int) && value > 0))
                {
                   m_IdDuVehiculeType = value;
                }
            }
        }

        public List<VehiculeVente> ListeVehiculeDispo
        {
            get
            {
                return m_ListeVehiculeDispo;
            }
            set
            {
                if (value is List<VehiculeVente>)
                {
                    m_ListeVehiculeDispo = value;
                }
            }
        }

        public Page_Disponibilites()
        {
            InitializeComponent();
            numericUpDownTVA.Minimum = 1;
            numericUpDownTVA.Maximum = 100;
            listeDeroulanteClientVehicule1.SurChangementSelection += ListeDeroulanteClientVehicule_SurChangementSelection;
            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());

            this.MinimumSize = new Size(1108, 650);
        }

        /// <summary>
        /// Se produit lors du changement de véhicule du client
        /// </summary>
        public void ListeDeroulanteClientVehicule_SurChangementSelection(object sender,EventArgs e)
        {
            if(listeDeroulanteClientVehicule1.ClientVehiculeSelectionne != null)
            {
                textBoxRemise.Enabled = true;
            }
        }

        /// <summary>
        /// Methode permettant la création des véhicules disponibles dans la concession
        /// </summary>
        public void CreationDesComposants()
        {
            PictureBox pictureBox1 = new PictureBox();
            TextBox textBox1 = new TextBox();
            Panel panelLigneSeparatrice = new Panel();
            Button buttonVoirPlus = new Button();
            Color couleurBleu = Color.FromArgb(47, 130, 172);

            if (IndiceDeCreation == 0)
            {
                // 
                // pictureBox
                // 
                pictureBox1.Location = new System.Drawing.Point(3, -10);
                pictureBox1.Name = "pictureBox" + IdVehicule;
                pictureBox1.Size = new System.Drawing.Size(250, 150);
                pictureBox1.TabIndex = 0;
                pictureBox1.TabStop = false;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + ListeVehiculeDispo[IndiceDeCreation].Vehicule.NomImage + ""))
                {
                    pictureBox1.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + ListeVehiculeDispo[IndiceDeCreation].Vehicule.NomImage + "");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
                pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
                pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
                // 
                // textBox1
                // 
                textBox1.Location = new System.Drawing.Point(39, 125);
                textBox1.Name = "textBox" + IdVehicule;
                textBox1.Size = new System.Drawing.Size(168, 20);
                textBox1.TabIndex = 21;
                textBox1.Text = string.Format("{0} €", ListeVehiculeDispo[IndiceDeCreation].PrixTotal.ToString());
                textBox1.Enabled = false;
                // 
                // panelLigneSeparatrice
                // 
                panelLigneSeparatrice.BackColor = System.Drawing.Color.Black;
                panelLigneSeparatrice.Location = new System.Drawing.Point(0, 190);
                panelLigneSeparatrice.Name = "panelLigneSeparatrice" + IdVehicule;
                panelLigneSeparatrice.Size = new System.Drawing.Size(250, 1);
                panelLigneSeparatrice.TabIndex = 22;
                panelLigneSeparatrice.BackColor = couleurBleu;
                // 
                // buttonVoirPlus
                // 
                buttonVoirPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
                buttonVoirPlus.Cursor = System.Windows.Forms.Cursors.Hand;
                buttonVoirPlus.FlatAppearance.BorderSize = 0;
                buttonVoirPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                buttonVoirPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttonVoirPlus.ForeColor = System.Drawing.Color.White;
                buttonVoirPlus.Location = new System.Drawing.Point(39, 150);
                buttonVoirPlus.Name = IdVehicule.ToString();
                buttonVoirPlus.Size = new System.Drawing.Size(168, 25);
                buttonVoirPlus.TabIndex = 23;
                buttonVoirPlus.Text = "Voir plus >";
                buttonVoirPlus.UseVisualStyleBackColor = false;
                buttonVoirPlus.Click += buttonVoirPlusClick;

                PointDeDepart = 180;
            }
            else
            {
                // 
                // pictureBox
                // 
                pictureBox1.Location = new System.Drawing.Point(3, PointDeDepart);
                pictureBox1.Name = "pictureBox" + IdVehicule;
                pictureBox1.Size = new System.Drawing.Size(250, 150);
                pictureBox1.TabIndex = 0;
                pictureBox1.TabStop = false;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + ListeVehiculeDispo[IndiceDeCreation].Vehicule.NomImage + ""))
                {
                    pictureBox1.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + ListeVehiculeDispo[IndiceDeCreation].Vehicule.NomImage + "");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
                pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
                pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
                // 
                // textBox1
                // 
                textBox1.Location = new System.Drawing.Point(39, PointDeDepart + 135);
                textBox1.Name = "textBox" + IdVehicule;
                textBox1.Size = new System.Drawing.Size(168, 20);
                textBox1.TabIndex = 21;
                textBox1.Text = string.Format("{0} €", ListeVehiculeDispo[IndiceDeCreation].PrixTotal.ToString());
                textBox1.Enabled = false;
                // 
                // panelLigneSeparatrice
                // 
                panelLigneSeparatrice.BackColor = System.Drawing.Color.Black;
                panelLigneSeparatrice.Location = new System.Drawing.Point(0, PointDeDepart + 150 + 20 + 25);
                panelLigneSeparatrice.Name = "panelLigneSeparatrice" + IdVehicule;
                panelLigneSeparatrice.Size = new System.Drawing.Size(250, 1);
                panelLigneSeparatrice.TabIndex = 22;
                panelLigneSeparatrice.BackColor = couleurBleu;
                // 
                // buttonVoirPlus
                // 
                buttonVoirPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
                buttonVoirPlus.Cursor = System.Windows.Forms.Cursors.Hand;
                buttonVoirPlus.FlatAppearance.BorderSize = 0;
                buttonVoirPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                buttonVoirPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttonVoirPlus.ForeColor = System.Drawing.Color.White;
                buttonVoirPlus.Location = new System.Drawing.Point(39, PointDeDepart + 150 + 10);
                buttonVoirPlus.Name = IdVehicule.ToString();
                buttonVoirPlus.Size = new System.Drawing.Size(168, 25);
                buttonVoirPlus.TabIndex = 23;
                buttonVoirPlus.Text = "Voir plus >";
                buttonVoirPlus.UseVisualStyleBackColor = false;
                buttonVoirPlus.Click += buttonVoirPlusClick;

                PointDeDepart += 177;
            }


            this.panelSideChoice.Controls.Add(buttonVoirPlus);
            this.panelSideChoice.Controls.Add(panelLigneSeparatrice);
            this.panelSideChoice.Controls.Add(textBox1);
            this.panelSideChoice.Controls.Add(pictureBox1);
        }


        private void buttonVoirPlusClick(object sender, EventArgs e)
        {
            if (IndiceDeCreation >= 0)
            {

                fichePackOptions1.Enabled = true;
                ficheOptions1.Enabled = true;
                formulaire_Client1.Enabled = true;
                numericUpDownTVA.Enabled = true;
                listeDeroulanteClientVehicule1.Enabled = true;
                buttonAcheter.Enabled = true;


                // Me permet de récupérer l'id indiqué lors de la création des composants par la propriété IdVehicule
                m_Id = (sender as Button).Name;

                buttonAcheter.Enabled = true;

                #region Requêtes pour les options
                ///////////////////////////////
                // Requêtes pour les options //
                ///////////////////////////////
                ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                    new PDSGBD.MyDB.CodeSql(@"JOIN choix_option_vehicule ON option_vehicule.id_option_vehicule = choix_option_vehicule.fk_id_option_vehicule
                                                                                                             JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                    new PDSGBD.MyDB.CodeSql("WHERE choix_option_vehicule.fk_id_vehicule_vente = {0}", m_Id.ToString()),
                                                                                    null);
                ficheOptions1.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet la simplification de la requête si l'utilisateur revient sur un filtre vide
                    if (ficheOptions1.TexteFiltreOptions != "")
                    {
                        ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql(@"JOIN choix_option_vehicule ON option_vehicule.id_option_vehicule = choix_option_vehicule.fk_id_option_vehicule
                                                                                                  JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE choix_option_vehicule.fk_id_vehicule_vente = {0} AND nom_option LIKE {1}", m_Id.ToString(), string.Format(c_FiltreAvecLike, ficheOptions1.TexteFiltreOptions)),
                                                                        null);
                    }
                    else
                    {
                        ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                new PDSGBD.MyDB.CodeSql(@"JOIN choix_option_vehicule ON option_vehicule.id_option_vehicule = choix_option_vehicule.fk_id_option_vehicule
                                                                                                          JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                new PDSGBD.MyDB.CodeSql("WHERE choix_option_vehicule.fk_id_vehicule_vente = {0}", m_Id.ToString()),
                                                                                null);
                    }
                };

                #endregion

                #region Requêtes pour les packs d'options
                ////////////////////////////////////////
                // Requêtes pour les packs d'options //
                ///////////////////////////////////////

                fichePackOptions1.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN choix_pack_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = choix_pack_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE choix_pack_vehicule.fk_id_vehicule_vente = {0}", m_Id.ToString()), null);
                fichePackOptions1.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet la simplification de la requête si l'utilisateur revient sur un filtre vide
                    if (fichePackOptions1.TexteFiltrePackOptions != "")
                    {
                        fichePackOptions1.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule_vente = {0} AND nom_pack LIKE {1}", m_Id.ToString(), string.Format(c_FiltreAvecLike, fichePackOptions1.TexteFiltrePackOptions)),
                                                                        null);
                    }
                    else
                    {
                        fichePackOptions1.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule_vente = {0}", m_Id.ToString()), null);
                    }
                };
                #endregion

                foreach (VehiculeVente VV in ListeVehiculeDispo)
                {
                    if (VV.Id == int.Parse(m_Id))
                    {
                        textBoxPrix.Text = string.Format("{0} €", VV.Vehicule.PrixVehicule.ToString());
                        textBoxPrixTotal.Text = string.Format("{0} €", VV.PrixTotal.ToString());
                    }
                }
            }
        }

        private void ActualiserApresAchat()
        {
            fichePackOptions1.Enabled = false;
            ficheOptions1.Enabled = false;
            formulaire_Client1.Enabled = false;
            numericUpDownTVA.Enabled = false;
            listeDeroulanteClientVehicule1.Enabled = false;
            buttonAcheter.Enabled = false;
            fichePackOptions1.PackOptionsSelectionnee = null;
            ficheOptions1.OptionsSelectionnee = null;
            formulaire_Client1.ClientEnCoursDeTraitement = null;
            formulaire_Client1.ViderFormulaire();
            numericUpDownTVA.Value = 1;
            listeDeroulanteClientVehicule1.ClientVehiculeSelectionne = null;
            textBoxRemise.Text = "";
            textBoxPrix.Text = "";
            textBoxPrixTotal.Text = "";

        }

        private void ActualiserListeVehiculeDispo()
        {
            panelSideChoice.Controls.Clear();
            ListeVehiculeDispo = Program.GMBD.EnumererVehiculeVente(null, new PDSGBD.MyDB.CodeSql("JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule"), new PDSGBD.MyDB.CodeSql("WHERE vehicule_vente.id_vehicule_vente NOT IN ( SELECT facture_vente.fk_id_vehicule_vente from facture_vente) AND statut.statut = \"En stock\" AND fk_id_vehicule = {0}", IdVehiculeType), null).ToList();

            int Indice = 0;
            foreach (VehiculeVente Vehicule in ListeVehiculeDispo)
            {
                IndiceDeCreation = Indice;
                IdVehicule = Vehicule.Id;
                CreationDesComposants();
                Indice++;
            }
        }

        private void formulaire_Client1_Load(object sender, EventArgs e)
        {

            ActualiserListeVehiculeDispo();
            formulaire_Client1.ChargerDonneesListView();
            formulaire_Client1.AccesALaListeClient.SurChangementSelectionDeuxiemeMethode += SurChangementListeClientVehicule;


        }

        private void SurChangementListeClientVehicule(object sender,EventArgs e)
        {
            listeDeroulanteClientVehicule1.ClientVehicule = formulaire_Client1.ClientEnCoursDeTraitement.EnumererVehiculeActifDuClient();
        }

        private void buttonAcheter_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            VehiculeVente VehiculeExiste = Program.GMBD.EnumererVehiculeVente(null, new PDSGBD.MyDB.CodeSql("JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule"), new PDSGBD.MyDB.CodeSql("WHERE id_vehicule_vente = {0}", m_Id), null).FirstOrDefault();
            if (VehiculeExiste != null)
            {
                if (formulaire_Client1.ClientEnCoursDeTraitement != null)
                {
                    // Si un véhicule a été repris, une indication de prix sur la reprise du véhicule doit être indiquée et le véhicule ne sera plus actif pour ce client.
                    if (listeDeroulanteClientVehicule1.ClientVehiculeSelectionne != null)
                    {
                        int DernierId = -1;
                        IEnumerable<FactureVente> ListeDesFactures = Program.GMBD.EnumererFactureVente(null, null, null, null);
                        if (ListeDesFactures.Count() == 0) DernierId = 1;
                        else DernierId = ListeDesFactures.Last().Id;

                        // On enregistrement le nouveau véhicule du client
                        ClientVehicule VehiculeAcheterParLeClient = new ClientVehicule();
                        VehiculeAcheterParLeClient.NumeroChassis = ListeVehiculeDispo.First(item => item.Id == int.Parse(m_Id)).NumeroChassis;
                        VehiculeAcheterParLeClient.VehiculeActif = 1;
                        VehiculeAcheterParLeClient.Immatriculation = "";
                        VehiculeAcheterParLeClient.Vehicule = ListeVehiculeDispo.First(item => item.Id == int.Parse(m_Id)).Vehicule;
                        VehiculeAcheterParLeClient.Client = formulaire_Client1.AccesALaListeClient.Client.FirstOrDefault();                        
                        if ((VehiculeAcheterParLeClient.EstValide) && (Program.GMBD.AjouterClientVehicule(VehiculeAcheterParLeClient)))
                        {
                            // On enregistre la facture
                            FactureVente NouvelleFactureDeVente = new FactureVente();
                            NouvelleFactureDeVente.Client = formulaire_Client1.ClientEnCoursDeTraitement;
                            NouvelleFactureDeVente.Employe = Form_Principal.Employe;
                            NouvelleFactureDeVente.VehiculeVente = ListeVehiculeDispo.First(item => item.Id == int.Parse(m_Id));
                            NouvelleFactureDeVente.PourcentageTva = int.Parse(numericUpDownTVA.Value.ToString());                            
                            double remise = 0;
                            if(double.TryParse(textBoxRemise.Text,out remise))
                            {
                                NouvelleFactureDeVente.RemiseSurReprise = remise;
                            }
                            else
                            {
                                NouvelleFactureDeVente.RemiseSurReprise = 0;
                            }
                            NouvelleFactureDeVente.DateVente = DateTime.Now;
                            NouvelleFactureDeVente.NumeroFacture = string.Format("{0}-{1}", DateTime.Now.Year, DernierId + 1);
                            if ((NouvelleFactureDeVente.EstValide) && (Program.GMBD.AjouterNouvelleFactureVente(NouvelleFactureDeVente)))
                            {

                                if (listeDeroulanteClientVehicule1.ClientVehiculeSelectionne != null)
                                {
                                    
                                    ClientVehicule VehiculeADesactiver = listeDeroulanteClientVehicule1.ClientVehiculeSelectionne;
                                    VehiculeADesactiver.VehiculeActif = 0;
                                    if((VehiculeADesactiver.EstValide)&& (Program.GMBD.ModifierClientVehicule(VehiculeADesactiver)))
                                    {
                                        VehiculeExiste.StatutLivraison = Program.GMBD.EnumererStatut(null, null, new PDSGBD.MyDB.CodeSql("WHERE statut = \"Vendu\""), null).FirstOrDefault();
                                        if ((VehiculeExiste.EstValide) && (Program.GMBD.ModifierVehiculeVente(VehiculeExiste)))
                                        {
                                            GenerationFacturePDF NouvelleFacturePDF = new GenerationFacturePDF();
                                            NouvelleFacturePDF.GenerationFactureVente(NouvelleFactureDeVente);
                                            ValidationProvider.SetError(buttonAcheter, "Achat correctement effectué");
                                        }
                                    }

                                    ActualiserApresAchat();
                                    ActualiserListeVehiculeDispo();
                                }
                            }
                            else
                            {
                                Program.GMBD.SupprimerClientVehicule(VehiculeAcheterParLeClient);
                            }

                        }


                    }
                    // Sinon l'acheteur ne revend pas de véhicule à la concession donc un traitement simple sera effectué
                    else
                    {
                        int DernierId = -1;
                        IEnumerable<FactureVente> ListeDesFactures = Program.GMBD.EnumererFactureVente(null, null, null, null);
                        if (ListeDesFactures.Count() == 0) DernierId = 1;
                        else DernierId = ListeDesFactures.Last().Id;

                        
                        ClientVehicule VehiculeAcheterParLeClient = new ClientVehicule();
                        VehiculeAcheterParLeClient.NumeroChassis = ListeVehiculeDispo.First(item => item.Id == int.Parse(m_Id)).NumeroChassis;
                        VehiculeAcheterParLeClient.VehiculeActif = 1;
                        VehiculeAcheterParLeClient.Immatriculation = "";
                        VehiculeAcheterParLeClient.Vehicule = ListeVehiculeDispo.First(item => item.Id == int.Parse(m_Id)).Vehicule;
                        VehiculeAcheterParLeClient.Client = formulaire_Client1.AccesALaListeClient.Client.FirstOrDefault();
                        if ((VehiculeAcheterParLeClient.EstValide) && (Program.GMBD.AjouterClientVehicule(VehiculeAcheterParLeClient)))
                        {
                            FactureVente NouvelleFactureDeVente = new FactureVente();
                            NouvelleFactureDeVente.Client = formulaire_Client1.ClientEnCoursDeTraitement;
                            NouvelleFactureDeVente.Employe = Form_Principal.Employe;
                            NouvelleFactureDeVente.VehiculeVente = ListeVehiculeDispo.First(item => item.Id == int.Parse(m_Id));
                            NouvelleFactureDeVente.PourcentageTva = int.Parse(numericUpDownTVA.Value.ToString());
                            NouvelleFactureDeVente.RemiseSurReprise = 0;
                            NouvelleFactureDeVente.DateVente = DateTime.Now;
                            NouvelleFactureDeVente.NumeroFacture = string.Format("{0}-{1}",DateTime.Now.Year, DernierId + 1);
                            
                            if ((NouvelleFactureDeVente.EstValide)&&(Program.GMBD.AjouterNouvelleFactureVente(NouvelleFactureDeVente)))
                            {
                                VehiculeExiste.StatutLivraison = Program.GMBD.EnumererStatut(null, null, new PDSGBD.MyDB.CodeSql("WHERE statut = \"Vendu\""), null).FirstOrDefault();
                                if ((VehiculeExiste.EstValide) && (Program.GMBD.ModifierVehiculeVente(VehiculeExiste)))
                                {
                                    ActualiserApresAchat();
                                    ActualiserListeVehiculeDispo();
                                    GenerationFacturePDF NouvelleFacturePDF = new GenerationFacturePDF();
                                    NouvelleFacturePDF.GenerationFactureVente(NouvelleFactureDeVente);
                                }
                            }
                            else
                            {
                                Program.GMBD.SupprimerClientVehicule(VehiculeAcheterParLeClient);
                            }                                   
                        }
                    }                    
                }
                else
                {
                    errorProvider.SetError(buttonAcheter, "Veuillez choisir un client");
                }
            }
            else
            {
                errorProvider.SetError(buttonAcheter, "Ce véhicule n'existe plus, veuillez en choisir un autre");
            }
        }
        
    }
}
