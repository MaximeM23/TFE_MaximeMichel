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
    public partial class Formulaire_ClientVehicule : UserControl
    {
        

        private ClientVehicule m_ClientSelectionneCalendrier;
        private ClientVehicule m_ClientAjouter;

        
        /// <summary>
        /// Accesseur/Modificateur me permettant l'accès au client et au véhicule choisi dans le calendrier
        /// </summary>
        public ClientVehicule ClientSelectionneCalendrier
        {
            get
            {
                return m_ClientSelectionneCalendrier;
            }
            set
            {
                if((value != null)&&(value is ClientVehicule))
                {
                    m_ClientSelectionneCalendrier = value;
                }
                else
                {
                    m_ClientSelectionneCalendrier = null;
                }
            }
        }
       
        /// <summary>
        /// Permet la désactivation ou l'activation du boutton depuis un formulaire parent
        /// </summary>
        public bool ButtonAjouter
        {
            set
            {
                buttonAjouter.Enabled = value;
            }
        }

        /// <summary>
        /// Permet la désactivation ou l'activation du boutton depuis un formulaire parent
        /// </summary>
        public bool ButtonModifier
        {
            set
            {
                buttonModifier.Enabled = value;
            }
        }

        public bool DesactiverListeClient
        {
            set
            {
                listeDeroulanteClient.Enabled = value;
            }
        }

        /// <summary>
        /// Me permet d'avoir accès à l'utilisateur qui vient d'être rajouter ou qui ne dispose pas encore de rendez-vous de planifié
        /// </summary>
        public ClientVehicule ClientVehiculeEnCoursDeTraitement
        {
            get
            {
                return m_ClientAjouter;
            }
            set
            {
                if ((value != null) && (value is ClientVehicule))
                {
                    m_ClientAjouter = value;
                }
                else
                {
                    m_ClientAjouter = null;
                }
            }
        }

        public bool DesactiverTextBoxImmatriculation
        {
            set
            {
                textBoxImmatriculation.Enabled = value;
            }
        }

        public bool DesactiverListeModele
        {
            set
            {
                listeDeroulanteModele.Enabled = value;
            }
        }

        public bool DesactiverTextBoxNumChassis
        {
            set
            {
                textBoxNumeroChassis.Enabled = value;
            }
        }
        
        
        public Formulaire_ClientVehicule()
        {
            InitializeComponent();
            listeDeroulanteClient.SurChangementSelection += ListeDeroulante_ChangementClient;
            listeDeroulanteClientVehicule.SurChangementSelection += ListeDeroulante_ChangementVehicule;
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
        private void RefreshListeClientVehicule()
        {
            if (listeDeroulanteClient.ClientSelectionne != null)
            {
                listeDeroulanteClientVehicule.ClientVehicule = Program.GMBD.EnumererClientVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                                                  JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"),
                                                                                                            new PDSGBD.MyDB.CodeSql("WHERE client.id_client = {0} AND vehicule_actif = 1", listeDeroulanteClient.ClientSelectionne.Id), null);

            }
            else if ((ClientSelectionneCalendrier != null) && (ClientSelectionneCalendrier.Client != null))
            {
                listeDeroulanteClientVehicule.ClientVehicule = Program.GMBD.EnumererClientVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                                                  JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"),
                                                                                                            new PDSGBD.MyDB.CodeSql("WHERE client.id_client = {0} AND vehicule_actif = 1", ClientSelectionneCalendrier.Client.Id), null);

            }
        }

        public EventHandler ActivationButtonSurChangementSelection;

        public EventHandler RafraichirApresModification;


        public void ListeDeroulante_ChangementClient(object sender, EventArgs e)
        {
            errorProviderClient.Clear();
            ValidationProvider.Clear();
            buttonModifier.Enabled = true;
            if((listeDeroulanteClient.ClientSelectionne != null)&&(ClientSelectionneCalendrier == null))
            {

                listeDeroulanteClientVehicule.ClientVehicule = null;
                listeDeroulanteModele.Vehicule = null;
                textBoxImmatriculation.Text = "";
                textBoxNumeroChassis.Text = "";

                listeDeroulanteClientVehicule.ClientVehicule = Program.GMBD.EnumererClientVehicule(null,new PDSGBD.MyDB.CodeSql(@"JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                                                  JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"), 
                                                                                                        new PDSGBD.MyDB.CodeSql("WHERE client.id_client = {0}  AND vehicule_actif = 1", listeDeroulanteClient.ClientSelectionne.Id), null);
                textBoxNom.Text = listeDeroulanteClient.ClientSelectionne.Nom;
                textBoxPrenom.Text = listeDeroulanteClient.ClientSelectionne.Prenom;
                listeDeroulanteCivilite.CiviliteSelectionne = listeDeroulanteClient.ClientSelectionne.Civilite;
                listeDeroulanteLocaliteCP.AdresseSelectionne = listeDeroulanteClient.ClientSelectionne.Adresse;           
                textBoxAdresse.Text = listeDeroulanteClient.ClientSelectionne.Rue;
                textBoxNumHabitation.Text = listeDeroulanteClient.ClientSelectionne.NumeroHabitation;
                textBoxNumTel.Text = listeDeroulanteClient.ClientSelectionne.NumeroTelephone.ToString();
                textBoxEmail.Text = listeDeroulanteClient.ClientSelectionne.Email;
                dateTimePickerDateNaissance.Value = listeDeroulanteClient.ClientSelectionne.DateNaissance;
                if (ActivationButtonSurChangementSelection != null)
                {
                    ActivationButtonSurChangementSelection(this, EventArgs.Empty);
                }
            }
            else if(ClientSelectionneCalendrier != null)
            {
                listeDeroulanteClient.ClientSelectionne = ClientSelectionneCalendrier.Client;
                listeDeroulanteClientVehicule.ClientVehicule = Program.GMBD.EnumererClientVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                                                  JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"),
                                                                                                        new PDSGBD.MyDB.CodeSql("WHERE client.id_client = {0}  AND vehicule_actif = 1", ClientSelectionneCalendrier.Client.Id), null);
                
                listeDeroulanteClientVehicule.ClientVehiculeSelectionne = ClientSelectionneCalendrier;
                textBoxNom.Text = ClientSelectionneCalendrier.Client.Nom;
                textBoxPrenom.Text = ClientSelectionneCalendrier.Client.Prenom;
                listeDeroulanteCivilite.CiviliteSelectionne = ClientSelectionneCalendrier.Client.Civilite;
                listeDeroulanteLocaliteCP.AdresseSelectionne = ClientSelectionneCalendrier.Client.Adresse;
                textBoxAdresse.Text = ClientSelectionneCalendrier.Client.Rue;
                textBoxNumHabitation.Text = ClientSelectionneCalendrier.Client.NumeroHabitation;
                textBoxNumTel.Text = ClientSelectionneCalendrier.Client.NumeroTelephone.ToString();
                textBoxEmail.Text = ClientSelectionneCalendrier.Client.Email;
                textBoxImmatriculation.Text = ClientSelectionneCalendrier.Immatriculation;
                textBoxNumeroChassis.Text = ClientSelectionneCalendrier.NumeroChassis;
                dateTimePickerDateNaissance.Value = ClientSelectionneCalendrier.Client.DateNaissance;
                listeDeroulanteModele.VehiculeSelectionne = ClientSelectionneCalendrier.Vehicule;
                if (ActivationButtonSurChangementSelection != null)
                {
                    ActivationButtonSurChangementSelection(this, EventArgs.Empty);
                }
            }
            else
            {
                //ViderFormulaire();
            }
        }

        public void ChargerDonneesListView()
        {
            listeDeroulanteLocaliteCP.Adresse = Program.GMBD.EnumererAdresse(null, null, null, null);
            listeDeroulanteClient.Client = Program.GMBD.EnumererClient(null, new PDSGBD.MyDB.CodeSql(@"JOIN civilite ON client.fk_id_civilite = civilite.id_civilite
                                                                                                      JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                      "), null, new PDSGBD.MyDB.CodeSql("ORDER BY id_client, nom_client"));
            listeDeroulanteCivilite.Civilite = Program.GMBD.EnumererCivilite(null, null, null, null);
            listeDeroulanteModele.Vehicule = Program.GMBD.EnumererVehicule(null, null, null, null);
        }

        private void ListeDeroulante_ChangementVehicule(object sender,EventArgs e)
        {
            if(listeDeroulanteClientVehicule.ClientVehiculeSelectionne != null)
            {
                if (ActivationButtonSurChangementSelection != null)
                {
                    ActivationButtonSurChangementSelection(this, EventArgs.Empty);
                }
                ClientVehiculeEnCoursDeTraitement = listeDeroulanteClientVehicule.ClientVehiculeSelectionne;
                listeDeroulanteModele.VehiculeSelectionne = listeDeroulanteClientVehicule.ClientVehiculeSelectionne.Vehicule;
                textBoxImmatriculation.Text = listeDeroulanteClientVehicule.ClientVehiculeSelectionne.Immatriculation;
                textBoxNumeroChassis.Text = listeDeroulanteClientVehicule.ClientVehiculeSelectionne.NumeroChassis;
            }
        }

        public void ViderFormulaire()
        {
            ClientSelectionneCalendrier = null;
            listeDeroulanteClient.ClientSelectionne = null;
            ClientVehiculeEnCoursDeTraitement = null;
            textBoxNom.Text = "";
            textBoxPrenom.Text = "";
            listeDeroulanteCivilite.CiviliteSelectionne = null;
            listeDeroulanteLocaliteCP.AdresseSelectionne = null;
            textBoxAdresse.Text = "";
            textBoxNumHabitation.Text = "";
            textBoxNumTel.Text = "";
            textBoxEmail.Text = "";
            listeDeroulanteClientVehicule.ClientVehicule = null;
            textBoxImmatriculation.Text = "";
            textBoxNumeroChassis.Text = "";
            dateTimePickerDateNaissance.Value = new DateTime(2000, 1, 1);
            listeDeroulanteModele.Vehicule = null;
            errorProviderClient.Clear();
            ValidationProvider.Clear();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            ViderFormulaire();
            buttonModifier.Enabled = false;
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            errorProviderClient.Clear();
            ValidationProvider.Clear();
            if(listeDeroulanteClient.ClientSelectionne == null)
            {
                Client NouveauClient = new Client();
                NouveauClient.SurErreur += ClientEnEdition_SurErreur;
                NouveauClient.AvantChangement += ClientEnEdition_AvantChangement;
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
                    ClientVehicule NouveauClientVehicule = new ClientVehicule();
                    NouveauClientVehicule.SurErreur += ClientVehiculeEnEdition_SurErreur;
                    NouveauClientVehicule.AvantChangement += ClientVehiculeEnAjout_AvantChangement;
                    NouveauClientVehicule.NumeroChassis = textBoxNumeroChassis.Text;
                    NouveauClientVehicule.Immatriculation = textBoxImmatriculation.Text;
                    NouveauClientVehicule.Vehicule = listeDeroulanteModele.VehiculeSelectionne;
                    NouveauClientVehicule.Client = NouveauClient;
                    NouveauClientVehicule.VehiculeActif = 1;

                    if((NouveauClientVehicule.EstValide) &&(Program.GMBD.AjouterClientVehicule(NouveauClientVehicule)))
                    {
                        ClientVehiculeEnCoursDeTraitement = NouveauClientVehicule;
                        RefreshListeClient();
                        listeDeroulanteClient.ClientSelectionne = NouveauClient;
                        listeDeroulanteClientVehicule.ClientVehiculeSelectionne = NouveauClientVehicule;
                        if (ActivationButtonSurChangementSelection != null)
                        {
                            ActivationButtonSurChangementSelection(this, EventArgs.Empty);
                        }
                        ValidationProvider.SetError(buttonAjouter, "Client correctement enregistré");
                    }
                    else
                    {
                        Program.GMBD.SupprimerClient(NouveauClient);
                    }
                }
            }
            else if(listeDeroulanteClient.ClientSelectionne != null)
            {
                ClientVehicule NouveauClientVehicule = new ClientVehicule();
                NouveauClientVehicule.SurErreur += ClientVehiculeEnEdition_SurErreur;
                NouveauClientVehicule.AvantChangement += ClientVehiculeEnAjout_AvantChangement;
                NouveauClientVehicule.NumeroChassis = textBoxNumeroChassis.Text;
                NouveauClientVehicule.Immatriculation = textBoxImmatriculation.Text;
                NouveauClientVehicule.Vehicule = listeDeroulanteModele.VehiculeSelectionne;
                NouveauClientVehicule.Client = listeDeroulanteClient.ClientSelectionne;
                NouveauClientVehicule.VehiculeActif = 1;

                if ((NouveauClientVehicule.EstValide) && (Program.GMBD.AjouterClientVehicule(NouveauClientVehicule)))
                {
                    buttonAjouter.Enabled = true;
                    ValidationProvider.SetError(buttonAjouter, "Client correctement enregistré");
                    RefreshListeClientVehicule();
                    listeDeroulanteClientVehicule.ClientVehiculeSelectionne = NouveauClientVehicule;
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
        /// Methode permettant de réagir sur l'erreur d'une edition de la partie véhicule du client
        /// </summary>
        /// <param name="Entite"></param>
        /// <param name="Champ"></param>
        /// <param name="MessageErreur"></param>
        private void ClientVehiculeEnEdition_SurErreur(ClientVehicule Entite, ClientVehicule.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case ClientVehicule.Champs.Immatriculation:
                    errorProviderClient.SetError(textBoxImmatriculation, MessageErreur);
                    break;
                case ClientVehicule.Champs.NumeroChassis:
                    errorProviderClient.SetError(textBoxNumeroChassis, MessageErreur);
                    break;
                case ClientVehicule.Champs.Vehicule:
                    errorProviderClient.SetError(listeDeroulanteModele, MessageErreur);
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
                        Client ClientExiste = Program.GMBD.EnumererClient(null, null, new PDSGBD.MyDB.CodeSql("WHERE email_client = {0} AND id_client != {1}", NouvelleValeur, Entite.Id), null).FirstOrDefault();
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
        /// Methode permettant de vérifier si l'immatriculations et le numero de châssis existe déjà avant le changement de celle ci dans la base de données
        /// </summary>
        /// <param name="Entite"></param>
        /// <param name="Champ"></param>
        /// <param name="ValeurActuelle"></param>
        /// <param name="NouvelleValeur"></param>
        /// <param name="AccumulateurErreur"></param>
        private void ClientVehiculeEnEdition_AvantChangement(ClientVehicule Entite, ClientVehicule.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case ClientVehicule.Champs.Immatriculation:
                    ClientVehicule ImmatriculationExiste = Program.GMBD.EnumererClientVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE immatriculation = {0} AND fk_id_client != {1} AND vehicule_actif = 1", NouvelleValeur, Entite.Client.Id), null).FirstOrDefault();
                    if (NouvelleValeur.ToString().Length < 1)
                    {
                        AccumulateurErreur.NotifierErreur("Le numéro d'immatriculation doit comprendre au minimum un caractère");
                        break;
                    }
                    if (ImmatriculationExiste != null)
                    {
                        ValidationProvider.Clear();
                        AccumulateurErreur.NotifierErreur("Cette immatriculation existe déjà pour un autre véhicule!");
                    }
                    break;
                case ClientVehicule.Champs.NumeroChassis:
                    {
                        ClientVehicule NumeroChassisExiste = Program.GMBD.EnumererClientVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE numero_chassis = {0} AND fk_id_client != {1} AND vehicule_actif = 1", NouvelleValeur, Entite.Client.Id), null).FirstOrDefault();
                        if(NouvelleValeur.ToString().Length < 1)
                        {
                            AccumulateurErreur.NotifierErreur("Le numéro de châssis doit comprendre au minimum un caractère");
                            break;
                        }
                        if (NumeroChassisExiste != null)
                        {
                            ValidationProvider.Clear();
                            AccumulateurErreur.NotifierErreur("Ce numéro de châssis existe déjà pour un autre véhicule!");
                        }
                        break;
                    }
            }
        }
        /// <summary>
        /// Methode permettant de vérifier si l'immatriculations et le numero de châssis existe déjà avant le changement de celle ci dans la base de données
        /// </summary>
        /// <param name="Entite"></param>
        /// <param name="Champ"></param>
        /// <param name="ValeurActuelle"></param>
        /// <param name="NouvelleValeur"></param>
        /// <param name="AccumulateurErreur"></param>
        private void ClientVehiculeEnAjout_AvantChangement(ClientVehicule Entite, ClientVehicule.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case ClientVehicule.Champs.Immatriculation:
                    ClientVehicule ImmatriculationExiste = Program.GMBD.EnumererClientVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE immatriculation = {0} AND vehicule_actif = 1", NouvelleValeur), null).FirstOrDefault();
                    if (ImmatriculationExiste != null)
                    {
                        ValidationProvider.Clear();
                        AccumulateurErreur.NotifierErreur("Cette immatriculation existe déjà pour un autre véhicule!");
                    }
                    if(textBoxImmatriculation.Text.Length < 1)
                    {
                        ValidationProvider.Clear();
                        AccumulateurErreur.NotifierErreur("L'immatriculation doit être indiquée");
                    }
                    break;
                case ClientVehicule.Champs.NumeroChassis:
                    {
                        ClientVehicule NumeroChassisExiste = Program.GMBD.EnumererClientVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE numero_chassis = {0} AND vehicule_actif = 1", NouvelleValeur), null).FirstOrDefault();
                        if (NumeroChassisExiste != null)
                        {
                            ValidationProvider.Clear();
                            AccumulateurErreur.NotifierErreur("Ce numéro de châssis existe déjà pour un autre véhicule!");
                        }
                        break;
                    }
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            errorProviderClient.Clear();
            ValidationProvider.Clear();
            if (((listeDeroulanteClientVehicule.ClientVehiculeSelectionne != null) && (listeDeroulanteClientVehicule.ClientVehiculeSelectionne.Vehicule != null)) || (ClientSelectionneCalendrier != null))
            {
                ClientVehicule ClientVehiculeEnEdition;
                if (ClientSelectionneCalendrier != null) ClientVehiculeEnEdition = ClientSelectionneCalendrier;
                else ClientVehiculeEnEdition = listeDeroulanteClientVehicule.ClientVehiculeSelectionne;                
                if (listeDeroulanteClient.ClientSelectionne != null)
                {
                    ClientVehiculeEnEdition = listeDeroulanteClientVehicule.ClientVehiculeSelectionne;
                    ClientVehiculeEnEdition.Client = listeDeroulanteClient.ClientSelectionne;
                    ClientVehiculeEnEdition.Vehicule = listeDeroulanteClientVehicule.ClientVehiculeSelectionne.Vehicule;
                }
                else if (ClientSelectionneCalendrier != null)
                {
                    ClientVehiculeEnEdition = ClientSelectionneCalendrier;
                    ClientVehiculeEnEdition.Client = ClientSelectionneCalendrier.Client;
                    ClientVehiculeEnEdition.Vehicule = ClientSelectionneCalendrier.Vehicule;
                }
                else
                {
                    errorProviderClient.SetError(buttonModifier, "Un client doit être sélectionné avant de pouvoir être modifié");
                }
                ClientVehiculeEnEdition.Client.SurErreur += ClientEnEdition_SurErreur;
                ClientVehiculeEnEdition.Client.AvantChangement += ClientEnEdition_AvantChangement;
                ClientVehiculeEnEdition.AvantChangement += ClientVehiculeEnEdition_AvantChangement;
                ClientVehiculeEnEdition.SurErreur += ClientVehiculeEnEdition_SurErreur;
                ClientVehiculeEnEdition.Client.Nom = textBoxNom.Text;
                ClientVehiculeEnEdition.Client.Prenom = textBoxPrenom.Text;
                ClientVehiculeEnEdition.Client.Email = textBoxEmail.Text;
                ClientVehiculeEnEdition.Client.Civilite = listeDeroulanteCivilite.CiviliteSelectionne;
                ClientVehiculeEnEdition.Client.Adresse = listeDeroulanteLocaliteCP.AdresseSelectionne;
                ClientVehiculeEnEdition.Client.DateNaissance = dateTimePickerDateNaissance.Value;
                ClientVehiculeEnEdition.Client.Rue = textBoxAdresse.Text;
                ClientVehiculeEnEdition.Client.NumeroTelephone = textBoxNumTel.Text;
                ClientVehiculeEnEdition.Client.NumeroHabitation = textBoxNumHabitation.Text;
                ClientVehiculeEnEdition.Immatriculation = textBoxImmatriculation.Text;
                ClientVehiculeEnEdition.NumeroChassis = textBoxNumeroChassis.Text;


                if (((ClientVehiculeEnEdition.EstValide)&&(ClientVehiculeEnEdition.Client.EstValide) && (Program.GMBD.ModifierClientVehicule(ClientVehiculeEnEdition))&& Program.GMBD.ModifierClient(ClientVehiculeEnEdition.Client)))
                {
                    if (ActivationButtonSurChangementSelection != null)
                    {
                        ActivationButtonSurChangementSelection(this, EventArgs.Empty);
                    }
                    if (RafraichirApresModification != null)
                    {
                        RafraichirApresModification(this, EventArgs.Empty);
                    }
                    RefreshListeClientVehicule();
                    listeDeroulanteClient.ClientSelectionne = ClientVehiculeEnEdition.Client;
                    ClientVehiculeEnEdition.Immatriculation = ClientVehiculeEnEdition.Immatriculation;
                    ClientVehiculeEnEdition.NumeroChassis = ClientVehiculeEnEdition.NumeroChassis;
                    listeDeroulanteClientVehicule.ClientVehiculeSelectionne = ClientVehiculeEnEdition;
                    ValidationProvider.SetError(buttonModifier, "Vos modifications ont été correctement sauvegardées");
                }
            }
            else if (((listeDeroulanteClient.ClientSelectionne != null) || (ClientSelectionneCalendrier != null)) && ((listeDeroulanteClientVehicule.ClientVehiculeSelectionne == null) || (ClientSelectionneCalendrier.Vehicule == null)))
            {
                Client ClientEnEdition = null;
                if (listeDeroulanteClient.ClientSelectionne != null)
                {
                    ClientEnEdition = listeDeroulanteClient.ClientSelectionne;
                }
                else if (ClientSelectionneCalendrier != null)
                {
                    ClientEnEdition = ClientSelectionneCalendrier.Client;
                }
                else
                {
                    errorProviderClient.SetError(buttonModifier, "Un client doit être sélectionné avant de pouvoir être modifié");
                }

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

                if ((ClientEnEdition.EstValide) && (Program.GMBD.ModifierClient(ClientEnEdition)))
                {
                    RefreshListeClient();
                    listeDeroulanteClient.ClientSelectionne = ClientEnEdition;
                    ValidationProvider.SetError(buttonModifier, "Vos modifications se sont correctement modifiée");
                }
            }                      
        }

        
    }
}
