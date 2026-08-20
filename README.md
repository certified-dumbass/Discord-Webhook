# 🎬 Dreamstreaming Discord Bot

Automatically scan your Jellyfin server for newly added movies and series and post updates directly to Discord using a Discord webhook.

Built for **Jellyfin** and designed to make your media server feel a little more alive. 🍿

---

## ✨ Features

* 🎬 Automatically detects newly added movies
* 📺 Automatically detects newly added series
* 🔍 Scans your Jellyfin library for new content
* 💬 Posts new additions to Discord
* 🤖 Uses a Discord webhook
* ⚙️ Configurable directly through Jellyfin
* 🗓️ Supports scheduled scans
* 💾 Keeps track of previous scans to prevent duplicate notifications
* 🖥️ Runs directly as a Jellyfin plugin

---

## 📸 Example

When new content is detected, the plugin can send a Discord message containing the newly added movies and series.

Example:

```text
🎬 New Movies

• Deadpool & Wolverine
• The Batman
• Interstellar

📺 New Series

• Stranger Things
• Fallout
```

---

## 🔧 Configuration

The plugin can be configured from the Jellyfin administration dashboard.

The configuration includes:

| Setting             | Description                                  |
| ------------------- | -------------------------------------------- |
| 🔑 Jellyfin API Key | API key used to access the Jellyfin server   |
| 🌐 Jellyfin URL     | URL of the Jellyfin server                   |
| 💬 Discord Webhook  | Discord webhook used to post notifications   |
| 🕐 Scan Schedule    | Determines when the server should be scanned |

After configuring the plugin, save the settings and allow the scheduled scan to run.

---

## 🚀 Installation

### Method 1 — Jellyfin Plugin Repository

1. Open the **Jellyfin Dashboard**.
2. Go to **Plugins**.
3. Open **Repositories**.
4. Add the Dreamstreaming plugin repository.
5. Save the repository.
6. Open the **Catalog**.
7. Find **Dreamstreaming Discord Bot**.
8. Install the plugin.
9. Restart Jellyfin.

### Method 2 — Manual Installation

1. Download the latest release from the project's GitHub repository.
2. Extract the plugin files.
3. Copy the plugin into the Jellyfin plugins directory.
4. Restart Jellyfin.
5. Open the Jellyfin Dashboard.
6. Configure the plugin.

---

## 🔄 Updating

When a new version is released:

1. Install the latest version through the Jellyfin Plugin Catalog.
2. Restart Jellyfin.
3. Verify that the new version is shown under **Plugins → Installed**.

The plugin will then use the updated version.

---

## 🔐 Discord Webhook

The plugin uses a Discord webhook to send notifications.

Create a webhook in your Discord server:

**Discord Server → Server Settings → Integrations → Webhooks**

Copy the webhook URL and enter it in the plugin configuration.

> ⚠️ **Never publish your Discord webhook URL publicly.**

If a webhook URL is accidentally exposed, delete the webhook and create a new one.

---

## 🧠 How It Works

The plugin periodically scans the Jellyfin server and compares the current library contents with the previous scan.

When new content is detected, the plugin separates it into:

* 🎬 Movies
* 📺 Series

The results are then sent to the configured Discord webhook.

Previously detected content is stored so that the same movie or series isn't repeatedly announced.

---

## 🛠️ Requirements

* Jellyfin **10.11.x or newer**
* A Discord server
* A Discord webhook
* Jellyfin API access
* .NET runtime supported by the plugin

---

## 🐛 Troubleshooting

### The plugin isn't appearing in Jellyfin

Try restarting Jellyfin after installing the plugin.

Then check:

**Dashboard → Plugins → Installed**

---

### Discord isn't receiving messages

Check that:

* The Discord webhook is correct.
* The webhook still exists.
* The Discord channel is accessible.
* The plugin has been configured correctly.
* The scheduled scan has run.

---

### Movies or series are duplicated

Make sure the plugin's scan data has not been deleted or reset.

The plugin uses previous scan information to determine which items are new.

---

## 📋 Version

Current version: **1.0.0**

See the GitHub releases page for the latest version and changelog.

---

## ❤️ Credits

Created by **Certified-dumbass** for the Dreamstreaming Jellyfin ecosystem.

Part of the **Dreamstreaming** project.

---

## 📜 License

This project is open source.

See the repository license for details.

---

### ⭐ Support the Project

If you find the plugin useful:

* ⭐ Star the repository
* 🐛 Report bugs
* 💡 Suggest features
* 🔧 Contribute improvements

Enjoy your Jellyfin server! 🍿🎬

