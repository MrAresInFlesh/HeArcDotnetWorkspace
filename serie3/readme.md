## Serie 03 (C# avancé)
Série pour travailler avec
- template
- Nullable<T>
- IEnumerable
(- async await)

Récupérer les données d'un fichier au format CSV et les filtrer/projeter/trier/... 
Générer un nouveau fichier ou un affichage avec


### 2.Affichage des Cantons
- VS
- FR
- VD

### 3a.Affichage des par canton alphabétiquement
- Bugnenetes-Savagneres, Bugnenetes-Savagneres, , 1090-1450m, {;}, 38, 23, ( km)
- Charmey, Charmey, FR, 876-1627m, {46.618312;7.167532}, 43, 25, ( km)
- Jaun Bellegarde, Jaun, FR, 1000-1580m, {;}, , , ( km)
- La Berra, La Berra, FR, 1030-1730m, {46.67612;7.175848}, 37, 23, ( km)
- La Chia (Bulle), La Chia (Bulle), FR, 1000-1300m, {46.595344;7.026117}, 20, 15, ( km)
- Les Paccots, Les Paccots, FR, 1061-1568m, {46.522336;6.947622}, 32, 22, ( km)
- Moléson, Moléson, FR, 1000-2000m, {46.560312;7.038395}, 30, 20, ( km)
- Rathvel, Rathvel, FR, 1223-1517m, {46.543366;6.97732}, 25, 18, ( km)
- Schwarzsee, Schwarzsee, FR, 1050-1750m, {46.669265;7.288287}, 37, 23, ( km)
- Château-d'Oex, Château-d'Oex, VD, 1000-1630m, {46.474472;7.134041}, 42, 19, ( km)
- Gryon, Villars-Gryon-Diablerets, VD, 1114-2120m, {46.283954;7.076873}, 53, 35, ( km)
- Les Diablerets, , VD, -m, {;}, 45, 29, ( km)
- Les Mosses- La Lécherette, , VD, 1424-1877m, {46.397351;7.096407}, 34, 24, ( km)
- Les Pléiades, , VD, 1200-1360m, {46.483305;6.909919}, 24, 13, ( km)
- Leysin, , VD, 1263-2200m, {46.347568;7.017436}, 47, 31, ( km)
- Rochers de Naye, , VD, -m, {;}, 35, 18, ( km)
- Rougemont, , VD, -m, {;}, 62, 31, ( km)
- Ste-Croix Les Rasses, Ste-Croix Les Rasses, VD, 1150-1580m, {46.830158;6.541451}, 32, 23, ( km)
- Villars, Villars-Gryon, VD, -m, {;}, 52, 34, ( km)
- Aminona, Crans-Montana, VS, 1500-3000m, {46.332531;7.525716}, 65, 36, ( km)
- Anzère, Anzère, VS, 1500-2420m, {46.295243;7.394784}, 52, 32, ( km)
- Arolla, Arolla, VS, 2003-2889m, {46.021759;7.481295}, 38, 25, ( km)
- Bruson, Bruson, VS, 1103-2232m, {46.076921;7.212537}, 36, 18, ( km)
- Champoussin, Portes du Soleil, VS, 1310-2277m, {46.209627;6.863438}, 45, 32, ( km)
- Champéry, Portes du Soleil, VS, 1040-2277m, {46.175121;6.871132}, 45, 32, ( km)
- Crans-Montana, Crans-Montana, VS, 1500-3000m, {46.312944;7.479375}, 65, 36, ( km)
- Evolène, Evolène, VS, 1407-2680m, {46.091766;7.516482}, 41, 20, ( km)
- Grimentz, Grimentz-Zinal, VS, 1327-2920m, {46.180694;7.556752}, 50, 30, ( km)
- La Forclaz, La Forclaz, VS, 1730-2200m, {46.086148;7.520138}, 25, 16, ( km)
- La Fouly, La Fouly, VS, 1600-2200m, {45.9336;7.098616}, 28, 14, ( km)
- Les Crosets, Portes du Soleil, VS, 1670-2277m, {46.186431;6.836388}, 45, 32, ( km)
- Les Marécottes, Les Marécottes, VS, 1110-2220m, {46.112689;7.009043}, 43, 22, ( km)
- Morgins, Portes du Soleil, VS, 1315-2277m, {46.236595;6.85808}, 54, 41, ( km)
- Nendaz, 4 Vallées, VS, 1400-3330m, {46.179916;7.291131}, 67, 34, ( km)
- Ovronnaz, Ovronnaz, VS, 1350-2427m, {46.198368;7.175124}, 49, 29, ( km)
- St-Luc-Chandolin, St-Luc-Chandolin, VS, 1680-2980m, {46.219587;7.602407}, 54, 32, ( km)
- Torgon, Portes du Soleil, VS, 1100-2277m, {46.320736;6.87632}, 54, 41, ( km)
- Verbier, 4 Vallées, VS, 1500-3330m, {46.093774;7.233448}, 67, 34, ( km)
- Vercorin, Vercorin, VS, 1330-2374m, {46.253897;7.533989}, 50, 30, ( km)
- Veysonnaz, 4 Vallées, VS, 1400-3330m, {46.195695;7.342718}, 67, 34, ( km)
- Vichères, Vichères (+St-Bernard), VS, 1595-2267m, {45.99719;7.166376}, 38, 19, ( km)
- Zinal, Grimentz-Zinal, VS, 1327-2920m, {46.138228;7.623762}, 50, 30, ( km)

### 3b. **SKI resorts with cost below 150 SFr for a family :**
1. La Chia (Bulle): 70 Sfr/day   45 km from HE-ARC
2. Les Pléiades: 74 Sfr/day   57 km from HE-ARC
3. La Forclaz: 82 Sfr/day   111 km from HE-ARC
4. La Fouly: 84 Sfr/day   119 km from HE-ARC
5. Rathvel: 86 Sfr/day   51 km from HE-ARC
6. Moléson: 100 Sfr/day   49 km from HE-ARC
7. Rochers de Naye: 106 Sfr/day
8. Bruson: 108 Sfr/day   105 km from HE-ARC
9. Les Paccots: 108 Sfr/day   53 km from HE-ARC
10. Ste-Croix Les Rasses: 110 Sfr/day   35 km from HE-ARC
11. Vichères: 114 Sfr/day   113 km from HE-ARC
12. Les Mosses- La Lécherette: 116 Sfr/day   68 km from HE-ARC
13. La Berra: 120 Sfr/day   40 km from HE-ARC
14. Schwarzsee: 120 Sfr/day   45 km from HE-ARC
15. Evolène: 122 Sfr/day   110 km from HE-ARC
16. Château-d'Oex: 122 Sfr/day   60 km from HE-ARC
17. Bugnenetes-Savagneres: 122 Sfr/day
18. Arolla: 126 Sfr/day   116 km from HE-ARC
19. Les Marécottes: 130 Sfr/day   99 km from HE-ARC
20. Charmey: 136 Sfr/day   46 km from HE-ARC
21. Les Diablerets: 148 Sfr/day

### 4. Ski resorts closer than 150km from HE-ARC
 4.Resorts by distance
- Ste-Croix Les Rasses: 35km
- La Berra: 40km
- Schwarzsee: 45km
- La Chia (Bulle): 45km
- Charmey: 46km
- Moléson: 49km
- Rathvel: 51km
- Les Paccots: 53km
- Les Pléiades: 57km
- Château-d'Oex: 60km
- Les Mosses- La Lécherette: 68km
- Leysin: 73km
- Torgon: 75km
- Gryon: 80km
- Morgins: 85km
- Anzère: 86km
- Aminona: 86km
- Crans-Montana: 87km
- Champoussin: 88km
- Les Crosets: 91km
- Ovronnaz: 91km
- Champéry: 92km
- Veysonnaz: 94km
- Vercorin: 94km
- Nendaz: 95km
- Les Marécottes: 99km
- St-Luc-Chandolin: 100km
- Grimentz: 102km
- Verbier: 103km
- Bruson: 105km
- Zinal: 109km
- Evolène: 110km
- La Forclaz: 111km
- Vichères: 113km
- Arolla: 116km
- La Fouly: 119km

This is the END...