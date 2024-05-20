// PAT Project - Sharp Coders

using PAT.Data;
using PAT.Models.Entities;
using PAT.ViewModels;

namespace PAT
{
    /// <summary>
    /// The app behind code.
    /// </summary>
    public partial class App
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="context">The data context to use.</param>
        public App(AppDbContext context)
        {
            InitializeComponent();
            ShellViewModel = new AppShellViewModel();
            MainPage = new AppShell(ShellViewModel);
            this.context = context;
        }

        /// <summary>
        /// Gets the global view model for the app.
        /// </summary>
        public static AppShellViewModel? ShellViewModel { get; private set; }



        protected override async void OnStart()
        {
            base.OnStart();
            await LoadData();
        }

        private async Task LoadData()
        {

            List<Course> troncCommun = [];
            List<Course> scienceNat = [];
            List<Course> informatique = [];
            List<Course> histoire = [];
            List<Course> designInterieur = [];
            List<Course> commercialisationMode = [];
            List<Course> graphisme = [];

#pragma warning disable IDE0001 // Simplify Names
            PAT.Models.Entities.Program? scienceNatProgram;
            PAT.Models.Entities.Program? infoProgram;
            PAT.Models.Entities.Program? commercialisationModeProgram;
            PAT.Models.Entities.Program? histoireProgram;
            PAT.Models.Entities.Program? designInterieurProgram;
            PAT.Models.Entities.Program? graphismeProgram;
#pragma warning restore IDE0001 // Simplify Names

            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "604-COM-CM", CourseCredits = 2, CourseName = "Anglais 1" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "340-101-MQ", CourseCredits = 2.33, CourseName = "Philosophie 1" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "340-102-MQ", CourseCredits = 2, CourseName = "Philosophie 2" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "340-103-MQ", CourseCredits = 2, CourseName = "Philosophie 3" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "109-101-MQ", CourseCredits = 1, CourseName = "Éducation Physique 1" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "109-102-MQ", CourseCredits = 1, CourseName = "Éducation Physique 2" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "109-103-MQ", CourseCredits = 1, CourseName = "Éducation Physique 3" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "601-101-MQ", CourseCredits = 2.33, CourseName = "Français 1" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "601-102-MQ", CourseCredits = 2.33, CourseName = "Français 2" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "601-103-MQ", CourseCredits = 2.66, CourseName = "Français 3" });
            troncCommun.Add(new Course { IsDeleted = false, CourseCode = "601-EJJ-MV", CourseCredits = 2, CourseName = "Français 4" });

            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "203-SN1-RE", CourseCredits = 2.66, CourseName = "Mécanique" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "201-SN1-RE", CourseCredits = 1.66, CourseName = "Probabilités et Statistiques" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "202-SN1-RE", CourseCredits = 2.66, CourseName = "Chimie générale: La matière" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "101-SN1-RE", CourseCredits = 2, CourseName = "Biologie cellulaire" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "201-SNR-RE", CourseCredits = 2.66, CourseName = "Calcul différentiel" });

            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "202-SN2-RE", CourseCredits = 2, CourseName = "Chimie des solutions" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "101-SNU-RE", CourseCredits = 2, CourseName = "Anatomie et physiologie humaines" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "203-SNC-RE", CourseCredits = 2, CourseName = "Astrophysique et notions d'ingénierie" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "101-SN2-RE", CourseCredits = 1.66, CourseName = "Écologie et évolution" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "203-SN2-RE", CourseCredits = 2, CourseName = "Électricité et magnétisme" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "201-SN3-RE", CourseCredits = 2, CourseName = "Calcul Intégral" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "201-SN4-RE", CourseCredits = 2, CourseName = "Algèbre linéaire et géometrie Vectorielle" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "203-NYC-05", CourseCredits = 2.66, CourseName = "Ondes et physique moderne" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "360-ESP-MV", CourseCredits = 2, CourseName = "Projet d'intégration en science de la nature" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "201-SNC-RE", CourseCredits = 2, CourseName = "Calcul différentiel et intégral dans l'espace" });
            scienceNat.Add(new Course { IsDeleted = false, CourseCode = "202-SNU-RE", CourseCredits = 2, CourseName = "Chimie organique" });
            scienceNat.AddRange(troncCommun);

            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-1M1-MV", CourseCredits = 2, CourseName = "Métiers en commercialisation de la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-1M2-MV", CourseCredits = 2, CourseName = "Marketing de la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-1M3-MV", CourseCredits = 2, CourseName = "Portrait de l'industrie de la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-1M5-MV", CourseCredits = 1, CourseName = "Matières et textiles" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-1M4-MV", CourseCredits = 1, CourseName = "Phénomène de la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-2M1-MV", CourseCredits = 2, CourseName = "Consommer la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-2M2-MV", CourseCredits = 2, CourseName = "Éléments du design" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-2M3-MV", CourseCredits = 2, CourseName = "Qualité des produits mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-2M4-MV", CourseCredits = 3, CourseName = "Mise en marché de la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-2M5-MV", CourseCredits = 1, CourseName = "Stratégies de vente et de démarrage" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "383-3M2-MV", CourseCredits = 1, CourseName = "Environnement économique" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-3M3-MV", CourseCredits = 2, CourseName = "Achat de produits mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-3M4-MV", CourseCredits = 2, CourseName = "Styles et tendances" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-3M5-MV", CourseCredits = 2, CourseName = "Présentation visuelle mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-3M6-MV", CourseCredits = 2, CourseName = "Stratégies de communication mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-4M1-MV", CourseCredits = 2, CourseName = "Innovations commerciales en mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-4M2-MV", CourseCredits = 1, CourseName = "Droits des affaires des entreprises mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-4M3-MV", CourseCredits = 2, CourseName = "Développement de programmes exclusifs mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-4M4-MV", CourseCredits = 3, CourseName = "Activités de communication mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-4M6-MV", CourseCredits = 2, CourseName = "Développement de marchés mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-5M1-MV", CourseCredits = 1, CourseName = "Recherche commerciale mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-5M2-MV", CourseCredits = 2, CourseName = "Comptabilité d'une entreprise mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-5M3-MV", CourseCredits = 1, CourseName = "Gérer des équipes de travail en mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-5M4-MV", CourseCredits = 2, CourseName = "Gestion de l'assortiment de produits mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-5M5-MV", CourseCredits = 2, CourseName = "Stylisme de mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-5M6-MV", CourseCredits = 2, CourseName = "Communication mode intégrée" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-5M8-MV", CourseCredits = 2, CourseName = "Parcours professionnel : objectifs et planification" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-6M1-MV", CourseCredits = 9, CourseName = "Stage d'intervention en commercialisation de la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-6M2-MV", CourseCredits = 4, CourseName = "Projet d'intégration en commercialisation de la mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "571-6M3-MV", CourseCredits = 1, CourseName = "Analyse financière des entreprises mode" });
            commercialisationMode.Add(new Course { IsDeleted = false, CourseCode = "570-6M4-MV", CourseCredits = 2, CourseName = "Espace commercial mode" });
            commercialisationMode.AddRange(troncCommun);

            histoire.Add(new Course { IsDeleted = false, CourseCode = "300-111-MV", CourseCredits = 2, CourseName = "MTI : réussir en sciences humaines" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "350-114-MV", CourseCredits = 1, CourseName = "À la découverte de la psychologie" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "387-111-MV", CourseCredits = 1, CourseName = "L'imagination sociologique" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "385-111-MV", CourseCredits = 1, CourseName = "Politique et citoyenneté" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "320-111-MV", CourseCredits = 1, CourseName = "Regard géographique sur le monde" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "383-111-MV", CourseCredits = 1, CourseName = "Économie et société" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "330-211-MV", CourseCredits = 2, CourseName = "Histoire globale : le monde du XVe siècle à nos jours" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "300-222-RE", CourseCredits = 2, CourseName = "Recherche et méthodes qualitatives en sciences humaines" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "387-211-MV", CourseCredits = 1, CourseName = "Observation et enquête de terrain en sociologie" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "360-223-RE", CourseCredits = 2, CourseName = "Analyse quantitative des réalités humaines" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "350-314-MV", CourseCredits = 1, CourseName = "Psychologie du développement et du bien-être" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "330-311-MV", CourseCredits = 2, CourseName = "Montréal, terrain d'histoire" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "300-411-MV", CourseCredits = 2, CourseName = "Projet de fin d'études en sciences humaines" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "330-170-MV", CourseCredits = 1, CourseName = "Des premiers royaume à la chute de l'empire Romain" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "340-170-MV", CourseCredits = 1, CourseName = "L'Homme et le sacré" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "385-170-MV", CourseCredits = 1, CourseName = "Pouvoir, démocratie et liberté" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "330-270-MV", CourseCredits = 1, CourseName = "Des grandes invasions aux grandes révolutions" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "340-270-MV", CourseCredits = 1, CourseName = "De la modernité à l'hypermodernité : La civilisation en marche" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "330-371-MV", CourseCredits = 1, CourseName = "De croire à savoir : L'évolution de la science" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "360-370-MV", CourseCredits = 1, CourseName = "De l'observation à la théorie" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "510-370-MV", CourseCredits = 2, CourseName = "L'atelier de l'artiste" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "340-370-MV", CourseCredits = 0.33, CourseName = "Dialogue philosophique" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "340-470-MV", CourseCredits = 2, CourseName = "L'histoire a-t-elle un sens?" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "330-470-MV", CourseCredits = 1, CourseName = "D'un continent à l'autre : les peuples qui ont fait le monde" });
            histoire.Add(new Course { IsDeleted = false, CourseCode = "601-470-MV", CourseCredits = 1, CourseName = "De l'épopée au roman" });
            histoire.AddRange(troncCommun);

            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-110-MV", CourseCredits = 1, CourseName = "Documentation technique et profession" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-111-MV", CourseCredits = 3, CourseName = "Introduction à la programmation informatique" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-112-MV", CourseCredits = 2, CourseName = "Création de sites web" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-113-MV", CourseCredits = 3, CourseName = "Systèmes d'exploitation" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "201-184-MV", CourseCredits = 2, CourseName = "Mathématiques de l'information" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "350-280-MV", CourseCredits = 2, CourseName = "Interactions humaines en informatique" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-210-MV", CourseCredits = 3, CourseName = "Programmation orientée objet" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-211-MV", CourseCredits = 3, CourseName = "Applications web" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-212-MV", CourseCredits = 2, CourseName = "Introduction aux bases de données" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-310-MV", CourseCredits = 1, CourseName = "Architecture de logiciel" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-311-MV", CourseCredits = 2, CourseName = "Structure de données" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-312-MV", CourseCredits = 3, CourseName = "Conception de réseaux informatiques" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-313-MV", CourseCredits = 2, CourseName = "Sécurité informatique" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-314-MV", CourseCredits = 2, CourseName = "Programmation de plateformes embarquées" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-410-MV", CourseCredits = 3, CourseName = "Introduction aux plateformes IdO" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-411-MV", CourseCredits = 2, CourseName = "Interfaces humain-machine" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-412-MV", CourseCredits = 5, CourseName = "Projet - Développement d'une application web" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-413-MV", CourseCredits = 2, CourseName = "Développement d'applications pour entreprise" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-414-MV", CourseCredits = 1, CourseName = "Infonuagique" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-510-MV", CourseCredits = 2, CourseName = "Soutien informatique" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-511-MV", CourseCredits = 4, CourseName = "Développement de jeux vidéo" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-512-MV", CourseCredits = 3, CourseName = "Développement d'applications mobiles" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-513-MV", CourseCredits = 2, CourseName = "Piratage éthique" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-514-MV", CourseCredits = 4, CourseName = "Collecte et interprétation de données" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-515-MV", CourseCredits = 2, CourseName = "Maintenance de logiciel" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-610-MV", CourseCredits = 7, CourseName = "Stage d'intégration en entreprise" });
            informatique.Add(new Course { IsDeleted = false, CourseCode = "420-611-MV", CourseCredits = 5, CourseName = "Projet - Développement IdO" });
            informatique.AddRange(troncCommun);

            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D4-MV", CourseCredits = 3, CourseName = "Couleur 1" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "520-1A1-MV", CourseCredits = 1, CourseName = "Courants artistiques et stylistiques 1" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D2-MV", CourseCredits = 2, CourseName = "Esquisse 1" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D5-MV", CourseCredits = 1, CourseName = "Matériaux I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D1-MV", CourseCredits = 2, CourseName = "Introduction au design d'intérieur" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D3-MV", CourseCredits = 2, CourseName = "AutoCAD" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "510-2D5-MV", CourseCredits = 3, CourseName = "Matériaux II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "510-2D2-MV", CourseCredits = 3, CourseName = "Esquisse II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "520-2A1-MV", CourseCredits = 1, CourseName = "Courants artistiques et stylistiques 2" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-2D3-MV", CourseCredits = 3, CourseName = "SketchUP - conception 3D" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-2D4-MV", CourseCredits = 2, CourseName = "Couleur 2" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-2D0-MV", CourseCredits = 2, CourseName = "Projet d'habitat" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D3-MV", CourseCredits = 2, CourseName = "REVIT I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D9-MV", CourseCredits = 2, CourseName = "Éléments d'architecture intérieure I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D8-MV", CourseCredits = 2, CourseName = "Conception sur mesure I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D0-MV", CourseCredits = 4, CourseName = "Projets d'hébergement public" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D5-MV", CourseCredits = 2, CourseName = "Matériaux III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D3-MV", CourseCredits = 2, CourseName = "REVIT II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D9-MV", CourseCredits = 2, CourseName = "Éléments d'architecture intérieure II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D8-MV", CourseCredits = 2, CourseName = "Conception sur mesure II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D0-MV", CourseCredits = 4, CourseName = "Projets d'aménagement de bureau" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D7-MV", CourseCredits = 2, CourseName = "Éclairage" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D5-MV", CourseCredits = 2, CourseName = "Matériaux IV" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D6-MV", CourseCredits = 2, CourseName = "Mobilier et produits spécifiés" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D2-MV", CourseCredits = 3, CourseName = "Présentation et traitement de l'image" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D9-MV", CourseCredits = 2, CourseName = "Éléments d'architecture intérieure III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D8-MV", CourseCredits = 2, CourseName = "Conception sur mesure III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D0-MV", CourseCredits = 5, CourseName = "Projets commerciaux" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D3-MV", CourseCredits = 2, CourseName = "REVIT III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6A1-MV", CourseCredits = 1, CourseName = "Projets actuels en design d'intérieur" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6D1-MV", CourseCredits = 2, CourseName = "Pratique professionnelle" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6D0-MV", CourseCredits = 7, CourseName = "Projet final" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6D3-MV", CourseCredits = 3, CourseName = "Plans d'exécution" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D4-MV", CourseCredits = 3, CourseName = "Couleur 1" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "520-1A1-MV", CourseCredits = 1, CourseName = "Courants artistiques et stylistiques 1" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D2-MV", CourseCredits = 2, CourseName = "Esquisse 1" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D5-MV", CourseCredits = 1, CourseName = "Matériaux I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D1-MV", CourseCredits = 2, CourseName = "Introduction au design d'intérieur" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-1D3-MV", CourseCredits = 2, CourseName = "AutoCAD" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "510-2D5-MV", CourseCredits = 3, CourseName = "Matériaux II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "510-2D2-MV", CourseCredits = 3, CourseName = "Esquisse II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "520-2A1-MV", CourseCredits = 1, CourseName = "Courants artistiques et stylistiques 2" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-2D3-MV", CourseCredits = 3, CourseName = "SketchUP - conception 3D" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-2D4-MV", CourseCredits = 2, CourseName = "Couleur 2" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-2D0-MV", CourseCredits = 2, CourseName = "Projet d'habitat" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D3-MV", CourseCredits = 2, CourseName = "REVIT I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D9-MV", CourseCredits = 2, CourseName = "Éléments d'architecture intérieure I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D8-MV", CourseCredits = 2, CourseName = "Conception sur mesure I" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D0-MV", CourseCredits = 4, CourseName = "Projets d'hébergement public" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-3D5-MV", CourseCredits = 2, CourseName = "Matériaux III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D3-MV", CourseCredits = 2, CourseName = "REVIT II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D9-MV", CourseCredits = 2, CourseName = "Éléments d'architecture intérieure II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D8-MV", CourseCredits = 2, CourseName = "Conception sur mesure II" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D0-MV", CourseCredits = 4, CourseName = "Projets d'aménagement de bureau" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D7-MV", CourseCredits = 2, CourseName = "Éclairage" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D5-MV", CourseCredits = 2, CourseName = "Matériaux IV" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-4D6-MV", CourseCredits = 2, CourseName = "Mobilier et produits spécifiés" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D2-MV", CourseCredits = 3, CourseName = "Présentation et traitement de l'image" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D9-MV", CourseCredits = 2, CourseName = "Éléments d'architecture intérieure III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D8-MV", CourseCredits = 2, CourseName = "Conception sur mesure III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D0-MV", CourseCredits = 5, CourseName = "Projets commerciaux" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-5D3-MV", CourseCredits = 2, CourseName = "REVIT III" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6A1-MV", CourseCredits = 1, CourseName = "Projets actuels en design d'intérieur" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6D1-MV", CourseCredits = 2, CourseName = "Pratique professionnelle" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6D0-MV", CourseCredits = 7, CourseName = "Projet final" });
            designInterieur.Add(new Course { IsDeleted = false, CourseCode = "570-6D3-MV", CourseCredits = 3, CourseName = "Plans d'exécution" });
            designInterieur.AddRange(troncCommun);

            graphisme.Add(new Course { IsDeleted = false, CourseCode = "510-1G0-MV", CourseCredits = 2, CourseName = "Techniques de dessin" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "510-1G1-MV", CourseCredits = 2, CourseName = "Couleur et sérigraphie" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "520-1G1-MV", CourseCredits = 1, CourseName = "Histoire des arts visuels" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-1G0-MV", CourseCredits = 2, CourseName = "Graphisme et typographie" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-1G1-MV", CourseCredits = 3, CourseName = "Graphisme vectoriel 1" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-1G2-MV", CourseCredits = 3, CourseName = "Graphisme matriciel 1" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "510-2G1-MV", CourseCredits = 3, CourseName = "Photographie et sérigraphie" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "520-2G1-MV", CourseCredits = 1, CourseName = "Histoire du graphisme" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-2G0-MV", CourseCredits = 2, CourseName = "Idéation" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-2G1-MV", CourseCredits = 3, CourseName = "Graphisme vectoriel 2 et imprimés" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-2G2-MV", CourseCredits = 3, CourseName = "Graphisme matriciel 2 et interfaces" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-2G3-MV", CourseCredits = 2, CourseName = "Prépresse" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-3G0-MV", CourseCredits = 2, CourseName = "Icônes et pictogrammes" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-3G1-MV", CourseCredits = 2, CourseName = "Photographie et studio" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-3G3-MV", CourseCredits = 2, CourseName = "Gestion de projet" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-3G4-MV", CourseCredits = 3, CourseName = "Publicité 1" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-3G5-MV", CourseCredits = 2, CourseName = "Mises en pages multimédia et imprimés" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-3G6-MV", CourseCredits = 2, CourseName = "Illustration 1" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "510-4G9-MV", CourseCredits = 2, CourseName = "Animation et image cinétique" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-4G1-MV", CourseCredits = 3, CourseName = "Production d'imprimés" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-4G5-MV", CourseCredits = 2, CourseName = "Production multimédia" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-4G6-MV", CourseCredits = 2, CourseName = "Illustration 2" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-4G7-MV", CourseCredits = 3, CourseName = "Packaging 1" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-4G8-MV", CourseCredits = 3, CourseName = "Identité visuelle 1" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-5G0-MV", CourseCredits = 3, CourseName = "Design multimédia" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-5G1-MV", CourseCredits = 3, CourseName = "Design corporatif 1" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-5G7-MV", CourseCredits = 3, CourseName = "Packaging 2" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-5G8-MV", CourseCredits = 3, CourseName = "Identité visuelle 2" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-5G9-MV", CourseCredits = 3, CourseName = "Design cinétique" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-6G0-MV", CourseCredits = 4, CourseName = "Laboratoire de création" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-6G1-MV", CourseCredits = 5, CourseName = "Design corporatif 2" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-6G2-MV", CourseCredits = 3, CourseName = "Stage en entreprise" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-6G3-MV", CourseCredits = 5, CourseName = "Promotion professionnelle" });
            graphisme.Add(new Course { IsDeleted = false, CourseCode = "570-6G4-MV", CourseCredits = 4, CourseName = "Publicité 2" });
            graphisme.AddRange(troncCommun);

#pragma warning disable IDE0001 // Simplify Names
            infoProgram = new PAT.Models.Entities.Program
            {
                IsDeleted = false,
                ProgramCode = "420.B0",
                ProgramName = "Technique de L'informatique",
                Courses = informatique,
            };

            commercialisationModeProgram = new PAT.Models.Entities.Program
            {
                IsDeleted = false,
                ProgramCode = "571.C0",
                ProgramName = "Commercialisation de la mode",
                Courses = commercialisationMode
            };

            scienceNatProgram = new PAT.Models.Entities.Program
            {
                IsDeleted = false,
                ProgramCode = "200.B1",
                ProgramName = "Science de la Nature",
                Courses = scienceNat
            };
            histoireProgram = new PAT.Models.Entities.Program
            {
                IsDeleted = false,
                ProgramCode = "700.B0",
                ProgramName = "Histoire et Civilisation",
                Courses = histoire
            };
            graphismeProgram = new PAT.Models.Entities.Program
            {
                IsDeleted = false,
                ProgramCode = "570.G0",
                ProgramName = "Graphisme",
                Courses = graphisme,
            };

            designInterieurProgram = new PAT.Models.Entities.Program
            {
                IsDeleted = false,
                ProgramCode = "570.E0",
                ProgramName = "Design d'intérieur",
                Courses = designInterieur,
            };

#pragma warning restore IDE0001 // Simplify Names

            context.Programs.Add(designInterieurProgram);
            context.Programs.Add(graphismeProgram);
            context.Programs.Add(histoireProgram);
            context.Programs.Add(scienceNatProgram);
            context.Programs.Add(commercialisationModeProgram);
            context.Programs.Add(infoProgram);


            context.Teachers.Add(new Teacher
            {
                FirstName = "teacher",
                LastName = "teacher",
                Email = "teacher",
                IsDeleted = false,
                IsValidated = true,
                Password = "teacher"
            });

            await context.SaveChangesAsync();
        }
    }
}
