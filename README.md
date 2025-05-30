# 2.PROJECTS-5.vCard-Manager
## ✍️ Author
- **Stephan .M** *(Junior Software Developer)*


## ⚙️ Technology

[![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)  

[![Docker](https://img.shields.io/badge/Docker-Containerized-2496ED?logo=docker&logoColor=white)](https://www.docker.com/)

[![Spectre.Console](https://img.shields.io/badge/Spectre.Console-Terminal_UI-yellow?logo=windows-terminal&logoColor=black)](https://spectreconsole.net/)


## 📄 Description

This is a console application to manage contacts via `.vcf` (vCard) files.  
You can:
- Add new contacts  
- Remove existing contacts  
- Search for contacts  
- Display all contacts  

It was created for educational purposes as part of a campus project.


## 📁 Structure

```
vcard-manager/
├── .git/
├── .vs/
├── .github/
│   └── workflows/
│       └── docker-deploy.yml
├── Solution/
│   ├── AddContacts.cs
│   ├── contacts.vcf
│   ├── DisplayContacts.cs
│   ├── dotnet
│   ├── ExportContacts.cs
│   ├── MainMenu.cs
│   ├── NormalizeWords.cs
│   ├── Program.cs
│   ├── RemoveContacts.cs
│   ├── SearchContacts.cs
│   ├── Solution.csproj
│   ├── Stephan Martin.vcf
│   ├── bin/
│   └── obj/
├── Tests/
│   ├── UnitTest1.cs
│   ├── Tests.csproj
│   ├── bin/
│   └── obj/
├── .gitignore
├── Dockerfile
├── README.md
└── Solution.sln
```

## ℹ️ Information

🚀 The project is automatically built and deployed to [Docker Hub](https://hub.docker.com/r/ndcstudio/vcard-manager) using **GitHub Actions**.  
This makes it easy to pull and run the app anywhere using Docker.

📦 **To run the project using Docker:**

```bash
docker run -it ndcstudio/vcard-manager
```

This command will pull the latest image and launch the terminal UI directly inside a Docker container.


🚫 This is a **solo project** and does **not accept collaborators**.  
It is **publicly available** for transparency and educational sharing,  
but all contributions and code decisions are handled by the author only.

💡 *This project was created as part of a developer training program and is actively maintained for learning and deployment practice.*
