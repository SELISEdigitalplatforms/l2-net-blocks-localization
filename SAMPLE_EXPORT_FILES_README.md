# Sample XLF Export Request Files

This folder contains sample `.xlf` files that users can upload to request exports from the UILM localization system.

---

## 📋 How It Works

1. **User uploads** a sample `.xlf` file
2. **System parses** the file to determine:
   - Which languages to export (`target-language` attribute)
   - Which modules to export (`original` attribute)
3. **System generates** a ZIP file containing the requested data
4. **User downloads** the ZIP with separate `.xlf` files per language

---

## 📁 Available Sample Files

### 1. [sample-export-request.xlf](sample-export-request.xlf)
**Purpose:** Basic export request template

**What it requests:**
- Languages: German (de), French (fr), Spanish (es)
- Modules: UserManagement, ProductCatalog

**Use when:**
- You need specific languages for specific modules
- Testing the export functionality
- Learning how the system works

**Export result:**
```
uilm_xlf_20251120103000.zip
├── de.xlf       (UserManagement + ProductCatalog in German)
├── fr.xlf       (UserManagement + ProductCatalog in French)
└── es.xlf       (UserManagement + ProductCatalog in Spanish)
```

---

### 2. [sample-export-all-languages.xlf](sample-export-all-languages.xlf)
**Purpose:** Export all configured languages

**What it requests:**
- Languages: de, fr, es, it, pt, ja, zh-CN, ko, ar, nl
- Modules: All modules (`original="*"`)

**Use when:**
- You need a complete export of all translations
- Backup before major changes
- Migrating to a new system

**Export result:**
```
uilm_xlf_20251120103000.zip
├── de.xlf       (All modules in German)
├── fr.xlf       (All modules in French)
├── es.xlf       (All modules in Spanish)
├── it.xlf       (All modules in Italian)
├── pt.xlf       (All modules in Portuguese)
├── ja.xlf       (All modules in Japanese)
├── zh-CN.xlf    (All modules in Chinese Simplified)
├── ko.xlf       (All modules in Korean)
├── ar.xlf       (All modules in Arabic)
└── nl.xlf       (All modules in Dutch)
```

---

### 3. [sample-export-single-module.xlf](sample-export-single-module.xlf)
**Purpose:** Export one module for multiple languages

**What it requests:**
- Languages: German (de), French (fr), Spanish (es)
- Modules: UserManagement only

**Use when:**
- New module released, needs translation
- Specific module updated, needs retranslation
- Different translators handle different modules

**Export result:**
```
uilm_xlf_20251120103000.zip
├── de.xlf       (Only UserManagement in German)
├── fr.xlf       (Only UserManagement in French)
└── es.xlf       (Only UserManagement in Spanish)
```

---

### 4. [sample-export-single-language.xlf](sample-export-single-language.xlf)
**Purpose:** Export all modules for one language

**What it requests:**
- Languages: German (de) only
- Modules: All (UserManagement, ProductCatalog, OrderManagement, etc.)

**Use when:**
- Hired a translator for a specific language
- Need to review all translations in one language
- Language-specific quality assurance

**Export result:**
```
uilm_xlf_20251120103000.zip
└── de.xlf       (All modules in German)
```

---

## 🔧 XLF Request File Structure

```xml
<?xml version="1.0" encoding="utf-8"?>
<xliff version="1.2" xmlns="urn:oasis:names:tc:xliff:document:1.2">

  <file source-language="en"           <!-- Source language (usually English) -->
        target-language="de"           <!-- Target language to export -->
        datatype="plaintext"
        original="UserManagement"      <!-- Module name to export -->
        product-name="UILM">
    <header>
      <note>Description of this export request</note>
    </header>
    <body>
      <!-- Body can be empty for request files -->
    </body>
  </file>

  <!-- Add more <file> elements for more languages/modules -->

</xliff>
```

---

## 📝 Important Attributes

| Attribute | Description | Example | Required |
|-----------|-------------|---------|----------|
| `source-language` | Source language code | `"en"` | ✅ Yes |
| `target-language` | Target language to export | `"de"`, `"fr"`, `"es"` | ✅ Yes |
| `original` | Module name or `"*"` for all | `"UserManagement"` or `"*"` | ✅ Yes |
| `product-name` | Always "UILM" | `"UILM"` | ✅ Yes |
| `datatype` | Always "plaintext" | `"plaintext"` | ✅ Yes |

---

## 🌍 Supported Language Codes

| Language | Code | Example |
|----------|------|---------|
| English | `en` | Source language |
| German | `de` | Deutsch |
| French | `fr` | Français |
| Spanish | `es` | Español |
| Italian | `it` | Italiano |
| Portuguese | `pt` | Português |
| Dutch | `nl` | Nederlands |
| Japanese | `ja` | 日本語 |
| Korean | `ko` | 한국어 |
| Chinese (Simplified) | `zh-CN` | 简体中文 |
| Chinese (Traditional) | `zh-TW` | 繁體中文 |
| Arabic | `ar` | العربية |
| Russian | `ru` | Русский |
| Polish | `pl` | Polski |
| Turkish | `tr` | Türkçe |
| Swedish | `sv` | Svenska |
| Danish | `da` | Dansk |
| Norwegian | `no` | Norsk |
| Finnish | `fi` | Suomi |

---

## 💡 Usage Examples

### Example 1: Export for Translation Agency

**Scenario:** Send German and French modules to a translation agency

**File to use:** Create custom file based on `sample-export-request.xlf`

```xml
<file source-language="en" target-language="de" original="*" product-name="UILM">
  <header><note>For German translation agency</note></header>
  <body></body>
</file>

<file source-language="en" target-language="fr" original="*" product-name="UILM">
  <header><note>For French translation agency</note></header>
  <body></body>
</file>
```

**Steps:**
1. Upload the custom `.xlf` file
2. System exports `uilm_xlf_YYYYMMDDHHMMSS.zip`
3. Extract `de.xlf` and send to German agency
4. Extract `fr.xlf` and send to French agency

---

### Example 2: New Feature Launch

**Scenario:** Just added "PaymentGateway" module, need it in all languages

**File to use:** Create custom file

```xml
<!-- German -->
<file source-language="en" target-language="de" original="PaymentGateway" product-name="UILM">
  <body></body>
</file>

<!-- French -->
<file source-language="en" target-language="fr" original="PaymentGateway" product-name="UILM">
  <body></body>
</file>

<!-- Spanish -->
<file source-language="en" target-language="es" original="PaymentGateway" product-name="UILM">
  <body></body>
</file>

<!-- Add more languages as needed -->
```

---

### Example 3: Quality Assurance

**Scenario:** Review all Italian translations before release

**File to use:** Modify `sample-export-single-language.xlf`

```xml
<!-- Change target-language to "it" for Italian -->
<file source-language="en" target-language="it" original="*" product-name="UILM">
  <header><note>QA review for Italian translations</note></header>
  <body></body>
</file>
```

**Result:** One ZIP file containing `it.xlf` with all modules

---

## 🔄 Workflow

```
┌─────────────────────────────────────────────────────────────┐
│ 1. Choose appropriate sample file                          │
│    - All languages? → sample-export-all-languages.xlf      │
│    - One module? → sample-export-single-module.xlf         │
│    - One language? → sample-export-single-language.xlf     │
│    - Custom? → Modify sample-export-request.xlf            │
└─────────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────────┐
│ 2. Upload .xlf file to UILM system                         │
│    - Via API: POST /api/export/request                     │
│    - Via UI: Upload file button                            │
└─────────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────────┐
│ 3. System processes request                                │
│    - Parses requested languages and modules                │
│    - Retrieves translation data from database              │
│    - Generates individual .xlf files per language          │
│    - Compresses files into ZIP archive                     │
└─────────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────────┐
│ 4. Download ZIP file                                       │
│    - Filename: uilm_xlf_YYYYMMDDHHMMSS.zip                 │
│    - Contains: One .xlf per requested language             │
└─────────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────────┐
│ 5. Extract and use                                         │
│    - Extract ZIP archive                                   │
│    - Send individual .xlf files to translators             │
│    - Open in CAT tools (SDL Trados, MemoQ, etc.)          │
│    - Translate and return                                  │
└─────────────────────────────────────────────────────────────┘
```

---

## 🎯 Best Practices

### ✅ DO:
- Use descriptive notes in `<header>` elements
- Specify exact module names if known
- Use `original="*"` for all modules if unsure
- Test with small request first before full export
- Keep request files for documentation

### ❌ DON'T:
- Include actual translation data in request files
- Use `<trans-unit>` elements (not needed for requests)
- Mix source and target languages incorrectly
- Forget to specify `target-language` attribute
- Upload request files with missing required attributes

---

## 📞 Support

If you encounter issues:
1. Verify all required attributes are present
2. Check language codes match configured languages
3. Ensure module names match exactly (case-sensitive)
4. Review system logs for error messages
5. Contact system administrator

---

## 📚 Related Documentation

- [XLF_EXPORT_IMPLEMENTATION_UPDATED.md](XLF_EXPORT_IMPLEMENTATION_UPDATED.md) - Technical implementation details
- [reference-examples/](reference-examples/) - Sample exported files
- [reference-example.xlf](reference-example.xlf) - Legacy reference file

---

**Last Updated:** November 20, 2025
**Format Version:** XLIFF 1.2
**Status:** ✅ Production Ready
