// Constellations example
// To play with enumerations
//
// 2021-10-02   PV
// 2023-01-10	PV		Net7

using System.Collections.Generic;

#nullable enable

namespace CS640;

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
            new("And","Andromeda","Andromedae","Andromède","Andromeda","N","Alpheratz"),
            new("Ant","Antlia Pneumatica","Antliae Pneumaticae","La Machine Pneumatique","Air Pump","S",""),
            new("Aps","Apus","Apodis","L'Oiseau du Paradis","Bird of Paradise","S",""),
            new("Aqr","Aquarius","Aquarii","Le Verseau","Water Carrier","S","Sadalmelik"),
            new("Aql","Aquila","Aquilae","L'Aigle","Eagle","N-S","Altair"),
            new("Ara","Ara","Arae","L'Autel","Altar","S",""),
            new("Ari","Aries","Arietis","Le Bélier","Ram","N","Hamal"),
            new("Aur","Auriga","Aurigae","Le Cocher","Charioteer","N","Capella"),
            new("Boo","Bootes","Bootis","Le Bouvier","Herdsman","N","Arcturus"),
            new("Cae","Caelum","Caeli","Le Burin (du Graveur)","Chisel","S",""),
            new("Cam","Camelopardalis","Camelopardalis","La Girafe","Giraffe","N",""),
            new("Cnc","Cancer","Cancri","Le Cancer","Crab","N","Acubens"),
            new("CVn","Canes Venatici","Canun Venaticorum","Les Chiens de Chasse","Hunting Dogs","N","Cor Caroli"),
            new("CMa","Canis Major","Canis Majoris","Le Grand Chien","Big Dog","S","Sirius"),
            new("CMi","Canis Minor","Canis Minoris","Le Petit Chien","Little Dog","N","Procyon"),
            new("Cap","Capricornus","Capricorni","Le Capricorne","Goat (Capricorn)","S","Algedi"),
            new("Car","Carina","Carinae","La Carène","Keel","S","Canopus"),
            new("Cas","Cassiopeia","Cassiopeiae","Cassiopée","Cassiopeia","N","Schedar"),
            new("Cen","Centaurus","Centauri","Le Centaure","Centaur","S","Rigil Kentaurus"),
            new("Cep","Cepheus","Cephei","Céphée","Cepheus","S","Alderamin"),
            new("Cet","Cetus","Ceti","La Baleine","Whale","S","Menkar"),
            new("Cha","Chamaleon","Chamaleontis","Le Caméléon","Chameleon","S",""),
            new("Cir","Circinus","Circini","Le Compas","Compasses","S",""),
            new("Col","Columba","Columbae","La Colombe","Dove","S","Phact"),
            new("Com","Coma Berenices","Comae Berenices","La Chevelure de Bérénice","Berenice's Hair","N","Diadem"),
            new("CrA","Corona Australis","Coronae Australis","La Couronne Australe","Southern Crown","S",""),
            new("CrB","Corona Borealis","Coronae Borealis","La Couronne Boréale","Northern Crown","N","Alphecca"),
            new("Crv","Corvus","Corvi","Le Corbeau","Crow","S","Alchiba"),
            new("Crt","Crater","Crateris","La Coupe","Cup","S","Alkes"),
            new("Cru","Crux","Crucis","La Croix du Sud","Southern Cross","S","Acrux"),
            new("Cyg","Cygnus","Cygni","Le Cygne","Swan","N","Deneb"),
            new("Del","Delphinus","Delphini","Le Dauphin","Dolphin","N","Sualocin"),
            new("Dor","Dorado","Doradus","La Dorade","Goldfish","S",""),
            new("Dra","Draco","Draconis","Le Dragon","Dragon","N","Thuban"),
            new("Equ","Equuleus","Equulei","Le Petit Cheval","Little Horse","N","Kitalpha"),
            new("Eri","Eridanus","Eridani","L'Eridan","River","S","Achernar"),
            new("For","Fornax","Fornacis","Le Fourneau","Furnace","S",""),
            new("Gem","Gemini","Geminorum","Les Gémeaux","Twins","N","Castor"),
            new("Gru","Grus","Gruis","La Grue","Crane","S","Al Na'ir"),
            new("Her","Hercules","Herculis","Hercule","Hercules","N","Rasalgethi"),
            new("Hor","Horologium","Horologii","L'Horloge","Clock","S",""),
            new("Hya","Hydra","Hydrae","L'Hydre femelle","Hydra (Sea Serpent)","S","Alphard"),
            new("Hyi","Hydrus","Hydri","L'Hydre mâle","Water Serpen (male)","S",""),
            new("Ind","Indus","Indi","L'Oiseau Indien","Indian","S",""),
            new("Lac","Lacerta","Lacertae","Le Lézard","Lizard","N",""),
            new("Leo","Leo","Leonis","Le Lion","Lion","N","Regulus"),
            new("LMi","Leo Minor","Leonis Minoris","Le Petit Lion","Smaller Lion","N",""),
            new("Lep","Lepus","Leporis","Le Lièvre","Hare","S","Arneb"),
            new("Lib","Libra","Librae","La Balance","Balance","S","Zubenelgenubi"),
            new("Lup","Lupus","Lupi","Le Loup","Wolf","S","Men"),
            new("Lyn","Lynx","Lyncis","Le Lynx","Lynx","N",""),
            new("Lyr","Lyra","Lyrae","La Lyre","Lyre","N","Vega"),
            new("Men","(Mons) Mensa","(Montis) Mensae","La Table","Table","S",""),
            new("Mic","Microscopium","Microscopii","Le Microscope","Microscope","S",""),
            new("Mon","Monoceros","Monocerotis","La Licorne","Unicorn","S",""),
            new("Mus","Musca","Muscae","La Mouche","Fly","S",""),
            new("Nor","Norma","Normae","La Règle","Square","S",""),
            new("Oct","Octans","Octantis","L'Octant","Octant","S",""),
            new("Oph","Ophiuchus","Ophiuchi","Le Serpentaire","Serpent Holder","N-S","Rasalhague"),
            new("Ori","Orion","Orionis","Orion","Orion","N-S","Betelgeuse"),
            new("Pav","Pavo","Pavonis","Le Paon","Peacock","S","Peacock"),
            new("Peg","Pegasus","Pegasi","Pégase","Winged Horse","N","Markab"),
            new("Per","Perseus","Persei","Persée","Perseus","N","Mirfak"),
            new("Phe","Phoenix","Phoenicis","Le Phénix","Phoenix","S","Ankaa"),
            new("Pic","Pictor","Pictoris","Le Peintre","Easel","S",""),
            new("Psc","Pisces","Piscium","Les Poissons","Fishes","N","Alrischa"),
            new("PsA","Pisces Austrinus","Pisces Austrini","Le Poisson Austal","Southern Fish","S","Fomalhaut"),
            new("Pup","Puppis","Puppis","La Poupe","Stern","S",""),
            new("Pyx","Pyxis","Pyxidis","La Boussole","Compass","S",""),
            new("Ret","Reticulum","Reticuli","Le Réticule","Reticle","S",""),
            new("Sge","Sagitta","Sagittae","La Flèche","Arrow","N",""),
            new("Sgr","Sagittarius","Sagittarii","Le Sagittaire","Archer","S","Rukbat"),
            new("Sco","Scorpius","Scorpii","Le Scorpion","Scorpion","S","Antares"),
            new("Scl","Sculptor","Sculptoris","Le Sculpteur","Sculptor","S",""),
            new("Sct","Scutum","Scuti","L'Ecu","Shield","S",""),
            new("Ser","Serpens","Serpentis","Le Serpent (Tête)","Serpent","N-S","Unuck al Hai"),
            new("Sex","Sextans","Sextantis","Le Sextant","Sextant","S",""),
            new("Tau","Taurus","Tauri","Le Taureau","Bull","N","Aldebaran"),
            new("Tel","Telescopium","Telescopii","Le Télescope","Telescope","S",""),
            new("Tri","Triangulum","Trianguli","Le Triangle","Triangle","N","Ras al Mothallah"),
            new("TrA","Triangulum Australe","Trianguli Australis","Le Triangle Austral","Southern Triangle","S","Atria"),
            new("Tuc","Tucana","Tucanae","Le Toucan","Toucan","S",""),
            new("UMa","Ursa Major","Ursae Majoris","La Grande Ourse","Great Bear","N","Dubhe"),
            new("UMi","Ursa Minor","Ursae Minoris","La Petite Ourse","Little Bear","N","Polaris"),
            new("Vel","Vela","Velorum","Les Voiles","Sails","S",""),
            new("Vir","Virgo","Virginis","La Vierge","Virgin","N-S","Spica"),
            new("Vol","Volans","Volantis","Le Poisson Volant","Flying Fish","S",""),
            new("Vul","Vulpecula","Vulpeculae","Le Petit Renard","Fox","N",""),
        };
}

