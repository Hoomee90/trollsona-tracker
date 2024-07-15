# Trollsona Organizer

#### By **Samantha Callie**

#### Organize your trolls

## Technologies Used

* HTML
* BootStrap
* CSS
* C#
* ASP.NET Core
* Razor
* EF Core
* SQL

## Description

It's a To-Do-List, but this time with many-to-many relationships between trolls (items) and their strife specibi (tags). The categories are blood caste. Maybe one day I'll make something interesting again.

## Setup/Installation Requirements

1. Press the green <> Code button and select Download ZIP
2. Unzip file
3. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory called "TrollsonaOrganizer".
4. Within that directory, create a file called `appsettings.json`
5. In `appsettings.json`, paste the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=trollsona_organizer;uid=YOUR_USERNAME;pwd=YOUR_PASSWORD;"
  }
}
```
6. To create the database, execute `dotnet ef database update` in the command line (still in the production directory)
7. Now run the command `dotnet run` to compile and execute the application. Then navigate to https://localhost:5001.
8. Optionally, you can run `dotnet run --launch-profile "production"` to run in the run in production mode, as oppose to development.

## Known Bugs

* There are no known bugs at this time

## License

MIT License

Copyright (c) 2024 Samantha Callie

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.