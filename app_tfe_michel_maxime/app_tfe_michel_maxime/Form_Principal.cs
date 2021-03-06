﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tfe_michel_maxime
{
    public partial class Form_Principal : Form
    {

        private static Form_Principal s_Instance = null;

        /// <summary>
        /// Singleton
        /// </summary>
        public static Form_Principal Instance
        {
            get
            {
                return s_Instance;
            }
        }

        /// <summary>
        /// Membre privé de type UserControl représentant la page
        /// </summary>
        private UserControl m_Page;

        /// <summary>
        /// Page courante dans le formulaire principal
        /// </summary>
        public UserControl PageCourante
        {
            get
            {
                return m_Page;
            }
            set
            {
                if ((value != null) && !object.ReferenceEquals(value, m_Page))
                {
                    if (m_Page != null)
                    {
                        this.Controls.Remove(m_Page);
                        m_Page.Dispose();
                    }
                    m_Page = value;
                    this.Controls.Add(m_Page);
                    ButtonClose.TailleOriginal = new Size(m_Page.Width, m_Page.Height);
                    if (value is Page_Connexion)
                    {
                        this.Size = new Size(1200, 400);
                    }
                    else
                    {
                        if (ButtonClose.EstPleinEcran == false)
                        {
                            this.Size = new Size(m_Page.Width, m_Page.Height);
                        }
                        else
                        {
                            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 40);
                            ButtonClose.EstPleinEcran = true;
                        }
                    }
                    m_Page.Dock = DockStyle.Fill;
                }
            }
        }

        /// <summary>
        /// Créer une nouvelle page courante
        /// </summary>
        /// <typeparam name="T">Type correspondant à une page dont le type dispose d'un usercontrol comme héritage</typeparam>
        /// <param name="MethodeInitialisation">Fonction permettant d'initialiser les valeurs de base</param>
        /// <returns> retourne vrai une fois les tests validé et que la page courante a été remplacer par la page principale</returns>
        public bool CreerPageCourante<T>(Func<T, bool> MethodeInitialisation = null)
            where T : UserControl, new()
        {
            T NouvellePage = new T();
            if (MethodeInitialisation != null)
            {
                if (!MethodeInitialisation(NouvellePage)) return false;
            }
            this.PageCourante = NouvellePage;
            return true;
        }


        private static Employe m_Employe = null;
        /// <summary>
        /// Permet de garder une trace de l'utilisateur actif sur l'application
        /// </summary>
        public static Employe Employe
        {
            get
            {
                return m_Employe;
            }
            set
            {
                if ((m_Employe == null) || (m_Employe != value))
                {
                    m_Employe = value;
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Form_Principal()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            InitializeComponent();

            if (s_Instance != null)
            {
                throw new Exception("Erreur de singleton non respecté !");
            }
            s_Instance = this;
            this.FormClosed += (s, e) =>
            {
                s_Instance = null;
            };
            AutoScaleMode = AutoScaleMode.Font;
            Employe PremiereConnexion = Program.GMBD.EnumererEmploye(null, null, null, null).FirstOrDefault();
            if(PremiereConnexion == null)
            {
                CreerPageCourante<Page_PremiereConnexion>();
            }
            else
            {
                CreerPageCourante<Page_Connexion>();
            }
        }
        

    }
}
