# CV Site - Developer Portfolio using GitHub API

A .NET Core Web API application designed for developers who want to showcase their portfolio by connecting to their personal GitHub account. The application fetches information about their projects (repositories) and activity and displays it conveniently. Additionally, there's an option to perform a general search in public GitHub repositories.

## Project Description:
The application connects to a GitHub account and displays:
- The user's list of repositories.
- Detailed information for each repository:
    - Code languages
    - Last Commit date
    - Number of stars
    - Number of Pull Requests
    - Link to the website (if exists)
- The ability to search public GitHub repositories by name, language, and username.

The application is developed as a Web API using .NET Core.

## Code Organization:
The project is split into two projects:
1.  **Class Library (Service):** Contains the logic for connecting to GitHub using Octokit.
2.  **Web API:** Uses the Service and provides an API with the required functionality.

## Using Octokit:
The project uses the Octokit library (.NET GitHub API Client) for communication with GitHub.

## API Functionality:
-   **`GetPortfolio`:** Returns a list of repositories from the user's GitHub account with details such as languages, last commit, stars, and link.
-   **`SearchRepositories`:** Allows searching public repositories on GitHub by name, language, and username (optional parameters).

## Caching:
Portfolio information is stored in the Cache for performance improvement, as it is updated infrequently. The Cache is cleared periodically or when a user update is detected on GitHub.

## Local Execution

To run the project locally, follow these steps:

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/Ayala-levi/github-portfolio-api.git](https://github.com/Ayala-levi/github-portfolio-api.git)
    cd github-portfolio-api
    ```

2.  **Create a `secrets.json` file:**
    Create a new file named `secrets.json` in the required location in your project (usually in the same directory as the Web API project's `.csproj` file).

3.  **Add GitHub access details to the `secrets.json` file:**
    Copy the following content into the `secrets.json` file and replace the placeholder values:

    ```json
    {
      "GitHubIntegrationOptions": {
        "UserName": "Your GitHub Username",
        "Token": "Your Personal GitHub Token"
      }
    }
    ```

    **Note:** Never upload the `secrets.json` file to your Git repository! It contains sensitive information. It is usually added to the `.gitignore` file.

4.  **Run the application:**
    You can run the application using the .NET CLI commands:

    ```bash
    dotnet run --project WebApi.csproj
    ```

    Or through your Integrated Development Environment (such as Visual Studio or Rider).
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# CV Site - פורטפוליו מפתחים באמצעות GitHub API

אפליקציית Web API ב-.NET Core המיועדת למפתחים המעוניינים להציג את תיק העבודות שלהם על ידי התחברות לחשבון ה-GitHub האישי שלהם. האפליקציה שואבת מידע על הפרויקטים (repositories) והפעילות שלהם ומציגה אותו בצורה נוחה. בנוסף, קיימת אפשרות לבצע חיפוש כללי במאגרי GitHub ציבוריים.


## תיאור הפרויקט:
האפליקציה מתחברת לחשבון GitHub ומציגה:
- רשימת ה-repositories של המשתמש.
- מידע מפורט עבור כל repository:
    - שפות קוד
    - תאריך Commit אחרון
    - מספר כוכבים
    - מספר Pull Requests
    - קישור לאתר (אם קיים)
- אפשרות חיפוש במאגרי GitHub ציבוריים לפי שם, שפה ושם משתמש.

האפליקציה מפותחת כ-Web API באמצעות .NET Core.

## ארגון הקוד:
הפרויקט מפוצל לשני פרויקטים:
1. **Class Library (Service):** מכיל את הלוגיקה של התחברות ל-גיטאב באמצעות Octokit.
2. **Web API:** משתמש ב-Service ומספק API עם הפונקציונליות הנדרשת.

## שימוש ב-Octokit:
הפרויקט משתמש בספריית Octokit (.NET GitHub API Client) לתקשורת עם GitHub.

## פונקציונליות API:
- **`GetPortfolio`:** מחזירה רשימת רפוזיטורי מהחשבון גיטאב של המשתמש עם פרטים כמו שפות, קומיט אחרון, כוכבים, וקישור
- **`SearchRepositories`:** .מאפשרת לחפש מאגרים ציבוריים ב-גיטאב לפי שם, שפה ושם משתמש (פרמטרים אופציונליים)

## Caching:
מידע הפורטפוליו נשמר ב-Cache לשיפור הביצועים, מאחר והוא מתעדכן לעיתים רחוקות. ה-Cache מתנקה מעת לעת או כאשר מזוהה עדכון בפעילות המשתמש ב-GitHub.


## הרצה מקומית

כדי להריץ את הפרויקט באופן מקומי, בצע את השלבים הבאים:

1.  **שכפל את ה-repository:**
    ```bash
    git clone https://github.com/Ayala-levi/github-portfolio-api.git
    cd github-portfolio-api
    ```

2.  **צור קובץ `secrets.json`:**
    צור קובץ חדש בשם `secrets.json` במיקום הנדרש בפרויקט שלך (בדרך כלל באותה תיקייה של קובץ ה-.csproj של פרויקט ה-Web API).

3.  **הוסף את פרטי הגישה ל-GitHub לקובץ `secrets.json`:**
    העתק את התוכן הבא לקובץ `secrets.json` והחלף את הערכים המתאימים:

    ```json
    {
      "GitHubIntegrationOptions": {
        "UserName": "שם המשתמש שלך בגיטהאב",
        "Token": "הטוקן האישי שלך מגיטהאב"
      }
    }
    ```

    **הערה:** לעולם אל תעלה את קובץ ה-`secrets.json` למאגר הגיט שלך! הוא מכיל מידע רגיש. בדרך כלל מוסיפים אותו ל-.gitignore.

4.  **הרצת האפליקציה:**
    אתה יכול להריץ את האפליקציה באמצעות פקודות ה-.NET CLI:

    ```bash
    dotnet run --project WebApi.csproj
    ```

    או באמצעות סביבת הפיתוח המשולבת שלך (כמו Visual Studio או Rider).

