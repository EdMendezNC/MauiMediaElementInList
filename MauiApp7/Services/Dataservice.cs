using MauiApp7.Models;
using Newtonsoft.Json;

namespace MauiApp7.Services
{
    public class Dataservice
    {
        private List<Monkey> _monkeyData = new List<Monkey>();
        private readonly List<SampleVideo> _sampleVideos;

        private List<Fact> _facts = new List<Fact>();

        public Dataservice()
        {
            _monkeyData = LoadMonkeyData();
            _sampleVideos = LoadSampleVideoData();
            LoadData();
        }
        public IEnumerable<Fact> GetFacts()
        {
            return _facts.AsReadOnly();
        }

        private void LoadData()
        {
            //         var groupedMonkeys = _monkeyData.Where(x=>x.Location == "Central & South America").GroupBy(x => x.Location).ToList();

            //foreach(var group  in groupedMonkeys) 
            //{

            //}

            foreach (var monkey in _monkeyData.Where(x => x.Location == "Central & South America"))
            {
                var fact = new Fact()
                {
                    Id = Guid.NewGuid(),
                    Description = monkey.Name,
                    Data = monkey.Details

                };

                var video = GetRandomVideo();
                fact.FactItems.Add(new FactItem
                {
                    Id = Guid.NewGuid(),
                    FactItemType = FactItemType.Video,
                    UriStoragePath = video.Sources[0],
                    Caption = $"{video.Description}"
                });

                video = GetRandomVideo();
                fact.FactItems.Add(new FactItem
                {
                    Id = Guid.NewGuid(),
                    FactItemType = FactItemType.Video,
                    UriStoragePath = video.Sources[0],
                    Caption = $"{video.Description}"
                });

                _facts.Add(fact);
            }
        }

        private List<Monkey> LoadMonkeyData()
        {

            var monkeys = JsonConvert.DeserializeObject<List<Monkey>>(this.MonkeyData);

            return monkeys;
        }

        private List<SampleVideo> LoadSampleVideoData()
        {

            return JsonConvert.DeserializeObject<List<SampleVideo>>(this.SampleVideos);

        }

        private SampleVideo GetRandomVideo()
        {
            Random rnd = new Random();
            var l = _sampleVideos.Count();
            var i = rnd.Next(l);

            return _sampleVideos.ToArray()[i];
        }

        private readonly string MonkeyData = @"[
	{
		""Name"": ""Baboon"",
		""Location"": ""Africa & Asia"",
		""Details"": ""Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg"",
		""Population"": 10000,
		""Latitude"": -8.783195,
		""Longitude"": 34.508523
	},
	{
		""Name"": ""Capuchin Monkey"",
		""Location"": ""Central & South America"",
		""Details"": ""The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg"",
		""Population"": 23000,
		""Latitude"": 12.769013,
		""Longitude"": -85.602364
	},
	{
		""Name"": ""Blue Monkey"",
		""Location"": ""Central and East Africa"",
		""Details"": ""The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia"",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg"",
		""Population"": 12000,
		""Latitude"": 1.957709,
		""Longitude"": 37.297204
	},
	{
		""Name"": ""Squirrel Monkey"",
		""Location"": ""Central & South America"",
		""Details"": ""The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg"",
		""Population"": 11000,
		""Latitude"": -8.783195,
		""Longitude"": -55.491477
	},
	{
		""Name"": ""Golden Lion Tamarin"",
		""Location"": ""Brazil"",
		""Details"": ""The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg"",
		""Population"": 19000,
		""Latitude"": -14.235004,
		""Longitude"": -51.92528
	},
	{
		""Name"": ""Howler Monkey"",
		""Location"": ""South America"",
		""Details"": ""Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg"",
		""Population"": 8000,
		""Latitude"": -8.783195,
		""Longitude"": -55.491477
	},
	{
		""Name"": ""Japanese Macaque"",
		""Location"": ""Japan"",
		""Details"": ""The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each"",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg"",
		""Population"": 1000,
		""Latitude"": 36.204824,
		""Longitude"": 138.252924
	},
	{
		""Name"": ""Mandrill"",
		""Location"": ""Southern Cameroon, Gabon, and Congo"",
		""Details"": ""The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg"",
		""Population"": 17000,
		""Latitude"": 7.369722,
		""Longitude"": 12.354722
	},
	{
		""Name"": ""Proboscis Monkey"",
		""Location"": ""Borneo"",
		""Details"": ""The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg"",
		""Population"": 15000,
		""Latitude"": 0.961883,
		""Longitude"": 114.55485
	},
	{
		""Name"": ""Sebastian"",
		""Location"": ""Seattle"",
		""Details"": ""This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Nexus 6P!"",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg"",
		""Population"": 1,
		""Latitude"": 47.606209,
		""Longitude"": -122.332071
	},
	{
		""Name"": ""Henry"",
		""Location"": ""Phoenix"",
		""Details"": ""An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!"",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg"",
		""Population"": 1,
		""Latitude"": 33.448377,
		""Longitude"": -112.074037
	},
	{
		""Name"": ""Red-shanked douc"",
		""Location"": ""Vietnam"",
		""Details"": ""The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest."",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg"",
		""Population"": 1300,
		""Latitude"": 16.111648,
		""Longitude"": 108.262122
	},
	{
		""Name"": ""Mooch"",
		""Location"": ""Seattle"",
		""Details"": ""An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone 6s!"",
		""Image"": ""https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG"",
		""Population"": 1,
		""Latitude"": 47.608013,
		""Longitude"": -122.335167
	}]";

        private readonly string SampleVideos = @"[
	{
		""description"": ""Big Buck Bunny tells the story of a giant rabbit with a heart bigger than himself. When one sunny day three rodents rudely harass him, something snaps... and the rabbit ain't no bunny anymore! In the typical cartoon tradition he prepares the nasty rodents a comical revenge.\n\nLicensed under the Creative Commons Attribution license\nhttps://www.bigbuckbunny.org"",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4""
		],
		""subtitle"": ""By Blender Foundation"",
		""thumb"": ""images/BigBuckBunny.jpg"",
		""title"": ""Big Buck Bunny""
	},
	{
		""description"": ""The first Blender Open Movie from 2006"",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4""
		],
		""subtitle"": ""By Blender Foundation"",
		""thumb"": ""images/ElephantsDream.jpg"",
		""title"": ""Elephant Dream""
	},
	{
		""description"": ""HBO GO now works with Chromecast -- the easiest way to enjoy online video on your TV. For when you want to settle into your Iron Throne to watch the latest episodes. For $35.\nLearn how to use Chromecast with HBO GO and more at google.com/chromecast."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4""
		],
		""subtitle"": ""By Google"",
		""thumb"": ""images/ForBiggerBlazes.jpg"",
		""title"": ""For Bigger Blazes""
	},
	{
		""description"": ""Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for when Batman's escapes aren't quite big enough. For $35. Learn how to use Chromecast with Google Play Movies and more at google.com/chromecast."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4""
		],
		""subtitle"": ""By Google"",
		""thumb"": ""images/ForBiggerEscapes.jpg"",
		""title"": ""For Bigger Escape""
	},
	{
		""description"": ""Introducing Chromecast. The easiest way to enjoy online video and music on your TV. For $35.  Find out more at google.com/chromecast."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerFun.mp4""
		],
		""subtitle"": ""By Google"",
		""thumb"": ""images/ForBiggerFun.jpg"",
		""title"": ""For Bigger Fun""
	},
	{
		""description"": ""Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for the times that call for bigger joyrides. For $35. Learn how to use Chromecast with YouTube and more at google.com/chromecast."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerJoyrides.mp4""
		],
		""subtitle"": ""By Google"",
		""thumb"": ""images/ForBiggerJoyrides.jpg"",
		""title"": ""For Bigger Joyrides""
	},
	{
		""description"": ""Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for when you want to make Buster's big meltdowns even bigger. For $35. Learn how to use Chromecast with Netflix and more at google.com/chromecast."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerMeltdowns.mp4""
		],
		""subtitle"": ""By Google"",
		""thumb"": ""images/ForBiggerMeltdowns.jpg"",
		""title"": ""For Bigger Meltdowns""
	},
	{
		""description"": ""Sintel is an independently produced short film, initiated by the Blender Foundation as a means to further improve and validate the free/open source 3D creation suite Blender. With initial funding provided by 1000s of donations via the internet community, it has again proven to be a viable development model for both open 3D technology as for independent animation film.\nThis 15 minute film has been realized in the studio of the Amsterdam Blender Institute, by an international team of artists and developers. In addition to that, several crucial technical and creative targets have been realized online, by developers and artists and teams all over the world.\nwww.sintel.org"",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/Sintel.mp4""
		],
		""subtitle"": ""By Blender Foundation"",
		""thumb"": ""images/Sintel.jpg"",
		""title"": ""Sintel""
	},
	{
		""description"": ""Smoking Tire takes the all-new Subaru Outback to the highest point we can find in hopes our customer-appreciation Balloon Launch will get some free T-shirts into the hands of our viewers."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/SubaruOutbackOnStreetAndDirt.mp4""
		],
		""subtitle"": ""By Garage419"",
		""thumb"": ""images/SubaruOutbackOnStreetAndDirt.jpg"",
		""title"": ""Subaru Outback On Street And Dirt""
	},
	{
		""description"": ""Tears of Steel was realized with crowd-funding by users of the open source 3D creation tool Blender. Target was to improve and test a complete open and free pipeline for visual effects in film - and to make a compelling sci-fi film in Amsterdam, the Netherlands.  The film itself, and all raw material used for making it, have been released under the Creatieve Commons 3.0 Attribution license. Visit the tearsofsteel.org website to find out more about this, or to purchase the 4-DVD box with a lot of extras.  (CC) Blender Foundation - https://www.tearsofsteel.org"",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/TearsOfSteel.mp4""
		],
		""subtitle"": ""By Blender Foundation"",
		""thumb"": ""images/TearsOfSteel.jpg"",
		""title"": ""Tears of Steel""
	},
	{
		""description"": ""The Smoking Tire heads out to Adams Motorsports Park in Riverside, CA to test the most requested car of 2010, the Volkswagen GTI. Will it beat the Mazdaspeed3's standard-setting lap time? Watch and see..."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/VolkswagenGTIReview.mp4""
		],
		""subtitle"": ""By Garage419"",
		""thumb"": ""images/VolkswagenGTIReview.jpg"",
		""title"": ""Volkswagen GTI Review""
	},
	{
		""description"": ""The Smoking Tire is going on the 2010 Bullrun Live Rally in a 2011 Shelby GT500, and posting a video from the road every single day! The only place to watch them is by subscribing to The Smoking Tire or watching at BlackMagicShine.com"",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/WeAreGoingOnBullrun.mp4""
		],
		""subtitle"": ""By Garage419"",
		""thumb"": ""images/WeAreGoingOnBullrun.jpg"",
		""title"": ""We Are Going On Bullrun""
	},
	{
		""description"": ""The Smoking Tire meets up with Chris and Jorge from CarsForAGrand.com to see just how far $1,000 can go when looking for a car.The Smoking Tire meets up with Chris and Jorge from CarsForAGrand.com to see just how far $1,000 can go when looking for a car."",
		""sources"": [
			""https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/WhatCarCanYouGetForAGrand.mp4""
		],
		""subtitle"": ""By Garage419"",
		""thumb"": ""images/WhatCarCanYouGetForAGrand.jpg"",
		""title"": ""What care can you get for a grand?""
	}
]";

    }
}
