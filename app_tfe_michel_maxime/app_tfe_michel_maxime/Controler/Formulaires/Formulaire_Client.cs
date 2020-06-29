using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tfe_michel_maxime
{
    public partial class Formulaire_Client : UserControl
    {

        private Client m_ClientEnCoursDeTraitement;        

        /// <summary>
        /// Me permet d'avoir accès à l'utilisateur qui vient d'être rajouter ou a été sélectionné
        /// </summary>
        public Client ClientEnCoursDeTraitement
        {
            get
            {
                return m_ClientEnCoursDeTraitement;
            }
            set
            {
                if ((value != null) && (value is Client))
                {
                    m_ClientEnCoursDeTraitement = value;
                }
            }
        }


        public IEnumerable<ClientVehicule> ListeVehiculeDispo
        {
            get
            {
                return EnumererVehiculeDuClient();
            }
        }

        public ListeDeroulanteClient AccesALaListeClient
        {
            get
            {
                return listeDeroulanteClient;
            }
        }


        public Formulaire_Client()
        {
            InitializeComponent();
            listeDeroulanteClient.SurChangementSelection += ListeDeroulante_ChangementClient;
            buttonModifier.Enabled = false;
            dateTimePickerDateNaissance.Value = DateTime.Now;

            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
            
        }               


        private void RefreshListeClient()
        {
            listeDeroulanteClient.Client = Program.GMBD.EnumererClient(null, new PDSGBD.MyDB.CodeSql(@"JOIN civilite ON client.fk_id_civilite = civilite.id_civilite
                                                                                                      JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                      "), null, new PDSGBD.MyDB.CodeSql("ORDER BY id_client, nom_client"));

        }
        
        public void ListeDeroulante_ChangementClient(object sender, EventArgs e)
        {
            errorProviderClient.Clear();
            ValidationProvider.Clear();
            if(listeDeroulanteClient.ClientSelectionne != null)
            {
                buttonAjouter.Enabled = false;
                buttonAnnuler.Enabled = true;
                buttonModifier.Enabled = true;
                textBoxNom.Text = listeDeroulanteClient.ClientSelectionne.Nom;
                textBoxPrenom.Text = listeDeroulanteClient.ClientSelectionne.Prenom;
                listeDeroulanteCivilite.CiviliteSelectionne = listeDeroulanteClient.ClientSelectionne.Civilite;
                listeDeroulanteLocaliteCP.AdresseSelectionne = listeDeroulanteClient.ClientSelectionne.Adresse;               
                textBoxAdresse.Text = listeDeroulanteClient.ClientSelectionne.Rue;
                textBoxNumTel.Text = listeDeroulanteClient.ClientSelectionne.NumeroTelephone.ToString();
                textBoxEmail.Text = listeDeroulanteClient.ClientSelectionne.Email;
                textBoxNumHabitation.Text = listeDeroulanteClient.ClientSelectionne.NumeroHabitation;
                dateTimePickerDateNaissance.Value = listeDeroulanteClient.ClientSelectionne.DateNaissance;
                ClientEnCoursDeTraitement = listeDeroulanteClient.ClientSelectionne;
             }
        }

        public void ChargerDonneesListView()
        {
            listeDeroulanteLocaliteCP.Adresse = Program.GMBD.EnumererAdresse(null, null, null, null);
            listeDeroulanteClient.Client = Program.GMBD.EnumererClient(null, new PDSGBD.MyDB.CodeSql(@"JOIN civilite ON client.fk_id_civilite = civilite.id_civilite
                                                                                                      JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                      "), null, new PDSGBD.MyDB.CodeSql("ORDER BY id_client,nom_client"));
            listeDeroulanteCivilite.Civilite = Program.GMBD.EnumererCivilite(null, null, null, null);
        }
        

        public void ViderFormulaire()
        {
            listeDeroulanteClient.ClientSelectionne = null;
            textBoxNom.Text = "";
            textBoxPrenom.Text = "";
            listeDeroulanteCivilite.CiviliteSelectionne = null;
            listeDeroulanteLocaliteCP.AdresseSelectionne = null;
            textBoxAdresse.Text = "";
            textBoxNumHabitation.Text = "";
            textBoxNumTel.Text = "";
            textBoxEmail.Text = "";
            dateTimePickerDateNaissance.Value = new DateTime(2000, 1, 1);
            buttonModifier.Enabled = false;
            buttonAnnuler.Enabled = false;
            buttonAjouter.Enabled = true;
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            ViderFormulaire();
            buttonModifier.Enabled = false;
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if(listeDeroulanteClient.ClientSelectionne == null)
            {
                Client NouveauClient = new Client();
                NouveauClient.SurErreur += ClientEnEdition_SurErreur;
                NouveauClient.AvantChangement += ClientEnAjout_AvantChangement;
                NouveauClient.Nom = textBoxNom.Text;
                NouveauClient.Prenom = textBoxPrenom.Text;
                NouveauClient.Email = textBoxEmail.Text;
                NouveauClient.Civilite = listeDeroulanteCivilite.CiviliteSelectionne;
                NouveauClient.Adresse = listeDeroulanteLocaliteCP.AdresseSelectionne;
                NouveauClient.DateNaissance = dateTimePickerDateNaissance.Value;
                NouveauClient.Rue = textBoxAdresse.Text;
                NouveauClient.NumeroTelephone = textBoxNumTel.Text;
                NouveauClient.NumeroHabitation = textBoxNumHabitation.Text;

                if((NouveauClient.EstValide) &&(Program.GMBD.AjouterClient(NouveauClient)))
                {
                    errorProviderClient.Clear();
                    RefreshListeClient();
                    listeDeroulanteClient.ClientSelectionne = NouveauClient;
                    ValidationProvider.SetError(listeDeroulanteClient, "Client correctement enregistré");
                }
            }                     
        }

        /// <summary>
        /// Methode permettant de vérifier si le client existe avant le changement de celle ci dans la base de données
        /// </summary>
        /// <param name="Entite"></param>
        /// <param name="Champ"></param>
        /// <param name="ValeurActuelle"></param>
        /// <param name="NouvelleValeur"></param>
        /// <param name="AccumulateurErreur"></param>
        private void ClientEnAjout_AvantChangement(Client Entite, Client.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case Client.Champs.NumeroTelephone:
                    long NumTel = 0;
                    if (!long.TryParse(textBoxNumTel.Text, out NumTel))
                    {
                        AccumulateurErreur.NotifierErreur("Le numéro de téléphone doit être de type numérique ! ");
                    }
                    break;
                case Client.Champs.Email:
                    {
                        Client ClientExiste = Program.GMBD.EnumererClient(null, null, new PDSGBD.MyDB.CodeSql("WHERE client.email_client = {0}", NouvelleValeur), null).FirstOrDefault();
                        if (ClientExiste != null)
                        {
                            ValidationProvider.Clear();
                            AccumulateurErreur.NotifierErreur("Un autre client a déjà cet email !");
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Methode permettant de réagir sur l'erreur d'une edition d'un client
        /// </summary>
        /// <param name="Entite"></param>
        /// <param name="Champ"></param>
        /// <param name="MessageErreur"></param>
        private void ClientEnEdition_SurErreur(Client Entite, Client.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case Client.Champs.Nom:
                    errorProviderClient.SetError(textBoxNom, MessageErreur);
                    break;
                case Client.Champs.Prenom:
                    errorProviderClient.SetError(textBoxPrenom, MessageErreur);
                    break;
                case Client.Champs.NumeroTelephone:
                    errorProviderClient.SetError(textBoxNumTel, MessageErreur);
                    break;
                case Client.Champs.Email:
                    errorProviderClient.SetError(textBoxEmail, MessageErreur);
                    break;
                case Client.Champs.Civilite:
                    errorProviderClient.SetError(listeDeroulanteCivilite, MessageErreur);
                    break;
                case Client.Champs.DateNaissance:
                    errorProviderClient.SetError(dateTimePickerDateNaissance, MessageErreur);
                    break;
                case Client.Champs.NumeroHabitation:
                    errorProviderClient.SetError(textBoxNumHabitation, MessageErreur);
                    break;
                case Client.Champs.Rue:
                    errorProviderClient.SetError(textBoxAdresse, MessageErreur);
                    break;
                case Client.Champs.Adresse:
                    if (listeDeroulanteLocaliteCP.AdresseSelectionne == null) errorProviderClient.SetError(listeDeroulanteLocaliteCP, MessageErreur);
                    break;
            }
        }
        

        /// <summary>
        /// Methode permettant de vérifier si le client existe avant le changement de celle ci dans la base de données
        /// </summary>
        /// <param name="Entite"></param>
        /// <param name="Champ"></param>
        /// <param name="ValeurActuelle"></param>
        /// <param name="NouvelleValeur"></param>
        /// <param name="AccumulateurErreur"></param>
        private void ClientEnEdition_AvantChangement(Client Entite, Client.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case Client.Champs.NumeroTelephone:
                    long NumTel = 0;
                    if(!long.TryParse(textBoxNumTel.Text,out NumTel))                    
                    {
                        AccumulateurErreur.NotifierErreur("Le numéro de téléphone doit être de type numérique ! ");
                    }
                    break;
                case Client.Champs.Email:
                    {
                        Client ClientExiste = Program.GMBD.EnumererClient(null, null, new PDSGBD.MyDB.CodeSql("WHERE client.email_client = {0} AND id_client != {1}", NouvelleValeur, Entite.Id), null).FirstOrDefault();
                        if (ClientExiste != null)
                        {
                            ValidationProvider.Clear();
                            AccumulateurErreur.NotifierErreur("Un autre client a déjà cet email !");                            
                        }
                        break;
                    }             
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (listeDeroulanteClient.ClientSelectionne != null)
            {
                Client ClientEnEdition = null;
                ClientEnEdition = listeDeroulanteClient.ClientSelectionne;
                ClientEnEdition.SurErreur += ClientEnEdition_SurErreur;
                ClientEnEdition.AvantChangement += ClientEnEdition_AvantChangement;
                ClientEnEdition.Nom = textBoxNom.Text;
                ClientEnEdition.Prenom = textBoxPrenom.Text;
                ClientEnEdition.Email = textBoxEmail.Text;
                ClientEnEdition.Civilite = listeDeroulanteCivilite.CiviliteSelectionne;
                ClientEnEdition.Adresse = listeDeroulanteLocaliteCP.AdresseSelectionne;
                ClientEnEdition.DateNaissance = dateTimePickerDateNaissance.Value;
                ClientEnEdition.Rue = textBoxAdresse.Text;
                ClientEnEdition.NumeroTelephone = textBoxNumTel.Text;
                ClientEnEdition.NumeroHabitation = textBoxNumHabitation.Text;

                if ((ClientEnEdition.EstValide) && (Program.GMBD.ModifierClient(ClientEnEdition)))
                {
                    RefreshListeClient();
                    listeDeroulanteClient.ClientSelectionne = ClientEnEdition;
                    ValidationProvider.SetError(listeDeroulanteClient, "Vos modifications se sont correctement modifiée");
                }
            }
            else
            {
                ValidationProvider.Clear();
                errorProviderClient.SetError(listeDeroulanteClient, "Veuillez choisir un client existant");
            }
        }

        private void buttonAnnuler_Click_1(object sender, EventArgs e)
        {
            ViderFormulaire();
        }        

        private IEnumerable<ClientVehicule> EnumererVehiculeDuClient()
        {
            return listeDeroulanteClient.ClientSelectionne.EnumererVehiculeActifDuClient();
        }        
    }
}
