# 📚 TP – Ma bibliothèque numérique (BookApp)

## 🎯 Objectif pédagogique

Créer une application complète (API + Front) pour gérer une bibliothèque personnelle de livres :
- Ajouter de nouveaux livres via un formulaire
- Afficher les livres existants
- Marquer un livre comme "lu"
- Bonus : filtrer ou styliser les livres selon leur statut

---

## 🔧 Partie 1 – API Minimal .NET (BookApi)

📂 Dossier : `BookApi`

### 1.1. Modèle `Book`

Compléter le fichier `Models/Book.cs` avec la structure suivante :

```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
}
```

### 1.1. Routes à implémenter dans `Program.cs`

- `GET /books` → retourne la liste des livres
- `POST /books` → ajoute un nouveau livre
- `PUT /books/{id}` → met à jour la propriété `IsRead` à `true`

> La base de données est en mémoire (`InMemory`) via Entity Framework Core.

---

## 🖥️ Partie 2 – Interface utilisateur Blazor Server (BookBlazor)

📂 Dossier : `BookBlazor`

### 2.1. Page `Books.razor`

Afficher la liste des livres en les récupérant depuis l’API.

### 2.2. Formulaire d’ajout de livre

Ajouter un formulaire avec les champs :

- Titre (`Title`)
- Auteur (`Author`)

Envoyer la requête via `HttpClient.PostAsJsonAsync`.

### 2.3. Action "Marquer comme lu"

Ajouter un bouton à chaque livre pour envoyer une requête `PUT` à l’API et mettre à jour son statut.

---

## 🌟 Bonus (facultatif)

- Afficher les livres lus avec une couleur différente (ex : vert)
- Ajouter un champ `Genre` dans le modèle `Book` + menu déroulant pour filtrer
- Afficher un compteur : "X livres lus sur Y"

---

## ✅ Livrable attendu

- Application fonctionnelle côté API et Blazor
- Interaction complète entre les deux
- Code propre et lisible
- Un readme clair et structuré expliquant le fonctionnement de l'application
