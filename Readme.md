# Reflections

## Project Overview

Reflections is a mobile journaling application created using .NET MAUI. The goal of this project is to provide users with a simple and easy way to record, view, edit, and manage personal journal entries directly from their mobile device.

The application allows users to create journal entries with a title, mood selection, date, and written content. Entries are stored locally using SQLite, allowing users to access their journal without needing an internet connection.

This project was created to demonstrate the use of .NET MAUI, the MVVM design pattern, local database storage, and mobile application development concepts.

## Main Features

- Create new journal entries
- View saved journal entries
- Edit existing journal entries
- Delete journal entries
- Search journal entries by title, content, or mood
- Store journal entries locally using SQLite
- Display journal entries with creation date and time
- Mobile-friendly user interface

## Technologies Used

- .NET 9 MAUI
- C#
- XAML
- MVVM Architecture
- SQLite
- sqlite-net-pcl
- Visual Studio

## Requirements

Before building the application, make sure the following are installed:

- Visual Studio 2022 or newer
- .NET 9 SDK
- .NET MAUI workload
- Android Emulator or Android device for testing

## Installing Required Tools

Install the .NET MAUI workload by opening a command prompt and running:

```
dotnet workload install maui
```

To verify the workload installation, run:

```
dotnet workload list
```

Make sure the MAUI workload appears in the list.

## Building the Application

1. Clone the repository:

```
git clone [repository-url]
```

2. Open the project folder.

3. Open the `.sln` file using Visual Studio.

4. Allow Visual Studio to restore NuGet packages.

5. Select the target platform:

- Android Emulator
- Windows Machine

6. Build the project:

```
Build > Build Solution
```

or use:

```
Ctrl + Shift + B
```

## Running the Application

### Using Android Emulator

1. Open Visual Studio.
2. Select an Android emulator from the device dropdown.
3. Press the Run button.
4. Wait for the application to deploy.

### Using Windows

1. Select Windows Machine as the target.
2. Press Run.
3. The application will open as a Windows application.

## Database Information

Reflections uses SQLite for local data storage.

The database is automatically created when the application first runs. Journal entries are stored locally on the user's device and are not uploaded to any external server.

## Author

Holden Kravitz