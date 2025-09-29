# AZ-204 Azure Developer Labs

Welcome to the AZ-204 Azure Developer certification labs repository! This repository contains multiple Azure projects, each organized in separate branches for easy navigation and deployment.

## 🌿 Repository Structure

This repository uses a **branch-per-project** approach where each Azure lab/project is maintained in its own dedicated branch:

```
📦 AZ-204-labs
├── 🌿 master              → Documentation & overview
├── 🌿 lab01-functions     → Azure Functions (C#)
├── 🌿 lab02-cosmosdb      → Cosmos DB integration
├── 🌿 lab03-servicebus    → Service Bus messaging
├── 🌿 lab04-keyvault      → Key Vault secrets
├── 🌿 lab05-storage       → Blob Storage operations
└── 🌿 lab06-containerapp  → Container Apps deployment
```

## 🚀 Quick Start Guide

### Step 1: Clone the Repository

```bash
git clone https://github.com/Owais-Eltigani/AZ-204-labs.git
cd AZ-204-labs
```

### Step 2: List Available Labs

```bash
git branch -r
```

### Step 3: Switch to a Lab Branch

```bash
# Switch to Azure Functions lab
git checkout lab01-functions

# Switch to Cosmos DB lab
git checkout lab02-cosmosdb

# Switch to Service Bus lab
git checkout lab03-servicebus
```

## 📋 Available Labs

| Branch Name          | Description                    | Azure Services         | Language   |
| -------------------- | ------------------------------ | ---------------------- | ---------- |
| `lab01-functions`    | HTTP triggered Azure Functions | Functions, App Service | C#         |
| `lab02-cosmosdb`     | Document database operations   | Cosmos DB, Functions   | C#         |
| `lab03-servicebus`   | Message queue processing       | Service Bus, Functions | C#         |
| `lab04-keyvault`     | Secret management              | Key Vault, Functions   | C#         |
| `lab05-storage`      | Blob storage operations        | Storage Account, Blobs | C#         |
| `lab06-containerapp` | Containerized applications     | Container Apps, ACR    | Docker, C# |

## 🔧 Working with Lab Branches

### Switching Between Labs

```bash
# Check current branch
git branch

# Switch to specific lab
git checkout lab01-functions

# See what's in this lab
ls -la

# Run the lab
dotnet run
```

### Getting Latest Updates

```bash
# Switch to desired lab branch
git checkout lab01-functions

# Pull latest changes
git pull origin lab01-functions
```

### Creating Your Own Lab Branch

```bash
# Create new branch from master
git checkout master
git checkout -b lab07-my-custom-lab

# Add your code and commit
git add .
git commit -m "Add custom lab implementation"
git push origin lab07-my-custom-lab
```

## ⚙️ Deployment Instructions

Each lab branch is configured for independent deployment to Azure:

### Option 1: GitHub Actions (Automatic)

1. **Push to lab branch** triggers automatic deployment
2. **Each branch** deploys to its own Azure Function App
3. **App naming convention**: `az204-{branch-name}`

### Option 2: Manual Deployment

```bash
# Switch to lab branch
git checkout lab01-functions

# Deploy using Azure Functions Core Tools
func azure functionapp publish az204-lab01-functions

# Or use Azure CLI
az functionapp deployment source config \
  --resource-group myResourceGroup \
  --name az204-lab01-functions \
  --repo-url https://github.com/Owais-Eltigani/AZ-204-labs \
  --branch lab01-functions
```

## 📖 Lab-Specific Instructions

### Lab 01: Azure Functions

```bash
git checkout lab01-functions
cd functions/c#
dotnet restore
dotnet run
```

### Lab 02: Cosmos DB

```bash
git checkout lab02-cosmosdb
# Update connection string in local.settings.json
dotnet run
```

### Lab 03: Service Bus

```bash
git checkout lab03-servicebus
# Configure Service Bus connection string
dotnet run
```

## 🛠️ Development Workflow

### For Contributors:

1. **Fork** the repository
2. **Clone** your fork locally
3. **Switch** to the lab branch you want to work on
4. **Make changes** and test locally
5. **Commit** and push to your fork
6. **Create PR** targeting the specific lab branch

### For Students:

1. **Clone** the repository
2. **Switch** between lab branches as needed
3. **Follow** each lab's specific README instructions
4. **Deploy** to your own Azure subscription

## 🔍 Finding What You Need

### View All Branches

```bash
# Local branches
git branch

# Remote branches
git branch -r

# All branches with descriptions
git branch -a
```

### Search for Specific Code

```bash
# Search across all branches
git grep "searchTerm" $(git rev-list --all)

# Search in specific branch
git checkout lab01-functions
grep -r "searchTerm" .
```

## 📚 Prerequisites

- **Azure Subscription** (free tier available)
- **.NET 8.0 SDK** or later
- **Azure Functions Core Tools** v4
- **Git** version control
- **Visual Studio Code** (recommended)

## 🆘 Troubleshooting

### Common Issues:

**Branch not found?**

```bash
git fetch origin
git checkout lab01-functions
```

**Merge conflicts?**

```bash
# Each branch is independent - conflicts shouldn't occur
# If they do, reset to origin:
git reset --hard origin/lab01-functions
```

**Deployment fails?**

- Check Azure Function App name matches branch
- Verify connection strings and app settings
- Ensure proper Azure permissions

## 🤝 Contributing

1. Create issues for bugs or feature requests
2. Fork the repository
3. Work on the appropriate lab branch
4. Submit pull requests to the specific lab branch
5. Follow the existing code style and conventions

## 📞 Support

- **GitHub Issues**: For code-related problems
- **Azure Documentation**: For Azure service questions
- **Microsoft Learn**: For AZ-204 certification guidance

---

**🎯 Pro Tip**: Use `git checkout -` to quickly switch between your last two branches!

**📖 Next Steps**:

1. Choose a lab from the list above
2. Switch to that branch: `git checkout lab##-name`
3. Follow the lab-specific README instructions
4. Deploy to Azure and test your implementation
