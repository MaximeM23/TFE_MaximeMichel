-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  lun. 07 oct. 2019 à 14:36
-- Version du serveur :  5.7.14
-- Version de PHP :  7.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `tfe_maxime_michel`
--

-- Création de l'utilisateur permettant la connexion avec l'application
CREATE USER 'u_admin_tfe_maxime_michel' IDENTIFIED BY 'BsAz0YQgdZCL8QgK';

GRANT USAGE ON `tfe_maxime_michel`.* TO 'u_admin_tfe_maxime_michel'@'%';

GRANT SELECT, INSERT, UPDATE, DELETE ON `tfe_maxime_michel`.* TO 'u_admin_tfe_maxime_michel'@'%';

-- --------------------------------------------------------

--
-- Structure de la table `adresse`
--

CREATE TABLE `adresse` (
  `id_adresse` int(11) NOT NULL,
  `code_postal` int(11) NOT NULL,
  `localite` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `adresse`
--

INSERT INTO `adresse` (`id_adresse`, `code_postal`, `localite`) VALUES
(1, 7100, 'La Louvière'),
(2, 7100, 'Saint-Vaast'),
(3, 7100, 'Trivières'),
(4, 7110, 'Boussoit'),
(5, 7110, 'Houdeng-Aimeries'),
(6, 7110, 'Houdeng-Goegnies (La Louvière)'),
(7, 7110, 'Maurage'),
(8, 7110, 'Strépy-Bracquegnies'),
(9, 7120, 'Croix-lez-Rouveroy'),
(10, 7120, 'Estinnes'),
(11, 7120, 'Estinnes-au-Mont'),
(12, 7120, 'Estinnes-au-Val'),
(13, 7120, 'Fauroeulx'),
(14, 7120, 'Haulchin'),
(15, 7120, 'Peissant'),
(16, 7190, 'Ecaussinnes'),
(17, 7190, 'Ecaussinnes-d\'Enghien'),
(18, 7190, 'Marche-lez-Ecaussinnes'),
(19, 7191, 'Ecaussinnes-Lalaing'),
(20, 7090, 'Braine-le-Comte');

-- --------------------------------------------------------

--
-- Structure de la table `article`
--

CREATE TABLE `article` (
  `id_article` int(11) NOT NULL,
  `nom_article` varchar(250) NOT NULL,
  `stock` int(11) NOT NULL,
  `prix_unite` double NOT NULL,
  `disponible` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `caracteristique`
--

CREATE TABLE `caracteristique` (
  `id_caracteristique` int(11) NOT NULL,
  `caracteristique` varchar(250) NOT NULL,
  `disponible` int(1) NOT NULL,
  `fk_id_type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `choix_option_vehicule`
--

CREATE TABLE `choix_option_vehicule` (
  `id_choix_option_vehicule` int(11) NOT NULL,
  `fk_id_vehicule_vente` int(11) NOT NULL,
  `fk_id_option_vehicule` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `choix_pack_vehicule`
--

CREATE TABLE `choix_pack_vehicule` (
  `id_choix_pack_vehicule` int(11) NOT NULL,
  `fk_id_vehicule_vente` int(11) NOT NULL,
  `fk_id_popv` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `civilite`
--

CREATE TABLE `civilite` (
  `id_civilite` int(11) NOT NULL,
  `civilite` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `civilite`
--

INSERT INTO `civilite` (`id_civilite`, `civilite`) VALUES
(2, 'Madame'),
(3, 'Mademoiselle'),
(1, 'Monsieur');

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

CREATE TABLE `client` (
  `id_client` int(11) NOT NULL,
  `nom_client` varchar(250) NOT NULL,
  `prenom_client` varchar(250) NOT NULL,
  `date_naissance_client` datetime NOT NULL,
  `email_client` varchar(250) NOT NULL,
  `numero_telephone_client` varchar(10) NOT NULL,
  `nom_de_rue_client` varchar(250) NOT NULL,
  `numero_habitation_client` varchar(20) NOT NULL,
  `fk_id_civilite` int(11) NOT NULL,
  `fk_id_adresse` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `client_vehicule`
--

CREATE TABLE `client_vehicule` (
  `id_client_vehicule` int(11) NOT NULL,
  `immatriculation` varchar(250) NOT NULL,
  `numero_chassis` varchar(250) NOT NULL,
  `vehicule_actif` int(1) NOT NULL,
  `fk_id_client` int(11) NOT NULL,
  `fk_id_vehicule` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `employe`
--

CREATE TABLE `employe` (
  `id_employe` int(11) NOT NULL,
  `mot_de_passe` varchar(500) NOT NULL,
  `nom` varchar(250) NOT NULL,
  `prenom` varchar(250) NOT NULL,
  `date_naissance` date NOT NULL,
  `email` varchar(250) NOT NULL,
  `numero_telephone` text NOT NULL,
  `compte_actif` int(1) NOT NULL,
  `nom_de_rue` varchar(250) NOT NULL,
  `numero_habitation` varchar(20) NOT NULL,
  `fk_id_civilite` int(11) NOT NULL,
  `fk_id_adresse` int(11) NOT NULL,
  `fk_id_statut_employe` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `entretien`
--

CREATE TABLE `entretien` (
  `id_entretien` int(11) NOT NULL,
  `type_entretien` varchar(250) NOT NULL,
  `prix` double NOT NULL,
  `disponible` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `facture`
--

CREATE TABLE `facture` (
  `id_facture` int(11) NOT NULL,
  `numero_facture` text NOT NULL,
  `heure_prestation` int(11) NOT NULL,
  `prix_total` double NOT NULL,
  `informations` varchar(500) NOT NULL,
  `commentaire` varchar(500) NOT NULL,
  `fk_id_rdv` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `facture_entretien`
--

CREATE TABLE `facture_entretien` (
  `id_facture_entretien` int(11) NOT NULL,
  `fk_id_facture` int(11) NOT NULL,
  `fk_id_entretien` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `facture_vente`
--

CREATE TABLE `facture_vente` (
  `id_facture_vente` int(11) NOT NULL,
  `numero_facture` longtext NOT NULL,
  `date_vente` datetime NOT NULL,
  `remise_sur_reprise` double NOT NULL,
  `pourcentage_tva` int(3) NOT NULL,
  `fk_id_vehicule_vente` int(11) NOT NULL,
  `fk_id_client` int(11) DEFAULT NULL,
  `fk_id_employe` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `option_vehicule`
--

CREATE TABLE `option_vehicule` (
  `id_option_vehicule` int(11) NOT NULL,
  `nom_option` varchar(250) NOT NULL,
  `prix` double NOT NULL,
  `disponible` int(1) NOT NULL,
  `fk_id_type_option` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `pack_option`
--

CREATE TABLE `pack_option` (
  `id_pack_option` int(11) NOT NULL,
  `fk_id_option_vehicule` int(11) NOT NULL,
  `fk_id_popv` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `pack_option_pack_vehicule`
--

CREATE TABLE `pack_option_pack_vehicule` (
  `id_pack_option_pack_vehicule` int(11) NOT NULL,
  `nom_pack` varchar(250) NOT NULL,
  `prix_pack` double NOT NULL,
  `disponible` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `popv_vehicule`
--

CREATE TABLE `popv_vehicule` (
  `id_popv_vehicule` int(11) NOT NULL,
  `fk_id_vehicule` int(11) NOT NULL,
  `fk_id_popv` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `rendez_vous_entretien_reparation`
--

CREATE TABLE `rendez_vous_entretien_reparation` (
  `id_rendez_vous_entretien_reparation` int(11) NOT NULL,
  `date_debut` datetime NOT NULL,
  `date_fin` datetime NOT NULL,
  `fk_id_statut` int(11) NOT NULL,
  `fk_id_client_vehicule` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `reparation`
--

CREATE TABLE `reparation` (
  `id_reparation` int(11) NOT NULL,
  `quantite_article` int(3) NOT NULL,
  `fk_id_facture` int(11) NOT NULL,
  `fk_id_article` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `statut`
--

CREATE TABLE `statut` (
  `id_statut` int(11) NOT NULL,
  `statut` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `statut`
--

INSERT INTO `statut` (`id_statut`, `statut`) VALUES
(4, 'Annuler'),
(1, 'En attente'),
(2, 'En cours'),
(5, 'En livraison'),
(6, 'En stock'),
(3, 'Terminé'),
(7, 'Vendu');

-- --------------------------------------------------------

--
-- Structure de la table `statut_employe`
--

CREATE TABLE `statut_employe` (
  `id_statut_employe` int(11) NOT NULL,
  `nom_statut` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `statut_employe`
--

INSERT INTO `statut_employe` (`id_statut_employe`, `nom_statut`) VALUES
(3, 'Administrateur'),
(1, 'Mécanicien'),
(2, 'Vendeur');

-- --------------------------------------------------------

--
-- Structure de la table `type`
--

CREATE TABLE `type` (
  `id_type` int(11) NOT NULL,
  `type` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `type`
--

INSERT INTO `type` (`id_type`, `type`) VALUES
(1, 'Voiture'),
(2, 'Moto'),
(3, 'Générique');

-- --------------------------------------------------------

--
-- Structure de la table `type_option`
--

CREATE TABLE `type_option` (
  `id_type_option` int(11) NOT NULL,
  `nom_type` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `type_option`
--

INSERT INTO `type_option` (`id_type_option`, `nom_type`) VALUES
(7, 'Autres'),
(8, 'Couleur du véhicule'),
(5, 'Habillage'),
(6, 'Inserts de décoration'),
(4, 'Jantes'),
(2, 'Moteur'),
(3, 'Teintes'),
(1, 'Version du modèle');

-- --------------------------------------------------------

--
-- Structure de la table `vehicule`
--

CREATE TABLE `vehicule` (
  `id_vehicule` int(11) NOT NULL,
  `modele` varchar(250) NOT NULL,
  `prix_vehicule` double NOT NULL,
  `nom_image` varchar(250) NOT NULL,
  `temps_livraison` int(11) NOT NULL,
  `disponible` int(1) NOT NULL,
  `fk_id_type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `vehicule_caracteristique`
--

CREATE TABLE `vehicule_caracteristique` (
  `id_vehicule_caracteristique` int(11) NOT NULL,
  `valeur` varchar(250) NOT NULL,
  `fk_id_vehicule` int(11) NOT NULL,
  `fk_id_caracteristique` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `vehicule_option_vehicule`
--

CREATE TABLE `vehicule_option_vehicule` (
  `id_vehicule_option_vehicule` int(11) NOT NULL,
  `fk_id_vehicule` int(11) NOT NULL,
  `fk_id_option_vehicule` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `vehicule_vente`
--

CREATE TABLE `vehicule_vente` (
  `id_vehicule_vente` int(11) NOT NULL,
  `annee_construction` int(4) NOT NULL,
  `date_arrivee` datetime NOT NULL,
  `date_commande` datetime NOT NULL,
  `date_mise_en_circulation` datetime NOT NULL,
  `kilometrage` int(11) NOT NULL,
  `numero_chassis` varchar(250) NOT NULL,
  `prix_total` double NOT NULL,
  `fk_id_statut` int(11) NOT NULL,
  `fk_id_vehicule` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `adresse`
--
ALTER TABLE `adresse`
  ADD PRIMARY KEY (`id_adresse`);

--
-- Index pour la table `article`
--
ALTER TABLE `article`
  ADD PRIMARY KEY (`id_article`);

--
-- Index pour la table `caracteristique`
--
ALTER TABLE `caracteristique`
  ADD PRIMARY KEY (`id_caracteristique`),
  ADD KEY `fk_id_type` (`fk_id_type`);

--
-- Index pour la table `choix_option_vehicule`
--
ALTER TABLE `choix_option_vehicule`
  ADD PRIMARY KEY (`id_choix_option_vehicule`),
  ADD KEY `fk_id_facture_vehicule` (`fk_id_vehicule_vente`),
  ADD KEY `fk_id_option_vehicule` (`fk_id_option_vehicule`);

--
-- Index pour la table `choix_pack_vehicule`
--
ALTER TABLE `choix_pack_vehicule`
  ADD PRIMARY KEY (`id_choix_pack_vehicule`),
  ADD KEY `fk_id_vehicule_vente` (`fk_id_vehicule_vente`),
  ADD KEY `fk_id_popv` (`fk_id_popv`);

--
-- Index pour la table `civilite`
--
ALTER TABLE `civilite`
  ADD PRIMARY KEY (`id_civilite`),
  ADD UNIQUE KEY `unicite_civilite` (`civilite`) USING BTREE;

--
-- Index pour la table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id_client`),
  ADD UNIQUE KEY `email_client` (`email_client`),
  ADD KEY `fk_id_adresse` (`fk_id_adresse`),
  ADD KEY `fk_id_civilite` (`fk_id_civilite`) USING BTREE;

--
-- Index pour la table `client_vehicule`
--
ALTER TABLE `client_vehicule`
  ADD PRIMARY KEY (`id_client_vehicule`),
  ADD KEY `fk_id_client` (`fk_id_client`),
  ADD KEY `fk_id_vehicule` (`fk_id_vehicule`);

--
-- Index pour la table `employe`
--
ALTER TABLE `employe`
  ADD PRIMARY KEY (`id_employe`),
  ADD UNIQUE KEY `unicite_email` (`email`) USING BTREE,
  ADD KEY `fk_id_adresse` (`fk_id_adresse`),
  ADD KEY `fk_id_statut` (`fk_id_statut_employe`),
  ADD KEY `fk_id_civilite` (`fk_id_civilite`) USING BTREE;

--
-- Index pour la table `entretien`
--
ALTER TABLE `entretien`
  ADD PRIMARY KEY (`id_entretien`),
  ADD UNIQUE KEY `unicite_type_entretien` (`type_entretien`) USING BTREE;

--
-- Index pour la table `facture`
--
ALTER TABLE `facture`
  ADD PRIMARY KEY (`id_facture`),
  ADD KEY `fk_id_rdv` (`fk_id_rdv`);

--
-- Index pour la table `facture_entretien`
--
ALTER TABLE `facture_entretien`
  ADD PRIMARY KEY (`id_facture_entretien`),
  ADD KEY `fk_id_facture` (`fk_id_facture`),
  ADD KEY `fk_id_entretien` (`fk_id_entretien`);

--
-- Index pour la table `facture_vente`
--
ALTER TABLE `facture_vente`
  ADD PRIMARY KEY (`id_facture_vente`),
  ADD KEY `fk_id_vehicule_vente` (`fk_id_vehicule_vente`),
  ADD KEY `fk_id_client` (`fk_id_client`),
  ADD KEY `fk_id_employe` (`fk_id_employe`);

--
-- Index pour la table `option_vehicule`
--
ALTER TABLE `option_vehicule`
  ADD PRIMARY KEY (`id_option_vehicule`),
  ADD KEY `fk_id_type_option` (`fk_id_type_option`);

--
-- Index pour la table `pack_option`
--
ALTER TABLE `pack_option`
  ADD PRIMARY KEY (`id_pack_option`),
  ADD KEY `fk_id_option` (`fk_id_option_vehicule`),
  ADD KEY `fk_id_vehicule_pack` (`fk_id_popv`);

--
-- Index pour la table `pack_option_pack_vehicule`
--
ALTER TABLE `pack_option_pack_vehicule`
  ADD PRIMARY KEY (`id_pack_option_pack_vehicule`);

--
-- Index pour la table `popv_vehicule`
--
ALTER TABLE `popv_vehicule`
  ADD PRIMARY KEY (`id_popv_vehicule`),
  ADD KEY `fk_id_vehicule` (`fk_id_vehicule`),
  ADD KEY `fk_id_popv` (`fk_id_popv`);

--
-- Index pour la table `rendez_vous_entretien_reparation`
--
ALTER TABLE `rendez_vous_entretien_reparation`
  ADD PRIMARY KEY (`id_rendez_vous_entretien_reparation`),
  ADD KEY `fk_id_client_vehicule` (`fk_id_client_vehicule`),
  ADD KEY `fk_id_statut` (`fk_id_statut`) USING BTREE;

--
-- Index pour la table `reparation`
--
ALTER TABLE `reparation`
  ADD PRIMARY KEY (`id_reparation`),
  ADD KEY `fk_id_facture` (`fk_id_facture`),
  ADD KEY `fk_id_article` (`fk_id_article`) USING BTREE;

--
-- Index pour la table `statut`
--
ALTER TABLE `statut`
  ADD PRIMARY KEY (`id_statut`),
  ADD UNIQUE KEY `unicite_nom_statut` (`statut`) USING BTREE;

--
-- Index pour la table `statut_employe`
--
ALTER TABLE `statut_employe`
  ADD PRIMARY KEY (`id_statut_employe`),
  ADD UNIQUE KEY `unicite_statut` (`nom_statut`) USING BTREE;

--
-- Index pour la table `type`
--
ALTER TABLE `type`
  ADD PRIMARY KEY (`id_type`);

--
-- Index pour la table `type_option`
--
ALTER TABLE `type_option`
  ADD PRIMARY KEY (`id_type_option`),
  ADD UNIQUE KEY `unicite_nom_type` (`nom_type`) USING BTREE;

--
-- Index pour la table `vehicule`
--
ALTER TABLE `vehicule`
  ADD PRIMARY KEY (`id_vehicule`),
  ADD KEY `fk_id_type` (`fk_id_type`);

--
-- Index pour la table `vehicule_caracteristique`
--
ALTER TABLE `vehicule_caracteristique`
  ADD PRIMARY KEY (`id_vehicule_caracteristique`),
  ADD KEY `fk_id_vehicule` (`fk_id_vehicule`),
  ADD KEY `fk_id_caracteristique` (`fk_id_caracteristique`);

--
-- Index pour la table `vehicule_option_vehicule`
--
ALTER TABLE `vehicule_option_vehicule`
  ADD PRIMARY KEY (`id_vehicule_option_vehicule`),
  ADD KEY `fk_id_vehicule` (`fk_id_vehicule`),
  ADD KEY `fk_id_option_vehicule` (`fk_id_option_vehicule`);

--
-- Index pour la table `vehicule_vente`
--
ALTER TABLE `vehicule_vente`
  ADD PRIMARY KEY (`id_vehicule_vente`),
  ADD KEY `fk_id_statut_livraison` (`fk_id_statut`),
  ADD KEY `fk_id_vehicule` (`fk_id_vehicule`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `adresse`
--
ALTER TABLE `adresse`
  MODIFY `id_adresse` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT pour la table `article`
--
ALTER TABLE `article`
  MODIFY `id_article` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `caracteristique`
--
ALTER TABLE `caracteristique`
  MODIFY `id_caracteristique` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `choix_option_vehicule`
--
ALTER TABLE `choix_option_vehicule`
  MODIFY `id_choix_option_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `choix_pack_vehicule`
--
ALTER TABLE `choix_pack_vehicule`
  MODIFY `id_choix_pack_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `civilite`
--
ALTER TABLE `civilite`
  MODIFY `id_civilite` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `client`
--
ALTER TABLE `client`
  MODIFY `id_client` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `client_vehicule`
--
ALTER TABLE `client_vehicule`
  MODIFY `id_client_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `employe`
--
ALTER TABLE `employe`
  MODIFY `id_employe` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `entretien`
--
ALTER TABLE `entretien`
  MODIFY `id_entretien` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `facture`
--
ALTER TABLE `facture`
  MODIFY `id_facture` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `facture_entretien`
--
ALTER TABLE `facture_entretien`
  MODIFY `id_facture_entretien` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `facture_vente`
--
ALTER TABLE `facture_vente`
  MODIFY `id_facture_vente` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `option_vehicule`
--
ALTER TABLE `option_vehicule`
  MODIFY `id_option_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `pack_option`
--
ALTER TABLE `pack_option`
  MODIFY `id_pack_option` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `pack_option_pack_vehicule`
--
ALTER TABLE `pack_option_pack_vehicule`
  MODIFY `id_pack_option_pack_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `popv_vehicule`
--
ALTER TABLE `popv_vehicule`
  MODIFY `id_popv_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `rendez_vous_entretien_reparation`
--
ALTER TABLE `rendez_vous_entretien_reparation`
  MODIFY `id_rendez_vous_entretien_reparation` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `reparation`
--
ALTER TABLE `reparation`
  MODIFY `id_reparation` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `statut`
--
ALTER TABLE `statut`
  MODIFY `id_statut` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT pour la table `statut_employe`
--
ALTER TABLE `statut_employe`
  MODIFY `id_statut_employe` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `type`
--
ALTER TABLE `type`
  MODIFY `id_type` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `type_option`
--
ALTER TABLE `type_option`
  MODIFY `id_type_option` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pour la table `vehicule`
--
ALTER TABLE `vehicule`
  MODIFY `id_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `vehicule_caracteristique`
--
ALTER TABLE `vehicule_caracteristique`
  MODIFY `id_vehicule_caracteristique` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `vehicule_option_vehicule`
--
ALTER TABLE `vehicule_option_vehicule`
  MODIFY `id_vehicule_option_vehicule` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `vehicule_vente`
--
ALTER TABLE `vehicule_vente`
  MODIFY `id_vehicule_vente` int(11) NOT NULL AUTO_INCREMENT;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `caracteristique`
--
ALTER TABLE `caracteristique`
  ADD CONSTRAINT `caracteristique_type` FOREIGN KEY (`fk_id_type`) REFERENCES `type` (`id_type`);

--
-- Contraintes pour la table `choix_option_vehicule`
--
ALTER TABLE `choix_option_vehicule`
  ADD CONSTRAINT `choix_option_vehicule_option_vehicule` FOREIGN KEY (`fk_id_option_vehicule`) REFERENCES `option_vehicule` (`id_option_vehicule`),
  ADD CONSTRAINT `choix_option_vehicule_vehicule_vente` FOREIGN KEY (`fk_id_vehicule_vente`) REFERENCES `vehicule_vente` (`id_vehicule_vente`);

--
-- Contraintes pour la table `choix_pack_vehicule`
--
ALTER TABLE `choix_pack_vehicule`
  ADD CONSTRAINT `choix_pack_vehicule_popv` FOREIGN KEY (`fk_id_popv`) REFERENCES `pack_option_pack_vehicule` (`id_pack_option_pack_vehicule`),
  ADD CONSTRAINT `choix_pack_vehicule_vehicule_vente` FOREIGN KEY (`fk_id_vehicule_vente`) REFERENCES `vehicule_vente` (`id_vehicule_vente`);

--
-- Contraintes pour la table `client`
--
ALTER TABLE `client`
  ADD CONSTRAINT `client_adresse` FOREIGN KEY (`fk_id_adresse`) REFERENCES `adresse` (`id_adresse`),
  ADD CONSTRAINT `client_civilite` FOREIGN KEY (`fk_id_civilite`) REFERENCES `civilite` (`id_civilite`);

--
-- Contraintes pour la table `client_vehicule`
--
ALTER TABLE `client_vehicule`
  ADD CONSTRAINT `client_vehicule_client` FOREIGN KEY (`fk_id_client`) REFERENCES `client` (`id_client`),
  ADD CONSTRAINT `client_vehicule_vehicule` FOREIGN KEY (`fk_id_vehicule`) REFERENCES `vehicule` (`id_vehicule`);

--
-- Contraintes pour la table `employe`
--
ALTER TABLE `employe`
  ADD CONSTRAINT `employe_adresse` FOREIGN KEY (`fk_id_adresse`) REFERENCES `adresse` (`id_adresse`),
  ADD CONSTRAINT `employe_civilite` FOREIGN KEY (`fk_id_civilite`) REFERENCES `civilite` (`id_civilite`),
  ADD CONSTRAINT `employe_statut_employe` FOREIGN KEY (`fk_id_statut_employe`) REFERENCES `statut_employe` (`id_statut_employe`);

--
-- Contraintes pour la table `facture`
--
ALTER TABLE `facture`
  ADD CONSTRAINT `facture_rdv` FOREIGN KEY (`fk_id_rdv`) REFERENCES `rendez_vous_entretien_reparation` (`id_rendez_vous_entretien_reparation`);

--
-- Contraintes pour la table `facture_entretien`
--
ALTER TABLE `facture_entretien`
  ADD CONSTRAINT `facture_entretien_entretien` FOREIGN KEY (`fk_id_entretien`) REFERENCES `entretien` (`id_entretien`),
  ADD CONSTRAINT `facture_entretien_facture` FOREIGN KEY (`fk_id_facture`) REFERENCES `facture` (`id_facture`);

--
-- Contraintes pour la table `facture_vente`
--
ALTER TABLE `facture_vente`
  ADD CONSTRAINT `facture_vente_client` FOREIGN KEY (`fk_id_client`) REFERENCES `client` (`id_client`),
  ADD CONSTRAINT `facture_vente_employe` FOREIGN KEY (`fk_id_employe`) REFERENCES `employe` (`id_employe`),
  ADD CONSTRAINT `facture_vente_vehicule_vente` FOREIGN KEY (`fk_id_vehicule_vente`) REFERENCES `vehicule_vente` (`id_vehicule_vente`);

--
-- Contraintes pour la table `option_vehicule`
--
ALTER TABLE `option_vehicule`
  ADD CONSTRAINT `option_vehicule_type_option` FOREIGN KEY (`fk_id_type_option`) REFERENCES `type_option` (`id_type_option`);

--
-- Contraintes pour la table `pack_option`
--
ALTER TABLE `pack_option`
  ADD CONSTRAINT `pack_option_option_vehicule` FOREIGN KEY (`fk_id_option_vehicule`) REFERENCES `option_vehicule` (`id_option_vehicule`),
  ADD CONSTRAINT `pack_option_popv` FOREIGN KEY (`fk_id_popv`) REFERENCES `pack_option_pack_vehicule` (`id_pack_option_pack_vehicule`);

--
-- Contraintes pour la table `popv_vehicule`
--
ALTER TABLE `popv_vehicule`
  ADD CONSTRAINT `popv_vehicule_popv` FOREIGN KEY (`fk_id_popv`) REFERENCES `pack_option_pack_vehicule` (`id_pack_option_pack_vehicule`),
  ADD CONSTRAINT `popv_vehicule_vehicule` FOREIGN KEY (`fk_id_vehicule`) REFERENCES `vehicule` (`id_vehicule`);

--
-- Contraintes pour la table `rendez_vous_entretien_reparation`
--
ALTER TABLE `rendez_vous_entretien_reparation`
  ADD CONSTRAINT `rdv_entretien_reparation_client_vehicule` FOREIGN KEY (`fk_id_client_vehicule`) REFERENCES `client_vehicule` (`id_client_vehicule`),
  ADD CONSTRAINT `rdv_entretien_reparation_statut` FOREIGN KEY (`fk_id_statut`) REFERENCES `statut` (`id_statut`);

--
-- Contraintes pour la table `reparation`
--
ALTER TABLE `reparation`
  ADD CONSTRAINT `reparation_article` FOREIGN KEY (`fk_id_article`) REFERENCES `article` (`id_article`),
  ADD CONSTRAINT `reparation_facture` FOREIGN KEY (`fk_id_facture`) REFERENCES `facture` (`id_facture`);

--
-- Contraintes pour la table `vehicule`
--
ALTER TABLE `vehicule`
  ADD CONSTRAINT `vehicule_type_vehicule` FOREIGN KEY (`fk_id_type`) REFERENCES `type` (`id_type`);

--
-- Contraintes pour la table `vehicule_caracteristique`
--
ALTER TABLE `vehicule_caracteristique`
  ADD CONSTRAINT `fk_id_caracteristique` FOREIGN KEY (`fk_id_caracteristique`) REFERENCES `caracteristique` (`id_caracteristique`),
  ADD CONSTRAINT `fk_id_vehicule_id_vehicule` FOREIGN KEY (`fk_id_vehicule`) REFERENCES `vehicule` (`id_vehicule`);

--
-- Contraintes pour la table `vehicule_option_vehicule`
--
ALTER TABLE `vehicule_option_vehicule`
  ADD CONSTRAINT `vehicule_option_vehicule_option_vehicule` FOREIGN KEY (`fk_id_option_vehicule`) REFERENCES `option_vehicule` (`id_option_vehicule`),
  ADD CONSTRAINT `vehicule_option_vehicule_vehicule` FOREIGN KEY (`fk_id_vehicule`) REFERENCES `vehicule` (`id_vehicule`);

--
-- Contraintes pour la table `vehicule_vente`
--
ALTER TABLE `vehicule_vente`
  ADD CONSTRAINT `vehicule_vente_statut_livraison` FOREIGN KEY (`fk_id_statut`) REFERENCES `statut` (`id_statut`),
  ADD CONSTRAINT `vehicule_vente_vehicule` FOREIGN KEY (`fk_id_vehicule`) REFERENCES `vehicule` (`id_vehicule`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
