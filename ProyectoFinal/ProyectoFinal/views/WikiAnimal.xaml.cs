using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoFinal.model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WikiAnimal : ContentPage
	{
        public bool CreateData = true;
		public WikiAnimal ()
		{
			InitializeComponent ();
            var listWikiData = new List<WikiData>();
            lstWiki.ItemsSource = listWikiData;
		}
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                if (CreateData != false)
                {
                    await App.Database.CreateWikiPage(new model.WikiData
                    {
                        NombreCientifico = "Apis mellifera",
                        Descripcion = "La abeja europea (Apis mellifera) es una especie de abeja altamente social y ampliamente reconocida por su papel en la polinización de cultivos y plantas silvestres. Son insectos voladores, peludos y de color amarillo y negro, con un cuerpo dividido en cabeza, tórax y abdomen. Las abejas desempeñan un papel crucial en la polinización, lo que las convierte en un elemento vital para la reproducción de muchas plantas y la producción de alimentos.",
                        Cuidados = "1. Hábitat: Las abejas necesitan un hábitat adecuado para establecer sus colonias. Las colmenas proporcionan un lugar seguro y protegido donde las abejas pueden vivir y criar a su prole. Estas deben colocarse en un área con acceso a fuentes de néctar y polen.\n\n2. Alimentación: Las abejas se alimentan principalmente de néctar y polen. Proporcionar una variedad de flores y plantas en el entorno cercano a la colmena asegurará que las abejas tengan suficiente alimento para sobrevivir.\n\n3. Protección contra plagas y enfermedades: Mantener las colmenas limpias y en buenas condiciones ayudará a prevenir la propagación de enfermedades y la infestación por parásitos. Realizar revisiones regulares y utilizar prácticas de manejo adecuadas son esenciales.\n\n4. Evitar pesticidas: Las abejas son sensibles a los pesticidas y productos químicos tóxicos. Utilizar métodos de control de plagas naturales y orgánicos en su jardín o área de cultivo ayudará a proteger a las abejas y otros polinizadores.\n\n5. Educación y sensibilización: Concientizar sobre la importancia de las abejas y su rol en la polinización es fundamental. Promover prácticas amigables con las abejas en la comunidad y apoyar la apicultura local contribuirá a su conservación.\n\n6. Consulta con apicultores: Si estás interesado en criar abejas, es recomendable consultar con apicultores experimentados o profesionales para obtener orientación sobre las mejores prácticas de manejo y cuidado.\n\nEs importante destacar que las abejas desempeñan un papel crítico en el equilibrio ecológico y la producción de alimentos, por lo que cuidar de ellas es esencial para nuestro entorno y la seguridad alimentaria."
                    });
                    await App.Database.CreateWikiPage(new model.WikiData
                    {
                        NombreCientifico = "Danaus plexippus",
                        Descripcion = "La mariposa monarca (Danaus plexippus) es una especie migratoria conocida por sus impresionantes patrones de color naranja y negro. Son famosas por sus migraciones anuales a largas distancias, viajando miles de kilómetros entre Norteamérica y México. Las mariposas monarca se alimentan principalmente de néctar y juegan un papel importante en la polinización de plantas.",
                        Cuidados = "1. Plantas hospederas: Las mariposas monarca necesitan plantas hospederas específicas para poner sus huevos y alimentar a las larvas. En Norteamérica, las especies de Asclepias (milkweed) son esenciales para la supervivencia de las larvas.\n\n2. Fuentes de néctar: Proporcionar una variedad de flores con néctar será beneficioso para las mariposas adultas. Plantas como la verbena, la lavanda y la salvia son opciones populares.\n\n3. Evitar pesticidas: Las mariposas son sensibles a los pesticidas, por lo que es importante evitar el uso de productos químicos tóxicos en el jardín o área de cultivo.\n\n4. Protección contra depredadores: Proporcionar refugio y protección contra depredadores es importante. Arbustos y áreas de vegetación densa pueden servir como escondites.\n\n5. Conservación de hábitat: Participar en programas de conservación y preservación de hábitats naturales es crucial para el mantenimiento de las poblaciones de mariposas monarca y otros polinizadores.\n\n6. Educación: Concientizar sobre la importancia de las mariposas monarca y la conservación de su hábitat es fundamental para su supervivencia. Participar en proyectos de monitoreo y seguimiento de migraciones también puede contribuir a su conservación."
                    });
                    await App.Database.CreateWikiPage(new WikiData
                    {
                        NombreCientifico = "Lepisma saccharina",
                        Descripcion = "El pececillo de plata (Lepisma saccharina) es un pequeño insecto conocido por su apariencia plateada y sus movimientos rápidos. Son considerados plagas en hogares y edificios, ya que se alimentan de almidones y azúcares presentes en materiales como papel, cartón y telas.",
                        Cuidados = "1. Eliminación de alimentos: Mantener los alimentos almacenados en recipientes herméticos y limpiar migas y restos de alimentos puede ayudar a prevenir infestaciones de pececillos de plata.\n\n2. Control de humedad: Los pececillos de plata prefieren ambientes húmedos. Utilizar deshumidificadores y ventilar adecuadamente los espacios puede reducir su presencia.\n\n3. Reparaciones estructurales: Sellado de grietas y hendiduras en paredes y pisos puede evitar que los pececillos de plata encuentren lugares para esconderse.\n\n4. Eliminación de desechos: Mantener las áreas limpias y libres de desechos puede reducir las áreas de anidación de estos insectos.\n\n5. Control químico: En casos severos, puede ser necesario usar insecticidas específicos para el control de pececillos de plata. Consultar con profesionales en control de plagas es recomendable."
                    });
                    await App.Database.CreateWikiPage(new WikiData
                    {
                        NombreCientifico = "Blattella germanica",
                        Descripcion = "La cucaracha alemana (Blattella germanica) es una especie de cucaracha pequeña y de color marrón claro. Son consideradas plagas comunes en hogares y establecimientos comerciales. Las cucarachas alemanas son nocturnas y se alimentan de una variedad de alimentos, incluyendo restos de comida, migajas y materiales orgánicos en descomposición.",
                        Cuidados = "1. Limpieza y saneamiento: Mantener una buena higiene y limpieza en la cocina y otras áreas donde se preparen o consuman alimentos es esencial para prevenir infestaciones de cucarachas.\n\n2. Almacenamiento adecuado: Almacenar alimentos en recipientes herméticos y sellados puede evitar que las cucarachas accedan a ellos.\n\n3. Eliminación de residuos: Mantener las áreas libres de desechos y basura puede reducir la disponibilidad de alimento para las cucarachas.\n\n4. Reparaciones estructurales: Sellado de grietas y hendiduras en paredes, pisos y tuberías puede prevenir la entrada de cucarachas a través de estas vías.\\n\\n5. Control químico: En casos graves, se pueden utilizar insecticidas específicos para el control de cucarachas. Es importante seguir las instrucciones de los productos y considerar la ayuda de profesionales en control de plagas.\"\r\n}"
                    });
                    lstWiki.ItemsSource = await App.Database.ReadWiki();
                    CreateData = false;
                }
            }
            catch
            {

            }
        }
        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstWiki.ItemsSource = await App.Database.SearchWiki(e.NewTextValue);
        }
    }
}
