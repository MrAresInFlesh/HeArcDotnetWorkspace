Série assez simple, avec cependant un peu de logique pour le jeu, et un soupçon d'architecture pour la séparation des éléments (vue, modèle, controleur)

## Points à vérifier

### Test du jeu
Jouer et contrôler les points suivants :
- Respect des règles du jeu (condition de victoire, fin de partie nulle)
- Ergonomie du jeu
- Sécurisation des saisies (Parse, indice invalide, ...)

### Architecture

- **Présence des 3 classes: Joueur, Plateau, Rendu**
- **Interface Iterminable** renvoi d'un bool
- ** this(int) [] ** un indexeur pour l'état d'une case
- Il ne devrait pas y avoir de logique dans le main --> le contrôleur du jeu doit dans une classe (Jeu/Joueur)

### Bonnes pratiques

- Conventions de codage C# (règles de nommage)
- XML comments
- 1 fichier par classe
