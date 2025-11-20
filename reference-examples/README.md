# XLF Export Reference Examples

This folder contains reference examples of the individual XLIFF files that are included in the exported ZIP archive.

## ZIP Archive Structure

When you export using OutputType.Xlf, the system generates a ZIP file with the following structure:

```
uilm_xlf_20251120103000.zip
├── de.xlf       (German translations)
├── fr.xlf       (French translations)
├── es.xlf       (Spanish translations)
├── it.xlf       (Italian translations)
└── ...          (one file per target language)
```

## File Naming Convention

- Each file is named after its language code: `{languageCode}.xlf`
- The source language (typically "en") is **not** included as a separate file
- Only target languages are exported

## File Structure

Each `.xlf` file inside the ZIP contains:
- Multiple `<file>` elements (one per module)
- All translation keys for that specific target language
- Source language text in `<source>` elements
- Target language text in `<target>` elements
- Metadata in `<note>` elements

## Example Files

- **[de.xlf](de.xlf)** - Example German translation file
- **[fr.xlf](fr.xlf)** - Example French translation file

Each file demonstrates:
- ✅ Multiple modules (UserManagement, ProductCatalog)
- ✅ Translation states (translated, needs-translation)
- ✅ Metadata (routes, character length, context)
- ✅ Complete XLIFF 1.2 structure

## Usage with CAT Tools

These files can be:
1. **Extracted** from the ZIP archive
2. **Imported** into translation tools (SDL Trados, MemoQ, Phrase, etc.)
3. **Edited** by translators
4. **Re-zipped** with the same structure
5. **Imported back** into UILM system

## Import Compatibility

The import function expects either:
- Individual `.xlf` files (imports that specific language)
- A ZIP archive containing multiple `.xlf` files (imports all languages)

Both formats are automatically detected and processed.
