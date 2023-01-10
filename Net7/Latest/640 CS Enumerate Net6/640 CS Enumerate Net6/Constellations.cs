// Constellations example
// To play with enumerations
//
// 2021-10-02   PV
// 2023-01-10	PV		Net7

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace CS640
{
    internal record ConstellationInfo
    {
        public string Abbreviation { get; init; }
        public string Constellation { get; init; }
        public string Genitive { get; init; }
        public string FrenchName { get; init; }
        public string EnglishName { get; init; }
        public string Hemisphere { get; init; }
        public string AlphaStar { get; init; }

        internal ConstellationInfo(string abbreviation, string constellation, string genitive, string frenchName, string englishName, string hemisphere, string alphaStar)
        {
            Abbreviation = abbreviation;
            Constellation = constellation;
            Genitive = genitive;
            FrenchName = frenchName;
            EnglishName = englishName;
            Hemisphere = hemisphere;
            AlphaStar = alphaStar;
        }
    }

    static internal class Constellations
    {
        static internal IEnumerable<ConstellationInfo> GetConstellations()
            => new List<ConstellationInfo>
            {
                new ConstellationInfo("And","Andromeda","Andromedae","Andromède","Andromeda","N","Alpheratz"),
                new ConstellationInfo("Ant","Antlia Pneumatica","Antliae Pneumaticae","La Machine Pneumatique","Air Pump","S",""),
                new ConstellationInfo("Aps","Apus","Apodis","L'Oiseau du Paradis","Bird of Paradise","S",""),
                new ConstellationInfo("Aqr","Aquarius","Aquarii","Le Verseau","Water Carrier","S","Sadalmelik"),
                new ConstellationInfo("Aql","Aquila","Aquilae","L'Aigle","Eagle","N-S","Altair"),
                new ConstellationInfo("Ara","Ara","Arae","L'Autel","Altar","S",""),
                new ConstellationInfo("Ari","Aries","Arietis","Le Bélier","Ram","N","Hamal"),
                new ConstellationInfo("Aur","Auriga","Aurigae","Le Cocher","Charioteer","N","Capella"),
                new ConstellationInfo("Boo","Bootes","Bootis","Le Bouvier","Herdsman","N","Arcturus"),
                new ConstellationInfo("Cae","Caelum","Caeli","Le Burin (du Graveur)","Chisel","S",""),
                new ConstellationInfo("Cam","Camelopardalis","Camelopardalis","La Girafe","Giraffe","N",""),
                new ConstellationInfo("Cnc","Cancer","Cancri","Le Cancer","Crab","N","Acubens"),
                new ConstellationInfo("CVn","Canes Venatici","Canun Venaticorum","Les Chiens de Chasse","Hunting Dogs","N","Cor Caroli"),
                new ConstellationInfo("CMa","Canis Major","Canis Majoris","Le Grand Chien","Big Dog","S","Sirius"),
                new ConstellationInfo("CMi","Canis Minor","Canis Minoris","Le Petit Chien","Little Dog","N","Procyon"),
                new ConstellationInfo("Cap","Capricornus","Capricorni","Le Capricorne","Goat (Capricorn)","S","Algedi"),
                new ConstellationInfo("Car","Carina","Carinae","La Carène","Keel","S","Canopus"),
                new ConstellationInfo("Cas","Cassiopeia","Cassiopeiae","Cassiopée","Cassiopeia","N","Schedar"),
                new ConstellationInfo("Cen","Centaurus","Centauri","Le Centaure","Centaur","S","Rigil Kentaurus"),
                new ConstellationInfo("Cep","Cepheus","Cephei","Céphée","Cepheus","S","Alderamin"),
                new ConstellationInfo("Cet","Cetus","Ceti","La Baleine","Whale","S","Menkar"),
                new ConstellationInfo("Cha","Chamaleon","Chamaleontis","Le Caméléon","Chameleon","S",""),
                new ConstellationInfo("Cir","Circinus","Circini","Le Compas","Compasses","S",""),
                new ConstellationInfo("Col","Columba","Columbae","La Colombe","Dove","S","Phact"),
                new ConstellationInfo("Com","Coma Berenices","Comae Berenices","La Chevelure de Bérénice","Berenice's Hair","N","Diadem"),
                new ConstellationInfo("CrA","Corona Australis","Coronae Australis","La Couronne Australe","Southern Crown","S",""),
                new ConstellationInfo("CrB","Corona Borealis","Coronae Borealis","La Couronne Boréale","Northern Crown","N","Alphecca"),
                new ConstellationInfo("Crv","Corvus","Corvi","Le Corbeau","Crow","S","Alchiba"),
                new ConstellationInfo("Crt","Crater","Crateris","La Coupe","Cup","S","Alkes"),
                new ConstellationInfo("Cru","Crux","Crucis","La Croix du Sud","Southern Cross","S","Acrux"),
                new ConstellationInfo("Cyg","Cygnus","Cygni","Le Cygne","Swan","N","Deneb"),
                new ConstellationInfo("Del","Delphinus","Delphini","Le Dauphin","Dolphin","N","Sualocin"),
                new ConstellationInfo("Dor","Dorado","Doradus","La Dorade","Goldfish","S",""),
                new ConstellationInfo("Dra","Draco","Draconis","Le Dragon","Dragon","N","Thuban"),
                new ConstellationInfo("Equ","Equuleus","Equulei","Le Petit Cheval","Little Horse","N","Kitalpha"),
                new ConstellationInfo("Eri","Eridanus","Eridani","L'Eridan","River","S","Achernar"),
                new ConstellationInfo("For","Fornax","Fornacis","Le Fourneau","Furnace","S",""),
                new ConstellationInfo("Gem","Gemini","Geminorum","Les Gémeaux","Twins","N","Castor"),
                new ConstellationInfo("Gru","Grus","Gruis","La Grue","Crane","S","Al Na'ir"),
                new ConstellationInfo("Her","Hercules","Herculis","Hercule","Hercules","N","Rasalgethi"),
                new ConstellationInfo("Hor","Horologium","Horologii","L'Horloge","Clock","S",""),
                new ConstellationInfo("Hya","Hydra","Hydrae","L'Hydre femelle","Hydra (Sea Serpent)","S","Alphard"),
                new ConstellationInfo("Hyi","Hydrus","Hydri","L'Hydre mâle","Water Serpen (male)","S",""),
                new ConstellationInfo("Ind","Indus","Indi","L'Oiseau Indien","Indian","S",""),
                new ConstellationInfo("Lac","Lacerta","Lacertae","Le Lézard","Lizard","N",""),
                new ConstellationInfo("Leo","Leo","Leonis","Le Lion","Lion","N","Regulus"),
                new ConstellationInfo("LMi","Leo Minor","Leonis Minoris","Le Petit Lion","Smaller Lion","N",""),
                new ConstellationInfo("Lep","Lepus","Leporis","Le Lièvre","Hare","S","Arneb"),
                new ConstellationInfo("Lib","Libra","Librae","La Balance","Balance","S","Zubenelgenubi"),
                new ConstellationInfo("Lup","Lupus","Lupi","Le Loup","Wolf","S","Men"),
                new ConstellationInfo("Lyn","Lynx","Lyncis","Le Lynx","Lynx","N",""),
                new ConstellationInfo("Lyr","Lyra","Lyrae","La Lyre","Lyre","N","Vega"),
                new ConstellationInfo("Men","(Mons) Mensa","(Montis) Mensae","La Table","Table","S",""),
                new ConstellationInfo("Mic","Microscopium","Microscopii","Le Microscope","Microscope","S",""),
                new ConstellationInfo("Mon","Monoceros","Monocerotis","La Licorne","Unicorn","S",""),
                new ConstellationInfo("Mus","Musca","Muscae","La Mouche","Fly","S",""),
                new ConstellationInfo("Nor","Norma","Normae","La Règle","Square","S",""),
                new ConstellationInfo("Oct","Octans","Octantis","L'Octant","Octant","S",""),
                new ConstellationInfo("Oph","Ophiuchus","Ophiuchi","Le Serpentaire","Serpent Holder","N-S","Rasalhague"),
                new ConstellationInfo("Ori","Orion","Orionis","Orion","Orion","N-S","Betelgeuse"),
                new ConstellationInfo("Pav","Pavo","Pavonis","Le Paon","Peacock","S","Peacock"),
                new ConstellationInfo("Peg","Pegasus","Pegasi","Pégase","Winged Horse","N","Markab"),
                new ConstellationInfo("Per","Perseus","Persei","Persée","Perseus","N","Mirfak"),
                new ConstellationInfo("Phe","Phoenix","Phoenicis","Le Phénix","Phoenix","S","Ankaa"),
                new ConstellationInfo("Pic","Pictor","Pictoris","Le Peintre","Easel","S",""),
                new ConstellationInfo("Psc","Pisces","Piscium","Les Poissons","Fishes","N","Alrischa"),
                new ConstellationInfo("PsA","Pisces Austrinus","Pisces Austrini","Le Poisson Austal","Southern Fish","S","Fomalhaut"),
                new ConstellationInfo("Pup","Puppis","Puppis","La Poupe","Stern","S",""),
                new ConstellationInfo("Pyx","Pyxis","Pyxidis","La Boussole","Compass","S",""),
                new ConstellationInfo("Ret","Reticulum","Reticuli","Le Réticule","Reticle","S",""),
                new ConstellationInfo("Sge","Sagitta","Sagittae","La Flèche","Arrow","N",""),
                new ConstellationInfo("Sgr","Sagittarius","Sagittarii","Le Sagittaire","Archer","S","Rukbat"),
                new ConstellationInfo("Sco","Scorpius","Scorpii","Le Scorpion","Scorpion","S","Antares"),
                new ConstellationInfo("Scl","Sculptor","Sculptoris","Le Sculpteur","Sculptor","S",""),
                new ConstellationInfo("Sct","Scutum","Scuti","L'Ecu","Shield","S",""),
                new ConstellationInfo("Ser","Serpens","Serpentis","Le Serpent (Tête)","Serpent","N-S","Unuck al Hai"),
                new ConstellationInfo("Sex","Sextans","Sextantis","Le Sextant","Sextant","S",""),
                new ConstellationInfo("Tau","Taurus","Tauri","Le Taureau","Bull","N","Aldebaran"),
                new ConstellationInfo("Tel","Telescopium","Telescopii","Le Télescope","Telescope","S",""),
                new ConstellationInfo("Tri","Triangulum","Trianguli","Le Triangle","Triangle","N","Ras al Mothallah"),
                new ConstellationInfo("TrA","Triangulum Australe","Trianguli Australis","Le Triangle Austral","Southern Triangle","S","Atria"),
                new ConstellationInfo("Tuc","Tucana","Tucanae","Le Toucan","Toucan","S",""),
                new ConstellationInfo("UMa","Ursa Major","Ursae Majoris","La Grande Ourse","Great Bear","N","Dubhe"),
                new ConstellationInfo("UMi","Ursa Minor","Ursae Minoris","La Petite Ourse","Little Bear","N","Polaris"),
                new ConstellationInfo("Vel","Vela","Velorum","Les Voiles","Sails","S",""),
                new ConstellationInfo("Vir","Virgo","Virginis","La Vierge","Virgin","N-S","Spica"),
                new ConstellationInfo("Vol","Volans","Volantis","Le Poisson Volant","Flying Fish","S",""),
                new ConstellationInfo("Vul","Vulpecula","Vulpeculae","Le Petit Renard","Fox","N",""),
            };
    }
}

