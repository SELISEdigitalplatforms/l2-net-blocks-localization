# Quick Start - XLF Export

## 🚀 Export in 3 Steps

### Step 1: Choose Your Sample File

| Want to export... | Use this file |
|-------------------|---------------|
| **Multiple languages, specific modules** | [sample-export-request.xlf](sample-export-request.xlf) |
| **All languages, all modules** | [sample-export-all-languages.xlf](sample-export-all-languages.xlf) |
| **One module, multiple languages** | [sample-export-single-module.xlf](sample-export-single-module.xlf) |
| **All modules, one language** | [sample-export-single-language.xlf](sample-export-single-language.xlf) |

### Step 2: Upload the File
- Upload via API or UI
- System processes your request
- Generates ZIP file

### Step 3: Download & Use
- Download: `uilm_xlf_YYYYMMDDHHMMSS.zip`
- Extract files: `de.xlf`, `fr.xlf`, etc.
- Send to translators or CAT tools

---

## 📦 What You Get

```
uilm_xlf_20251120103000.zip
├── de.xlf       ← German translations
├── fr.xlf       ← French translations
├── es.xlf       ← Spanish translations
└── ...
```

Each `.xlf` file contains:
- ✅ All requested modules
- ✅ Source language (English)
- ✅ Target language translations
- ✅ Metadata (routes, character limits)
- ✅ Translation status
- ✅ Ready for CAT tools

---

## 🔧 Customize Request File

```xml
<?xml version="1.0" encoding="utf-8"?>
<xliff version="1.2" xmlns="urn:oasis:names:tc:xliff:document:1.2">

  <!-- Change these values: -->
  <file source-language="en"              <!-- Source: usually "en" -->
        target-language="de"              <!-- Target: "de", "fr", "es", etc. -->
        original="UserManagement"         <!-- Module name or "*" for all -->
        datatype="plaintext"
        product-name="UILM">
    <body></body>
  </file>

  <!-- Add more <file> elements for more exports -->

</xliff>
```

---

## 🌍 Language Codes

| Language | Code | Language | Code |
|----------|------|----------|------|
| German | `de` | Japanese | `ja` |
| French | `fr` | Korean | `ko` |
| Spanish | `es` | Chinese (S) | `zh-CN` |
| Italian | `it` | Arabic | `ar` |
| Portuguese | `pt` | Russian | `ru` |

---

## ⚡ Common Use Cases

### 1. Export Everything
Use: `sample-export-all-languages.xlf`

### 2. New Module Translation
```xml
<file source-language="en" target-language="de" original="NewModule" product-name="UILM">
  <body></body>
</file>
```

### 3. Single Language QA
```xml
<file source-language="en" target-language="de" original="*" product-name="UILM">
  <body></body>
</file>
```

---

## 📚 Full Documentation

For detailed information, see:
- [SAMPLE_EXPORT_FILES_README.md](SAMPLE_EXPORT_FILES_README.md) - Complete guide
- [XLF_EXPORT_IMPLEMENTATION_UPDATED.md](XLF_EXPORT_IMPLEMENTATION_UPDATED.md) - Technical details

---

**Ready to export?** Pick a sample file and upload it! 🎉
