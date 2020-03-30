# Photo API

#### C#/.NET Core API that allows access to photo URLs. Current version: 03.30.20

#### By Krista Rutz, Sarah "Sasa" Schwartz

---

## Table of Contents

1. [Description](#description)
2. [Setup/Installation Requirements](#installation-requirements)
3. [Specifications](#user-stories)
4. [Known Bugs](#known-bugs)
5. [Technologies Used](#technologies-used)
6. [License](#license)

---

## Description

DESCRIPTION HERE

## Installation Requirements

- Clone the repository on Github
- Open the terminal on your desktop
- \$git clone "insert your cloned URL here"
- Change directory to the PhotoApi directory, within the PhotoApi.Solution directory
- \$dotnet restore
- Recreate my database structure with migration:
  - \$dotnet ef migrations add Initial
  - \$dotnet ef database update
- Call this API with your web application or test out the requests using Postman.

## User Stories

- As a user, I want to be able to GET all photos related to a specific tag.
- As a user, I want to be able to POST photos to a specific tag.
- As a user, I want to be able to see a list of all tags.
- As a user, I want to input date parameters and retrieve only photos posted during that timeframe.
- As a user, I want to be able to PUT and DELETE photos, but only if I posted them. (requiring a user_name param to match the user_name of the author on the message)

## Known Bugs

- No known bugs

## Technologies Used

- C#
- .NET

### License

- This software is licensed under the MIT license.
